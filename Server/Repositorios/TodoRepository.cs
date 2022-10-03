using BlazorApp3.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.Repositorios
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TODOContext _context;

        public TodoRepository(TODOContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Todo>> CreateTodo(Todo todo)
        {
            _context.Todos.Add(todo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return new ServiceResponse<Todo>
                {
                    Data = null,
                    Message = $"Ocurrio un error al guardar el todo.",
                    Success = false
                };
            }
            return new ServiceResponse<Todo>
            {
                Data = todo,
                Message = $"Tipo: {todo.Descrpcion}, ha sido registrado exitosamente!"
            };
        }

        public async Task<ServiceResponse<bool>> DeleteTodo(int idTodo)
        {
            var response = new ServiceResponse<bool>();

            Todo cat = await _context.Todos.FirstOrDefaultAsync(x => x.Id == idTodo);

            if (cat == null) { 
            response.Success = false;
            response.Message = "No se encontro esta tarea";
            return response;
        }
            try
            {
                _context.Todos.Remove(cat);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Data=true;
                
            }
            catch (DbUpdateException)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
              

            }
            return response;

        }

        public async Task<ServiceResponse<List<Todo>>> GetAllTodos()
        {
            var response = new ServiceResponse<List<Todo>>
            {
                Data = await _context.Todos.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Todo>> GetTodoById(int id)
        {
            var response = new ServiceResponse<Todo>();
            var tipo = await _context.Todos.FirstOrDefaultAsync(d => d.Id == id);
            if (tipo == null)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
            }
            else
            {
                response.Data = tipo;
            }

            return response;
        }

        public async Task<ServiceResponse<Todo>> UpdateTodo(Todo todo)
        {
            var response = new ServiceResponse<Todo>();
            if (todo == null)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
                return response;

            }

            Todo t = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);

            if (t == null)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
                return response;
            }

            try
            {
                t.Terminado = todo.Terminado;
                _context.Todos.Update(t);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "actualizado";
                response.Data = todo;
                return response;
            }
            catch (DbUpdateException)
            {
                response.Success = false;
                response.Message = "error al actualizar";
                return response;
            }
        }
    }
}
