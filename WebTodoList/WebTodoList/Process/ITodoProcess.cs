using System.Collections.Generic;
using System.Threading.Tasks;
using WebTodoList.Models;

namespace WebTodoList.Process
{
    public interface ITodoProcess
    {
        Task<List<Todo>> GetList();
        Task<Todo> GetTodo(int id);
        Task Update(Todo todo);
        Task Delete(int id);
        Task<Todo> Create(Todo todo);
    }
}