using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DataAccess.Repositories;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name ="GetTodo")]
        public IActionResult GetById(long id)
        {
            var todoItem = _repository.Find(id);
            if(todoItem == null)
            {
                return NotFound();
            }
            return new ObjectResult(todoItem);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            _repository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);

        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]TodoItem item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _repository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Name = item.Name;
            todo.IsComplete = item.IsComplete;

            _repository.Update(todo);
            return NoContent();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _repository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _repository.Remove(id);
            return new NoContentResult();
        }
    }
}
