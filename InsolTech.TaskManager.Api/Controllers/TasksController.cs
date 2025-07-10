using Microsoft.AspNetCore.Mvc;

using InsolTech.TaskManager.Application.DTOs;
using InsolTech.TaskManager.Application.Interfaces;

namespace InsolTech.TaskManager.Api.Controllers
{
    [Route("api/tasks-manager")]
    [ApiController]
    public class TasksController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="dto">Datos de la tarea a crear.</param>
        /// <returns>Guid de la tarea recién creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskCreateDto dto)
        {
            var id = await _taskService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <param name="dto">Datos que se van a actualizar.</param>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, TaskUpdateDto dto)
        { 
            await _taskService.UpdateAsync(id, dto); return NoContent(); 
        }

        /// <summary>
        /// Elimina una tarea de forma permanente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            await _taskService.DeleteAsync(id); return NoContent(); 
        }

        /// <summary>
        /// Obtiene una tarea por su <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <exception cref="KeyNotFoundException">
        /// Se lanza si no existe una tarea con el identificador proporcionado.
        /// </exception>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) => 
            Ok(await _taskService.GetAsync(id));

        /// <summary>
        /// Devuelve una página de tareas según los parámetros indicados.
        /// </summary>
        /// <param name="page">Número de página (empieza en 1).</param>
        /// <param name="size">Cantidad de registros por página.</param>
        /// <returns>
        /// Objeto <see cref="PaginatedList{TaskDto}"/> con la lista de tareas y metadatos de paginación.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int size = 10) =>
           Ok(await _taskService.GetAsync(page, size));
    }
}