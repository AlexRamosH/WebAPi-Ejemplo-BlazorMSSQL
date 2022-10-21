using BlazorApp3.Server.Repositorios;
using BlazorApp3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{

    /// <summary>
    /// Clase utilizada para que el cliente interactue con los repositorios
    /// manteniendo un patron MVC creara cada uno de los metodos utilizados en 
    /// TodoRepository para conectarlos
    /// </summary>
    //ruta al realizar las llamadas api/todo
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _todoRepository.DeleteTodo(id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TodoI>>> Update(TodoI todo)
        {
            try
            {
                var result = await _todoRepository.UpdateTodo(todo);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<List<TodoI>> { Message = e.Message });
            }
        }
    }
}
