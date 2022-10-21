using BlazorApp3.Shared;

namespace BlazorApp3.Server.Repositorios
{
    /// <summary>
    /// Interface para la estandarizacion de nuestras clase
    /// su implemetacion realizara las actualizaciones a la base de datos
    /// </summary>
    public interface ITodoRepository
    {

        Task<ServiceResponse<List<TodoI>>> GetAllTodos();
        Task<ServiceResponse<TodoI>> GetTodoById(int id);
        Task<ServiceResponse<TodoI>> CreateTodo(TodoI todo);
        Task<ServiceResponse<bool>> DeleteTodo(int idTodo);
        Task<ServiceResponse<TodoI>> UpdateTodo(TodoI todo);

    }
}
