using BlazorApp3.Server.Repositorios;
using BlazorApp3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository TodoRepository)
        {
            _todoRepository = TodoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TodoI>>>> GetTodos()
        {
            var result = await _todoRepository.GetAllTodos();
            return Ok(result);
        }

        [HttpGet("{idtodo}")]
        public async Task<ActionResult<ServiceResponse<TodoI>>> GetTodoById(int IdTodo)
        {
            var result = await _todoRepository.GetTodoById(IdTodo);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TodoI>>> CreateTodo(TodoI todo)
        {

            try
            {
                var result = await _todoRepository.CreateTodo(todo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<TodoI> { Message = e.Message });
            }

        }


    }
}
