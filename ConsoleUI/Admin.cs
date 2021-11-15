using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Admin
    {
        public static void CreateSurvey()
        {
            string surveyTitle;
            List<string> questionList = new();
            string question;
            bool questionRun = true;
            System.Console.WriteLine("- Create survey -");
            System.Console.WriteLine("Enter title of questionaire: ");
            surveyTitle = Console.ReadLine();
            System.Console.WriteLine("To stop adding questions, leave the field empty");
            while (questionRun == true)
            {
                question = "";
                System.Console.WriteLine("Enter a question : ");
                question = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(question))
                {
                    System.Console.WriteLine("Questionaire finished");
                    questionRun = false;
                }
                else 
                {
                    questionList.Add(question);
                }
            }
            return;
        }

    }
}

//     private UserList _userlist;
//     public Admin(UserList userlist)
//     {
//         this._userlist=userlist;
//     }


//      private void NewAdmin()
//      {
//          while(true)
//         {

//           System.Console.WriteLine("Submit SSN: ");
//             string input = Console.ReadLine();

//            if (input.Length == 12)
//             {
//                 User user = new( input, UserRoles.Admin);
//                 Console.WriteLine("Successfully logged in.");
//                 Console.ReadLine();
//             }
//             else
//             {
//                 Console.WriteLine($"Incorrect length of personal number, you entered {input.Length} digits, try again please.");
//                 Console.ReadLine();
//             }


//         }

//  }