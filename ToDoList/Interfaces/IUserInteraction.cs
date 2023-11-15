using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interfaces
{
    public interface IUserInteraction
    {
        public int GetUserChoice();
        public string GetUserInput();
        public void DisplayToUser(string s);
    }
}
