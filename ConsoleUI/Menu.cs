using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Menu
    {
        public static void MainMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            while (true)
            {
                Console.Clear();
                DrawMenu();
                var choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            UserMenu.Questionaire(userRepository, surveyRepository, usr);
                            Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            AdminMenu(userRepository, surveyRepository, usr);
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            WriteCentered("Press ENTER to exit program.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        private static void DrawMenu()
        {
            List<string> menuRows = new();
            menuRows.Add("╔═════════════════════╗");
            menuRows.Add("║     SCB Surveys     ║");
            menuRows.Add("╠═════════════════════╣");
            menuRows.Add("║  1 - Take survey    ║");
            menuRows.Add("║  2 - Admin login    ║");
            menuRows.Add("║                     ║");
            menuRows.Add("║  ESC - Quit         ║");
            menuRows.Add("╚═════════════════════╝");
            foreach (string row in menuRows)
            {
                WriteCentered(row);
            }
        }
        public static void AdminMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            // ConfirmAdmin(); <-- kolla utifall riktig admin här med lösen osv.
            bool adminMenuLoop = true;
            while (adminMenuLoop == true)
            {
                Console.Clear();
                DrawAdminMenu();
                var choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            // Create Survey
                            Survey newSurvey = Admin.BuildSurvey();
                            surveyRepository.AddSurvey(newSurvey);
                            surveyRepository.SaveSurvey(newSurvey);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            // List all surveys
                            Admin.ListAllSurveys(surveyRepository);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            // Distribute Survey
                            Admin.DistributeSurvey(userRepository, surveyRepository, usr);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            // List distributions
                            Admin.ListDistributions(usr);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            // List users
                            Admin.ListAllUsers(userRepository);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.D6:
                        {
                            Console.Clear();
                            // Add user
                            Admin.AddUser(userRepository);

                            ReturnToAdminMenu();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            WriteCentered("Press ENTER to return to main menu.");
                            Console.ReadLine();
                            adminMenuLoop = false;
                            break;
                        }
                }
            }
        }


        private static void DrawAdminMenu()
        {
            List<string> menuRows = new();
            menuRows.Add("╔════════════════════════════╗");
            menuRows.Add("║       Admin commands       ║");
            menuRows.Add("╠════════════════════════════╣");
            menuRows.Add("║  1 - Create a survey       ║");
            menuRows.Add("║  2 - List all surveys      ║");
            menuRows.Add("║  3 - Distribute survey     ║");
            menuRows.Add("║  4 - List distributions    ║");
            menuRows.Add("╠════════════════════════════╣");
            menuRows.Add("║  5 - List all users        ║");
            menuRows.Add("║  6 - Add a new user        ║");
            menuRows.Add("╠════════════════════════════╣");
            menuRows.Add("║  ESC - Return to main menu ║");
            menuRows.Add("╚════════════════════════════╝");
            foreach (string row in menuRows)
            {
                WriteCentered(row);
            }

        }
        public static void WelcomeScreen()
        {
            WriteCentered("███████╗ ██████╗██████╗ ");
            WriteCentered("██╔════╝██╔════╝██╔══██╗");
            WriteCentered("███████╗██║     ██████╔╝");
            WriteCentered("╚════██║██║     ██╔══██╗");
            WriteCentered("███████║╚██████╗██████╔╝");
            WriteCentered("╚══════╝ ╚═════╝╚═════╝ ");
            WriteCentered("The Swedish statistical CentralBureau\n\n");
            WriteCentered("Press ENTER to start.");
        }

        private static void ReturnToAdminMenu()
        {
            WriteCentered("Press ENTER to return to admin menu...");
            Console.ReadLine();
        }
        public static void WriteCentered(string s)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
        }


    }
}



//         public void MyMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
//         {
//             List<string> mymenu = new();
//             mymenu.Add(@"
// ███████╗ ██████╗██████╗ 
// ██╔════╝██╔════╝██╔══██╗
// ███████╗██║     ██████╔╝
// ╚════██║██║     ██╔══██╗
// ███████║╚██████╗██████╔╝
// ╚══════╝ ╚═════╝╚═════╝                        
// ");
//             mymenu.Add("[A] Admin");
//             mymenu.Add("[B] User");
//             mymenu.Add("[X] Log out");

