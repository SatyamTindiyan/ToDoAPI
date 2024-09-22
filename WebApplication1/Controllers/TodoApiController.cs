using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TodoApiController : ControllerBase
    {

        private readonly TodoService _todoService;

        public TodoApiController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(long id)
        {
            var todoItem = _todoService.GetById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            var newItem = _todoService.Add(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        
        public IActionResult PutTodoItem(long id, TodoItem todoItem)
        {
            if (!_todoService.Update(id, todoItem))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(long id)
        {
            if (!_todoService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
