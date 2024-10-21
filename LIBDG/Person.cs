using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public void Login()
        {
            Console.WriteLine($"{Name} has logged in.");
            Console.WriteLine("TBB");
        }
        //chứa các thuộc tính và phương thức chung giữa Member và Librarian.
        
    }
}
