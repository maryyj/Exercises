using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interfaces
{
    public interface ITodoListStorage
    {
        bool Save(TodoItem item);
        List<TodoItem> Load();
    }
    public class TodoListStorage : ITodoListStorage
    {
        private List<TodoItem> todoItems = new List<TodoItem>();

        public bool Save(TodoItem item)
        {
            try
            {
                todoItems.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TodoItem> Load()
        {
            return todoItems;
        }
    }
}
