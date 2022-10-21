using BlazorApp3.Shared;

namespace BlazorApp3.Client.Services
{
    public interface ITodoService
    {
        Task<List<TodoI>> GetAll();
        Task<TodoI> GetById(int id);
        Task<bool> Delete(int id);
        Task<TodoI> Create(TodoI todo);
        Task<TodoI> Update(TodoI todo);
    }
}