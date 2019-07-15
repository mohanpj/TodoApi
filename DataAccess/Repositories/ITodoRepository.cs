using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.DataAccess.Repositories
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(long id);
        void Remove(long id);
        void Update(TodoItem item);
    }
}
