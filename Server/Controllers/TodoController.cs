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
        public async Task<ActionResult<ServiceResponse<List<Todo>>>> GetTodos()
        {
            var result = await _todoRepository.GetAllTodos();
            return Ok(result);
        }
        [HttpGet("{IdTodo}")]
        public async Task<ActionResult<ServiceResponse<Todo>>> GetTodoById(int IdTodo)
        {
            var result = await _todoRepository.GetTodoById(IdTodo);
            return Ok(result);
        }

        [HttpPost]
        public void CreateTodo(Todo todo)
        {
            _todoRepository.CreateTodo(todo);
        }


    }
}