//             while (true)
//             {

//                 Console.Clear();
//                 Console.ForegroundColor = ConsoleColor.DarkRed;
//                 for (int i = 0; i < mymenu.Count; i++)
//                 {
//                     Console.WriteLine(mymenu[i]);
//                 }

//                 string choice = Console.ReadKey(true).Key.ToString().ToLower();
//                 Login login = new();

//                 if (choice == "a")
//                 {
//                     AdminLogin(userRepository, surveyRepository, usr);
//                 }

//                 else if (choice == "b")
//                 {
//                     UserMenu(userRepository, surveyRepository, usr);
//                 }
//                 else if (choice == "x")
//                 {
//                     Environment.Exit(0);
//                 }
//                 else
//                 {
//                     Console.WriteLine("\nMake a new menu choice please.\nPress any key to continue.");
//                     Console.ReadLine();
//                 }
//                 Console.ResetColor();
//             }
//         }

//         public static void UserMenu(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
//         {
//             System.Console.WriteLine("Enter the questionaire code: ");
//             string code = Console.ReadLine();

//             foreach (User_Survey US in usr.GetUser_Surveys())
//             {
//                 if (US.FindMatch(code) != null)
//                 {
//                     AnswerSurvey(US.FindMatch(code));
//                     US.IsSubmitted = true;
//                     Console.WriteLine("Thanks for taking the survey!");
//                     PrintData.Print(US.FindMatch(code), usr);
//                     Console.ReadLine();
//                 }
//             }
//         }

//         public static bool AdminMenu(SurveyRepository surveyRepository, UserRepository userRepository, User_Survey_Repository usr)
//         {
//             bool adminRun = true;
//             Menu men = new();
//             while (adminRun == true)
//             {
//                 Console.Clear();
//                 System.Console.WriteLine(@"
//     ███████ ███████  ██████ ██████  ███████ ████████      █████  ██████  ███    ███ ██ ███    ██     ███    ███ ███████ ███    ██ ██    ██ 
//     ██      ██      ██      ██   ██ ██         ██        ██   ██ ██   ██ ████  ████ ██ ████   ██     ████  ████ ██      ████   ██ ██    ██ 
//     ███████ █████   ██      ██████  █████      ██        ███████ ██   ██ ██ ████ ██ ██ ██ ██  ██     ██ ████ ██ █████   ██ ██  ██ ██    ██ 
//          ██ ██      ██      ██   ██ ██         ██        ██   ██ ██   ██ ██  ██  ██ ██ ██  ██ ██     ██  ██  ██ ██      ██  ██ ██ ██    ██ 
//     ███████ ███████  ██████ ██   ██ ███████    ██        ██   ██ ██████  ██      ██ ██ ██   ████     ██      ██ ███████ ██   ████  ██████  


