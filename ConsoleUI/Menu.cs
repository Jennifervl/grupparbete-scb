using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Menu
    {
        public void MyMenu(UserList userList, SurveyLibrary surveyLibrary)
        {
            List<string> mymenu = new();
            mymenu.Add(@"
 ██████╗ ██╗   ██╗███████╗███████╗████████╗██╗ ██████╗ ███╗   ██╗███████╗
██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝
██║   ██║██║   ██║█████╗  ███████╗   ██║   ██║██║   ██║██╔██╗ ██║███████╗
██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║
╚██████╔╝╚██████╔╝███████╗███████║   ██║   ██║╚██████╔╝██║ ╚████║███████║
 ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════                                                                                                   
");
            mymenu.Add("[A] Admin");
            mymenu.Add("[B] User");
            mymenu.Add("[X] Log out");

            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int i = 0; i < mymenu.Count; i++)
                {
                    Console.WriteLine(mymenu[i]);
                }

                string choice = Console.ReadKey(true).Key.ToString().ToLower();
                Login login = new();

                if (choice == "a")
                {
                    AdminLogin(userList, surveyLibrary);
                }

                else if (choice == "b")
                {
                    UserMenu(userList, surveyLibrary);
                }
                else if (choice == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nMake a new menu choice please.\nPress any key to continue.");
                    Console.ReadLine();
                }
                Console.ResetColor();
            }

        }

        public static void UserMenu(UserList userList, SurveyLibrary surveyLibrary)
        {
            System.Console.WriteLine("Enter the questionaire code: ");
            string code = Console.ReadLine();

            foreach (User user in userList.GetUsers())
            {
                foreach (User_Survey US in user.GetUserSurveys())
                {
                    if (US.FindMatch(code) != null)
                    {
                        AnswerSurvey(US.FindMatch(code));
                        Console.WriteLine("Thanks for taking the survey!");

                    }
                }
            }
        }

        public static bool AdminMenu(SurveyLibrary surveyLibrary, UserList userList)
        {
            bool adminRun = true;
            Menu men = new();
            while (adminRun == true)
            {
                Console.Clear();
                System.Console.WriteLine(@"
    ███████ ███████  ██████ ██████  ███████ ████████      █████  ██████  ███    ███ ██ ███    ██     ███    ███ ███████ ███    ██ ██    ██ 
    ██      ██      ██      ██   ██ ██         ██        ██   ██ ██   ██ ████  ████ ██ ████   ██     ████  ████ ██      ████   ██ ██    ██ 
    ███████ █████   ██      ██████  █████      ██        ███████ ██   ██ ██ ████ ██ ██ ██ ██  ██     ██ ████ ██ █████   ██ ██  ██ ██    ██ 
         ██ ██      ██      ██   ██ ██         ██        ██   ██ ██   ██ ██  ██  ██ ██ ██  ██ ██     ██  ██  ██ ██      ██  ██ ██ ██    ██ 
    ███████ ███████  ██████ ██   ██ ███████    ██        ██   ██ ██████  ██      ██ ██ ██   ████     ██      ██ ███████ ██   ████  ██████  
                                                                                                                                           
                                                                                                                                           
");
                System.Console.WriteLine("Welcome to the super secret admin menu");
                System.Console.WriteLine("[A] Create a survey");
                System.Console.WriteLine("[L] List all surveys");
                System.Console.WriteLine("[T] Test a survey");
                Console.WriteLine("[D] Distribute survey");
                System.Console.WriteLine("[X] Return to main menu");
                string adminChoice = Console.ReadKey(true).Key.ToString().ToLower();
                switch (adminChoice)
                {
                    case "a":
                        {   // Skapa survey
                            surveyLibrary.AddSurvey(Admin.BuildSurvey());
                            break;
                        }
                    case "l":
                        {   // Lista alla surveys
                            Admin.ListAllSurveys(surveyLibrary);
                            Console.ReadLine();
                            break;
                        }
                    case "t":
                        {   // Testkör en survey
                            Console.ReadLine();
                            break;
                        }
                    case "d":
                        {
                            Console.WriteLine("Which survey do you want to distribute?");
                            int counter = 1;
                            foreach (Survey survey in surveyLibrary.GetAllSurveys())
                            {
                                Console.Write(counter);
                                Console.WriteLine(survey.Title);
                                counter++;
                            }
                            int index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How would you like to distribute it?");
                            Console.WriteLine("1. By age");
                            Console.WriteLine("2. CoinFlip");
                            Console.WriteLine("3. To everyone");

                            string distributeChoice = Console.ReadLine();
                            if (distributeChoice == "1")
                            {
                                Console.WriteLine("Minumum age: ");
                                int minAge = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Maximum age: ");
                                int maxAge = Convert.ToInt32(Console.ReadLine());
                                Distributor.DistributeByAge(surveyLibrary.GetSurveyAtIndex(index), userList);
                            }
                            else if (distributeChoice == "2")
                            {
                                Distributor.CoinFlipDistribution(surveyLibrary.GetSurveyAtIndex(index), userList);
                            }
                            else if (distributeChoice == "3")
                            {
                                Distributor.DistributeToAll(surveyLibrary.GetSurveyAtIndex(index), userList);
                            }
                            Console.ReadLine();


                            break;
                        }
                    case "x":
                        {
                            return true;
                        }
                }
            }
            return false;
        }
        public void AdminLogin(UserList userList, SurveyLibrary surveyLibrary)
        {
            while (true)
            {
                Console.Clear();

                System.Console.WriteLine("Submit SSN: ");
                string ssnInput = Console.ReadLine();
                foreach (User u in userList.GetUsers())
                {
                    if (ssnInput == u.Ssn && u.userRoles == UserRoles.Admin)
                    {
                        int passAttempt = 0;
                        string passwordInput = "";
                        string password = "admin";
                        while (passwordInput != password && passAttempt <= 2)
                        {
                            System.Console.WriteLine("Enter password (5 characters): ");
                            passwordInput = Console.ReadLine();
                            passAttempt++;
                            if (passwordInput != password && passAttempt <= 2)
                            {
                                System.Console.WriteLine("Wrong password, try again");
                            }
                        }
                        if (passAttempt >= 3)
                        {
                            System.Console.WriteLine("Too many attempts, you're a big fat phony");
                            Console.ReadLine();
                            return;
                        }
                        bool goBack = AdminMenu(surveyLibrary, userList);
                        if (goBack == true) return;
                    }
                }
            }
        }


        public static void AnswerSurvey(Survey survey)
        {
            Console.Clear();
            Console.WriteLine(survey.Title);
            Console.WriteLine("");

            int questionCounter = 0;

            foreach (Question q in survey.GetQuestions())
            {
                questionCounter++;
                Console.WriteLine("Question " + questionCounter);
                Console.WriteLine(q.Title);

                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;
                YesOrNoQuestion ynq = q as YesOrNoQuestion;
                FreetextQuestion ftq = q as FreetextQuestion;

                if (_1_to_10_question != null)
                {
                    Console.WriteLine("1 means: " + _1_to_10_question.Value1 + " 10 means: " + _1_to_10_question.Value10);
                    _1_to_10_question.SetAnswer(Convert.ToInt32(Console.ReadLine()));
                }

                else if (mcq != null)
                {
                    Console.WriteLine("Options: ");
                    foreach (string option in mcq.GetOptions())
                    {
                        Console.WriteLine(option);
                    }
                    List<int> answers = new();
                    while (true)
                    {
                        Console.WriteLine("Enter a number and press enter to add more answers. Press enter without writing anything to stop adding answers.");
                        string input = Console.ReadLine();
                        if (input == "") break;

                        if (Int32.TryParse(input, out int answerInt) == true)
                        {
                            answers.Add(answerInt);
                        }
                        else Console.WriteLine("You must enter a digit");
                    }
                    mcq.SetAnswer(answers);
                }
                else if (ynq != null)
                {
                    Console.WriteLine("Y/N ?");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        ynq.SetAnswer(true);
                    }
                    else ynq.SetAnswer(false);
                }
                else if (ftq != null)
                {
                    string answer = Console.ReadLine();
                    ftq.SetAnswer(answer);
                }
            }
            txtfileDataManager.SaveResult(survey);
        }
    }
}