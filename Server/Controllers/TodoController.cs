using BlazorApp3.Server.Repositorios;
using BlazorApp3.Shared;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
=======
>>>>>>> 37e70b3484a67ba64c0d3cb78070df9422276cb5
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

<<<<<<< HEAD
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Todo>>>> GetTodos()
        {
            var result = await _todoRepository.GetAllTodos();
            return Ok(result);
        }

        [HttpGet("{IdTipo}")]
        public async Task<ActionResult<ServiceResponse<Todo>>> GetTodoById(int IdTodo)
        {
            var result = await _todoRepository.GetTodoById(IdTodo);
            return Ok(result);
        }
=======
>>>>>>> 37e70b3484a67ba64c0d3cb78070df9422276cb5

        [HttpPost]
        public void CreateTodo(Todo tipo)
        {
            _todoRepository.CreateTodo(tipo);
        }


<<<<<<< HEAD
=======
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



>>>>>>> 37e70b3484a67ba64c0d3cb78070df9422276cb5
    }
}