// ");
//                 System.Console.WriteLine("Welcome to the super secret admin menu");
//                 System.Console.WriteLine("[A] Add a user");
//                 System.Console.WriteLine("[C] Create a survey");
//                 System.Console.WriteLine("[L] List all surveys");
//                 System.Console.WriteLine("[T] Test a survey");
//                 Console.WriteLine("[D] Distribute survey");
//                 Console.WriteLine("[S] Show all distributions");
//                 Console.WriteLine("[U] List all users");
//                 System.Console.WriteLine("[X] Return to main menu");
//                 string adminChoice = Console.ReadKey(true).Key.ToString().ToLower();
//                 switch (adminChoice)
//                 {
//                     case "a":
//                         {   // Lägg till ny användare
//                             AddUser(userRepository);
//                             System.Console.WriteLine("Press ENTER to return to menu...");
//                             Console.ReadLine();
//                             break;
//                         }
//                     case "c":
//                         {   // Skapa survey
//                             surveyRepository.AddSurvey(Admin.BuildSurvey());
//                             break;
//                         }
//                     case "l":
//                         {   // Lista alla surveys
//                             Admin.ListAllSurveys(surveyRepository);
//                             Console.ReadLine();
//                             break;
//                         }
//                     case "t":
//                         {   // Testkör en survey
//                             Console.WriteLine("Choose a survey to test");
//                             Admin.ListAllSurveys(surveyRepository);
//                             Console.ReadLine();
//                             break;
//                         }
//                     case "d":
//                         {
//                             Console.WriteLine("Which survey do you want to distribute?");
//                             int counter = 1;
//                             foreach (Survey survey in surveyRepository.GetAllSurveys())
//                             {
//                                 Console.Write(counter);
//                                 Console.WriteLine(survey.Title);
//                                 counter++;
//                             }
//                             int index = Convert.ToInt32(Console.ReadLine());
//                             Console.WriteLine("How would you like to distribute it?");
//                             Console.WriteLine("1. By age");
//                             Console.WriteLine("2. CoinFlip");
//                             Console.WriteLine("3. To everyone");

//                             string distributeChoice = Console.ReadLine();
//                             if (distributeChoice == "1")
//                             {
//                                 Console.WriteLine("Minumum age: ");
//                                 int minAge = Convert.ToInt32(Console.ReadLine());
//                                 Console.WriteLine("Maximum age: ");
//                                 int maxAge = Convert.ToInt32(Console.ReadLine());
//                                 Distributor.DistributeByAge(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
//                             }
//                             else if (distributeChoice == "2")
//                             {
//                                 Distributor.CoinFlipDistribution(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
//                             }
//                             else if (distributeChoice == "3")
//                             {
//                                 Distributor.DistributeToAll(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
//                             }
//                             Console.ReadLine();
//                             break;
//                         }

//                     case "s":
//                         {
//                             foreach (User_Survey us in usr.GetUser_Surveys())
//                             {
//                                 Console.WriteLine(us.GetUserSsn() + " | " + us.GetUserCode() + " | " + us.GetSurvey().Title);
//                             }
//                             Console.ReadLine();
//                             break;
//                         }

//                     case "u":
//                         {
//                             Dictionary<string, UserRoles> users = userRepository.ListUsers();
//                             foreach (KeyValuePair<string, UserRoles> u in users)
//                             {
//                                 Console.WriteLine(u.Key + " " + u.Value.ToString());
//                             }
//                             Console.ReadLine();
//                             break;
//                         }
//                     case "x":
//                         {
//                             return true;
//                         }
//                 }
//             }
//             return false;
//         }

//         private static void AddUser(UserRepository userRepository)
//         {
//             string roleAdd = "";
//             string ssnAdd = "";
//             System.Console.WriteLine("What role of user do you wish to add?");
//             System.Console.WriteLine("1. Admin");
//             System.Console.WriteLine("2. Participant");
//             roleAdd = Console.ReadLine();
//             while (roleAdd != "1" && roleAdd != "2")
//             {
//                 System.Console.WriteLine("Enter a valid role");
//                 roleAdd = Console.ReadLine();
//             }
//             System.Console.WriteLine("Enter the SSN of the user (example : 199001015555");
//             ssnAdd = Console.ReadLine();
//             while (ssnAdd.Length != 12)
//             {
//                 System.Console.WriteLine("Invalid SSN, 12 digits.");
//                 ssnAdd = Console.ReadLine();
//                 if (IsDigitsOnly(ssnAdd) == false)
//                 {
//                     ssnAdd = "";
//                 }
//             }
//             foreach (User u in userRepository.GetUsers())
//             {
//                 if (ssnAdd == u.Ssn)
//                 {
//                     System.Console.WriteLine("A user with this SSN already exists, aborting...");
//                     roleAdd = "0";
//                 }
//             }
//             if (roleAdd == "1")
//             {
//                 User addUser = new User(ssnAdd, UserRoles.Admin);
//                 userRepository.AddNewUser(addUser);
//                 System.Console.WriteLine("Added an Admin with the SSN: " + ssnAdd);
//             }
//             else if (roleAdd == "2")
//             {
//                 User addUser = new User(ssnAdd, UserRoles.Participant);
//                 userRepository.AddNewUser(addUser);
//                 System.Console.WriteLine("Added a Participant with the SSN: " + ssnAdd);
//             }
//         }

