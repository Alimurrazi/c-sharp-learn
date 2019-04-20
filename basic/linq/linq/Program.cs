using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> listofusers = new List<User>()
            {
                new User(){Name="john doe",age=42},
                new User(){Name="jane doe",age=34},
                new User(){Name="joe doe",age=8},
                new User(){Name="jake doe",age=15},
            };

            var filter = listofusers.Where(user => user.Name.StartsWith("j") && user.age < 20);
            foreach(User user in filter)
            {
                Console.WriteLine(user.Name + " " + user.age);
            }

            filter = listofusers.OrderBy(user=>user.age);
            foreach (User user in filter)
            {
                Console.WriteLine(user.Name + " " + user.age);
            }

            Console.ReadLine();
        }
    }
    class User
    {
        public string Name { get; set; }
        public int age { get; set; }
    }
}
