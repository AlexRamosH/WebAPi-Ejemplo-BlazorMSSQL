using BlazorApp3.Shared;

namespace BlazorApp3.Client.Services
{
    public class TodoService : ITodoService
    {
        public Task<Todo> Create(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> Update(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
