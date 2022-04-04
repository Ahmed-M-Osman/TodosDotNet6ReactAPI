using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodosAPIReact.Models;

namespace TodosAPIReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {

            return Ok(await _context.Todos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return BadRequest("Todo not found");

            return Ok(todo);
        } 

        [HttpPost]
        public async Task<ActionResult<List<Todo>>> AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Todo>>> UpdateTodo(Todo request)
        {
            var dbtodo = await _context.Todos.FindAsync(request.Id);
            if (dbtodo == null)
                return BadRequest("Todo not found");

            dbtodo.Text = request.Text;
            dbtodo.Date = request.Date;
            dbtodo.Reminder = request.Reminder;

            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todo>>> DeleteTodo(int id)
        {
            var dbtodo = await _context.Todos.FindAsync(id);
            if (dbtodo == null)
                return BadRequest("Todo not found");


            _context.Todos.Remove(dbtodo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }
    }
}
