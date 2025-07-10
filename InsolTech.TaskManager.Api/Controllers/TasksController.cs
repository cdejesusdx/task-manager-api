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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskCreateDto dto)
        {
            var id = await _taskService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, TaskUpdateDto dto)
        { 
            await _taskService.UpdateAsync(id, dto); return NoContent(); 
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            await _taskService.DeleteAsync(id); return NoContent(); 
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) => 
            Ok(await _taskService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int size = 10) =>
           Ok(await _taskService.GetAsync(page, size));
    }
}