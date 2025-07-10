using InsolTech.TaskManager.Application.DTOs;
using InsolTech.TaskManager.Application.Common;

namespace InsolTech.TaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="dto">Datos de la tarea a crear.</param>
        /// <returns>Guid de la tarea recién creada.</returns>
        Task<Guid> CreateAsync(TaskCreateDto dto);
        
        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <param name="dto">Datos que se van a actualizar.</param>
        Task UpdateAsync(Guid id, TaskUpdateDto dto);

        /// <summary>
        /// Elimina una tarea de forma permanente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Obtiene una tarea por su <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <exception cref="KeyNotFoundException">
        /// Se lanza si no existe una tarea con el identificador proporcionado.
        /// </exception>
        Task<TaskDto> GetAsync(Guid id);

        /// <summary>
        /// Devuelve una página de tareas según los parámetros indicados.
        /// </summary>
        /// <param name="page">Número de página (empieza en 1).</param>
        /// <param name="size">Cantidad de registros por página.</param>
        /// <returns>
        /// Objeto <see cref="PaginatedList{TaskDto}"/> con la lista de tareas y metadatos de paginación.
        /// </
        Task<PaginatedList<TaskDto>> GetAsync(int page, int size);
    }
}