//         public void AdminLogin(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
//         {
//             while (true)
//             {
//                 Console.Clear();

//                 System.Console.WriteLine("Submit SSN: ");
//                 string ssnInput = Console.ReadLine();
//                 foreach (User u in userRepository.GetUsers())
//                 {
//                     if (ssnInput == u.Ssn && u.GetUserRole() == UserRoles.Admin)
//                     {
//                         int passAttempt = 0;
//                         string passwordInput = "";
//                         string password = "admin";
//                         while (passwordInput != password && passAttempt <= 2)
//                         {
//                             System.Console.WriteLine("Enter password (5 characters): ");
//                             passwordInput = Console.ReadLine();
//                             passAttempt++;
//                             if (passwordInput != password && passAttempt <= 2)
//                             {
//                                 System.Console.WriteLine("Wrong password, try again");
//                             }
//                         }
//                         if (passAttempt >= 3)
//                         {
//                             System.Console.WriteLine("Too many attempts, you're a big fat phony");
//                             Console.ReadLine();
//                             return;
//                         }
//                         bool goBack = AdminMenu(surveyRepository, userRepository, usr);
//                         if (goBack == true) return;
//                     }
//                 }
//             }
//         }


//         public static void AnswerSurvey(Survey survey)
//         {
//             Console.Clear();
//             Console.WriteLine(survey.Title);
//             Console.WriteLine("");

//             int questionCounter = 0;

//             foreach (Question q in survey.GetQuestions())
//             {
//                 questionCounter++;
//                 Console.WriteLine("Question " + questionCounter);
//                 Console.WriteLine(q.Title);

//                 _1_to_10 _1_to_10_question = q as _1_to_10;
//                 MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;
//                 YesOrNoQuestion ynq = q as YesOrNoQuestion;
//                 FreetextQuestion ftq = q as FreetextQuestion;

//                 if (_1_to_10_question != null)
//                 {
//                     Console.WriteLine("1 means: " + _1_to_10_question.Value1 + " 10 means: " + _1_to_10_question.Value10);
//                     _1_to_10_question.SetAnswer(Convert.ToInt32(Console.ReadLine()));
//                 }

//                 else if (mcq != null)
//                 {
//                     Console.WriteLine("Options: ");
//                     foreach (string option in mcq.GetOptions())
//                     {
//                         Console.WriteLine(option);
//                     }
//                     List<int> answers = new();
//                     while (true)
//                     {
//                         Console.WriteLine("Enter a number and press enter to add more answers. Press enter without writing anything to stop adding answers.");
//                         string input = Console.ReadLine();
//                         if (input == "") break;

//                         if (Int32.TryParse(input, out int answerInt) == true)
//                         {
//                             answers.Add(answerInt);
//                         }
//                         else Console.WriteLine("You must enter a digit");
//                     }
//                     mcq.SetAnswer(answers);
//                 }
//                 else if (ynq != null)
//                 {
//                     Console.WriteLine("Y/N ?");
//                     string answer = Console.ReadLine();
//                     if (answer.ToLower() == "y")
//                     {
//                         ynq.SetAnswer(true);
//                     }
//                     else ynq.SetAnswer(false);
//                 }
//                 else if (ftq != null)
//                 {
//                     string answer = Console.ReadLine();
//                     ftq.SetAnswer(answer);
//                 }
//             }
//             txtfileDataManager.SaveResult(survey);
//         }
//         static bool IsDigitsOnly(string str)
//         {
//             foreach (char c in str)
//             {
//                 if (c < '0' || c > '9')
//                     return false;
//             }

//             return true;
//         }
