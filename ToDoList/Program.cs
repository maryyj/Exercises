using ToDoList.Interfaces;

namespace ToDoList
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            ITodoListStorage todoListStorage = new TodoListStorage();
            StartMenu startmenu = new StartMenu(todoListStorage);
            startmenu.Run();
            
        }
    }
}
