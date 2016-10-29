using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad_1
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </summary >
        private readonly List<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(List<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new List<TodoItem>();
        }

        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem), "Null reference cannot be added to list.");
            }
            TodoItem id = Get(todoItem.Id);
            if (id == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            else
            {
                throw new DuplicateTodoItemException();
            }
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));
        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> activeList = _inMemoryTodoDatabase.Where(i => i.IsCompleted == false).ToList();
            return activeList;
        }

        public List<TodoItem> GetAll()
        {
            List<TodoItem> descendingOrderList = _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
            return descendingOrderList;
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> completedList = _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
            return completedList;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            List<TodoItem> filteredList = _inMemoryTodoDatabase.Where(i => filterFunction(i)).ToList();
            return filteredList;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item == null)
            {
                return false;
            }
            item.MarkAsCompleted();
            return item.IsCompleted;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public void Update(TodoItem todoItem)
        {
            var index = _inMemoryTodoDatabase.IndexOf(todoItem);
            if (index == -1)
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            else
            {
                TodoItem item = _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoItem.Id));
                item.IsCompleted = todoItem.IsCompleted;
                item.DateCompleted = todoItem.DateCompleted;
                item.DateCreated = todoItem.DateCreated;
                item.Text = todoItem.Text;
            }
        }

    }

}

