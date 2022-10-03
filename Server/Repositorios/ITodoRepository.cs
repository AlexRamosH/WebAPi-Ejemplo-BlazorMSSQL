using BlazorApp3.Shared;

namespace BlazorApp3.Server.Repositorios
{
    public interface ITodoRepository
    {

        Task<ServiceResponse<List<Todo>>> GetAllTodos();
        Task<ServiceResponse<Todo>> GetTodoById(int id);
        Task<ServiceResponse<Todo>> CreateTodo(Todo todo);
        Task<ServiceResponse<bool>> DeleteTodo(int idTodo);
        Task<ServiceResponse<Todo>> UpdateTodo(Todo todo);

    }
}
