
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApi;

namespace Homework_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Task_Controller : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public Task_Controller(TaskManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
        {
        
            return await _context.TaskItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);

            if (task == null) return NotFound("La tarea no existe.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(CreateTaskDto dto)
        {
            var newTask = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                IsCompleted = false
            };

            _context.TaskItems.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
        {
            var taskInDb = await _context.TaskItems.FindAsync(id);

            if (taskInDb == null) return NotFound();

            taskInDb.Title = dto.Title;
            taskInDb.Description = dto.Description;
            taskInDb.IsCompleted = dto.IsCompleted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Error de concurrencia al actualizar.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);

            if (task == null) return NotFound();

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Tarea {id} eliminada." });
        }
    }
}
