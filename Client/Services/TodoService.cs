using BlazorApp3.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp3.Client.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Todo> Create(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Todo>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Todo>>>("api/Todo");
            return response.Data;
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
