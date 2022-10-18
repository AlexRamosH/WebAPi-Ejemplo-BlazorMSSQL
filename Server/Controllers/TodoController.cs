using BlazorApp3.Server.Repositorios;
using BlazorApp3.Shared;
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


        [HttpPost]
        public void CreateTodo(Todo tipo)
        {
            _todoRepository.CreateTodo(tipo);
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Todo>>>> GetTodos()
        {
            var result = await _todoRepository.GetAllTodos();
            return Ok(result);
        }


        [HttpGet("{IdTipo}")]
        public async Task<ActionResult<ServiceResponse<Todo>>> GetTodoById(int IdTipo)
        {
            var result = await _todoRepository.GetTodoById(IdTipo);
            return Ok(result);
        }



    }
}
