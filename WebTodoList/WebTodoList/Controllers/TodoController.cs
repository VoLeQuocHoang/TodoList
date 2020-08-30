using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTodoList.Models;
using WebTodoList.Process;

namespace WebTodoList.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController: ControllerBase
    {
        private readonly ITodoProcess process;

        public TodoController(ITodoProcess process)
        {
            this.process = process;
        }

        [HttpGet]
        public async Task<List<Todo>> Get()
        {
            return await process.GetList();
        }
        
        [HttpGet]
        [Route("{id}")]
        
        public async Task<Todo> Get(int id)
        {
            return await process.GetTodo(id);
        }

        [HttpPost]
        public async Task<Todo> Create([FromBody] Todo todo)
        {
            return await process.Create(todo);
        }

        [HttpPut]
        public async Task Update([FromBody] Todo todo)
        {
            await process.Update(todo);
        }

        [HttpDelete]
        [Route("{id}")]
        
        public async Task Delete(int id)
        {
            await process.Delete(id);
        }
    }
}