using WebTodoList.Models;
using Microsoft.EntityFrameworkCore;
namespace WebTodoList
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Todo> TodoLists { get; set; }
    }
}