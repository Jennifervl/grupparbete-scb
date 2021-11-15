using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Admin
    {
        private UserList _userlist;
        public Admin(UserList userlist)
        {
            this._userlist=userlist;
        }


         private void NewAdmin()
         {
             while(true)
            {
              
              System.Console.WriteLine("Submit SSN: ");
                string input = Console.ReadLine();
             
               if (input.Length == 12)
                {
                    User user = new( input, UserRoles.Admin);
                    Console.WriteLine("Successfully logged in.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Incorrect length of personal number, you entered {input.Length} digits, try again please.");
                    Console.ReadLine();
                }
             
             
            }
            
         }
    }
}