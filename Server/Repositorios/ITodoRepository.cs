using BlazorApp3.Shared;

namespace BlazorApp3.Server.Repositorios
{
    public interface ITodoRepository
    {

        Task<ServiceResponse<List<TodoI>>> GetAllTodos();
        Task<ServiceResponse<TodoI>> GetTodoById(int id);
        Task<ServiceResponse<TodoI>> CreateTodo(TodoI todo);
        Task<ServiceResponse<bool>> DeleteTodo(int idTodo);
        Task<ServiceResponse<TodoI>> UpdateTodo(TodoI todo);

    }
}
