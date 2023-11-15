using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interfaces;

namespace ToDoList
{
    public class TodoList
    {
        private readonly ITodoListStorage _todoListStorage;
        public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public TodoList(ITodoListStorage todoListStorage)
        {
            _todoListStorage = todoListStorage;
        }

        public TodoItem Add(string title, string description)
        {
            var task = new TodoItem()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                IsCompleted = false
            };

            TodoItems.Add(task);
            _todoListStorage.Save(task);

            return task;
        }
        public void ShowTasks(List<TodoItem> taskList)
        {
            Console.WriteLine("Id \t\t\t\t\t\t Title \t\t Description \t\t\t\t\t IsCompleted");
            if (TodoItems != null)
            {

                foreach (var task in taskList)
                {
                    Console.WriteLine($"{task.Id} \t {task.Title} \t\t {task.Description} \t\t\t " +
                        $"{(task.IsCompleted == true ? "Yes" : "No")}\r");
                }
            }
            _todoListStorage.Load();
        }
        public List<TodoItem> GetAllCompletedTasks()
        {
            var completedTaskList = TodoItems.Where(x => x.IsCompleted).ToList();

            return completedTaskList;
        }
        public List<TodoItem> GetAllNotCompletedTasks()
        {
            var notCompletedTaskList = TodoItems.Where(x => x.IsCompleted == false).ToList();

            return notCompletedTaskList;
        }
        public TodoItem MarkAsComplete(Guid taskId)
        {
            var task = TodoItems.FirstOrDefault(x => x.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
            }

            return task;
        }
        public TodoItem MarkAsNotComplete(Guid taskId)
        {
            var task = TodoItems.FirstOrDefault(x => x.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = false;
            }

            return task;
        }
        public bool Delete(Guid taskId)
        {
            var task = TodoItems.FirstOrDefault(x => x.Id == taskId);
            if (task != null)
            {
                TodoItems.Remove(task);
                return true;
            }
            else
                return false;
        }
    }
}
