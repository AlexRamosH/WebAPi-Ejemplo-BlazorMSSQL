using BlazorApp3.Client.Pages;
using BlazorApp3.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorApp3.Client.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  async Task<TodoI> Create(TodoI todo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/todo", todo);
            return response.Content.ReadFromJsonAsync<ServiceResponse<TodoI?>>().Result.Data;
        }

        public async Task<bool> Delete(int id)
        {
            var response =  await _httpClient.DeleteAsync("api/todo/" + id);

            return response.Content.ReadFromJsonAsync<ServiceResponse<bool>>().Result.Data;
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

        public async Task<TodoI> Update(TodoI todo)
        {
            var response = await _httpClient.PutAsJsonAsync("api/todo", todo);
            return response.Content.ReadFromJsonAsync<ServiceResponse<TodoI?>>().Result.Data;
        }
    }
}
