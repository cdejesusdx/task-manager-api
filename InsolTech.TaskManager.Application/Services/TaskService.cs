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
        
        /* ---------- CREAR ---------- */
        public async Task<Guid> CreateAsync(TaskDto dto)
        {
            var entity = _map.Map<TaskItem>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return entity.Id;
        }

        /* ---------- ACTUALIZAR ---------- */
        public async Task UpdateAsync(Guid id, TaskDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");

            // Mapear solo campos modificables
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.DueDate = dto.DueDate;
            entity.Status = (Domain.Enums.TaskStatus)dto.Status;

            _repo.Update(entity);
            await _repo.SaveChangesAsync();
        }

        /* ---------- ELIMINAR ---------- */
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");
            _repo.Delete(entity);
            await _repo.SaveChangesAsync();
        }

        /* ---------- OBTENER POR ID ---------- */
        public async Task<TaskDto> GetAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Task {id} not found");
            return _map.Map<TaskDto>(entity);
        }

        /* ---------- LISTAR PAGINADO ---------- */
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