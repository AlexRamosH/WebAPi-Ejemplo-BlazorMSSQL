using BlazorApp3.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.Repositorios
{
    /// <summary>
    /// Clase que implementa la interface ITodoRepository
    /// Realizara las llamadas necesarias para los metodos creados
    /// de esta forma se realiza las actualizaciones insert etc en la tabla TODO
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        private readonly TODOContext _context;

        /// <summary>
        /// Agrega el contexto de la base de datos a la clase
        /// pare realizar las opereciones nesesarias
        /// </summary>
        /// <param name="context"> Referencia a la base de datos</param>
        public TodoRepository(TODOContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agregara un nuevo dato a la tabla TODO
        /// </summary>
        /// <param name="todo">objeto base con la informacion a registrar</param>
        /// <returns>Respuesta del query</returns>
        public async Task<ServiceResponse<TodoI>> CreateTodo(TodoI todo)
        {
            _context.Todos.Add(todo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return new ServiceResponse<TodoI>
                {
                    Data = null,
                    Message = $"Ocurrio un error al guardar el todo.",
                    Success = false
                };
            }
            return new ServiceResponse<TodoI>
            {
                Data = todo,
                Message = $"Tipo: {todo.Descripcion}, ha sido registrado exitosamente!"
            };
        }

        /// <summary>
        /// Eliminara el dato indicado de la tabla Todo
        /// </summary>
        /// <param name="idTodo"> id de la tarea</param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> DeleteTodo(int idTodo)
        {
            var response = new ServiceResponse<bool>();

            TodoI cat = await _context.Todos.FirstOrDefaultAsync(x => x.Id == idTodo);

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

        public async Task<ServiceResponse<List<TodoI>>> GetAllTodos()
        {
            var response = new ServiceResponse<List<TodoI>>
            {
                Data = await _context.Todos.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<TodoI>> GetTodoById(int id)
        {
            var response = new ServiceResponse<TodoI>();
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

        public async Task<ServiceResponse<TodoI>> UpdateTodo(TodoI todo)
        {
            var response = new ServiceResponse<TodoI>();
            if (todo == null)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
                return response;

            }

            TodoI t = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);

            if (t == null)
            {
                response.Success = false;
                response.Message = "No se encontro esta tarea";
                return response;
            }

            try
            {
                //Agregamos los parametros que se actualizaran antes de hacer la 
                //solicitud en la base de datos
                t.Terminado = todo.Terminado;
                t.Descripcion = todo.Descripcion;
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
