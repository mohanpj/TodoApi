using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
            // Add(new TodoItem { Name = "Item 1" });
        }

        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        public TodoItem Find(long id)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.TodoItems.First(t => t.Id == id);
            _context.TodoItems.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
            _context.SaveChanges();
        }
    }
}
