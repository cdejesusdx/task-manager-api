using AutoMapper;

using InsolTech.TaskManager.Domain.Entities;
using InsolTech.TaskManager.Application.DTOs;
using InsolTech.TaskManager.Application.Common;
using InsolTech.TaskManager.Domain.Repositories;
using InsolTech.TaskManager.Application.Interfaces;

namespace InsolTech.TaskManager.Application.Services
{
    public class TaskService(ITaskRepository repo, IMapper map) : ITaskService
    {
        private readonly IMapper _map = map;
        private readonly ITaskRepository _repo = repo;

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="dto">Datos de la tarea a crear.</param>
        /// <returns>Guid de la tarea recién creada.</returns>
        public async Task<Guid> CreateAsync(TaskCreateDto dto)
        {
            var entity = _map.Map<TaskItem>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <param name="dto">Datos que se van a actualizar.</param>
        public async Task UpdateAsync(Guid id, TaskUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");

            // Mapear solo campos modificables
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.DueDate = dto.DueDate;
            entity.Status = dto.Status;

            _repo.Update(entity);
            await _repo.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una tarea de forma permanente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");
            _repo.Delete(entity);
            await _repo.SaveChangesAsync();
        }

        /// <summary>
        /// Obtiene una tarea por su <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <exception cref="KeyNotFoundException">
        /// Se lanza si no existe una tarea con el identificador proporcionado.
        /// </exception>
        public async Task<TaskDto> GetAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");
            return _map.Map<TaskDto>(entity);
        }

        /// <summary>
        /// Devuelve una página de tareas según los parámetros indicados.
        /// </summary>
        /// <param name="page">Número de página (empieza en 1).</param>
        /// <param name="size">Cantidad de registros por página.</param>
        /// <returns>
        /// Objeto <see cref="PaginatedList{TaskDto}"/> con la lista de tareas y metadatos de paginación.
        /// </returns>
        public async Task<PaginatedList<TaskDto>> GetAsync(int page, int size)
        {
            // 1) Consulta IQueryable
            var query = _repo.AsQueryable();              
            
            // 2) Ejecutar paginación genérica
            var entityPage = await PaginatedList<TaskItem>.CreateAsync(query, page, size);
            
            // 3) Mapear items
            var dtoItems = _map.Map<List<TaskDto>>(entityPage.Items);

            // 4) Devolver DTO paginado
            return new PaginatedList<TaskDto>(dtoItems,
                                              entityPage.TotalCount,
                                              entityPage.PageIndex,
                                              entityPage.PageSize);
        }
    }
}