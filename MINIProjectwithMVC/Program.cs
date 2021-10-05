using DailyBL;
using DailyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINIProjectwithMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            UserBL blObj = new UserBL();
            var result = blObj.GetAllUser();
            foreach (var u in result)
            {
                Console.WriteLine(u.FullName + "|" + u.Email );
            }

            Console.WriteLine("Enter the product name to fetch products");
            string uName = Console.ReadLine();
            var user = blObj.GetUserByName(uName);
            foreach (var u in user)
            {
                Console.WriteLine(u.FullName + "|" + u.Email);
            }
            Console.WriteLine("----------------------------------------------------");


          


            Console.WriteLine("Enter User name ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter email ");
            string Email = Console.ReadLine();
            UserDTO DeptObj = new UserDTO()
            {
                FullName = Name,
                Email = Email
            };
            int retVal = blObj.AddNewUser(DeptObj);
            if (retVal == 1)
            {
                Console.WriteLine("Department has been added successfully");
            }
            else if (retVal == -1)
            {
                Console.WriteLine("Department name cannot be empty");
            }
            else if (retVal == -2)
            {
                Console.WriteLine("Department group name cannot be empty");
            }
            else if (retVal == -3)
            {
                Console.WriteLine("Department date cannot be empty");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
