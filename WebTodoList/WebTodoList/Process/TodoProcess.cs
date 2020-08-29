
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTodoList.Models;

namespace WebTodoList.Process
{
    public class TodoProcess: ITodoProcess
    {
        private readonly TodoContext _context;

        public TodoProcess(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetList()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _context.TodoLists.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Todo todo)
        {
            if (await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == todo.Id) is {} ex)
            {
                ex.Name = todo.Name;
                ex.Content = todo.Content;

                _context.Entry(ex).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            if (await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id) is {} ex)
            {
                _context.Entry(ex).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Todo> Create(Todo todo)
        {
            await _context.TodoLists.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}