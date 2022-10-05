using BlazorApp3.Shared;

namespace BlazorApp3.Client.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAll();
        Task<Todo> GetById(int id);
        Task<bool> Delete(int id);
        Task<Todo> Create(Todo todo);
        Task<Todo> Update(Todo todo);
    }
}