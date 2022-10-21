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

        public Task<TodoI> Create(TodoI todo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoI>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<TodoI>>>("api/todo");
            return response.Data;
           
        }


        public async Task<TodoI> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<TodoI>>($"api/todo/{id}");
            return response.Data;
        }

        public Task<TodoI> Update(TodoI todo)
        {
            throw new NotImplementedException();
        }
    }
}
