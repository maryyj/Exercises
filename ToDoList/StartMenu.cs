using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interfaces;

namespace ToDoList
{
    public class StartMenu
    {
        private readonly ITodoListStorage _todoListStorage;
        private readonly TodoList todo;

        enum MenuList
        {
            Add_task = 1,
            Delete_task = 2,
            Mark_As_Completed = 3,
            View = 4,
            Quit = 9
        }
        enum ViewMenu
        {
            View_all_tasks = 1,
            View_completed_tasks = 2,
            View_not_completed_tasks = 3,
            Return = 9
        }
        public StartMenu(ITodoListStorage todoListStorage)
        {
            _todoListStorage = todoListStorage;
            todo = new TodoList(_todoListStorage);
        }
        public void Run()
        {
            bool runProgram = true;

            while (runProgram)
            {
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome!");
                Console.WriteLine("Choose an option:");
                Console.ResetColor();
                foreach (int i in Enum.GetValues(typeof(MenuList)))
                {
                    Console.WriteLine($"{i}.{Enum.GetName(typeof(MenuList), i).Replace('_', ' ')}");
                }

                int nr;
                MenuList menu = (MenuList)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {

                    menu = (MenuList)nr;
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }


                var idString = string.Empty;
                switch (menu)
                {

                    case MenuList.Add_task:
                        Console.WriteLine("Add a title: ");
                        var title = Console.ReadLine();
                        Console.WriteLine("Add a description: ");
                        var description = Console.ReadLine();
                        if (title != null && description != null)
                        {
                            todo.Add(title, description);
                            Console.WriteLine("Task added. Press any key to continue...");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    case MenuList.Delete_task:
                        Console.WriteLine("Input the id of the task you want to delete: ");
                        idString = Console.ReadLine();

                        if (System.Guid.TryParse(idString, out Guid id))
                        {
                            bool isDeleted = todo.Delete(id);
                            if (isDeleted)
                                Console.WriteLine("Task deleted");
                            else
                                Console.WriteLine("Task not found/could not be deleted");
                        }
                        else
                            Console.WriteLine("Invalid Id format, try again!");

                        break;
                    case MenuList.Mark_As_Completed:
                        Console.WriteLine("Input Id of task you want to complete: ");
                        idString = Console.ReadLine();
                        if (System.Guid.TryParse(idString, out Guid taskId))
                        {
                            todo.MarkAsComplete(taskId);
                            Console.WriteLine("Task is Complete. Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine("Invalid Id format, try again!");
                        break;
                    case MenuList.View:
                        View();
                        break;
                    case MenuList.Quit:
                        runProgram = false;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for using our app!");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        Environment.Exit(0);

                        break;
                }
            }
        }

        public void View()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose an option: ");
            Console.ResetColor();
            foreach (int i in Enum.GetValues(typeof(ViewMenu)))
            {
                Console.WriteLine($"{i}.{Enum.GetName(typeof(ViewMenu), i).Replace('_', ' ')}");
            }
            ViewMenu menu = (ViewMenu)99;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int nr))
            {

                menu = (ViewMenu)nr;
            }
            else
            {
                Console.WriteLine("Fel inmatning");
            }


            var idString = string.Empty;
            switch (menu)
            {

                case ViewMenu.View_all_tasks:
                    var allTask = todo.TodoItems;
                    todo.ShowTasks(allTask);
                    break;
                case ViewMenu.View_completed_tasks:
                    var completeTaskList = todo.GetAllCompletedTasks();
                    todo.ShowTasks(completeTaskList);
                    break;
                case ViewMenu.View_not_completed_tasks:
                    var notCompleteTaskList = todo.GetAllNotCompletedTasks();
                    todo.ShowTasks(notCompleteTaskList);
                    break;
                case ViewMenu.Return:

                    break;
            }
        }
    }
}
