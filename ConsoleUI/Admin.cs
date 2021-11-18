using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Admin
    {
        public static void ListAllSurveys(SurveyRepository surveyRepository)
        {

            foreach (Survey s in surveyRepository.GetAllSurveys())
            {
                Menu.WriteCentered(s.Title);
            }
        }
        public static void TestSurvey(Survey testSurvey)
        {
            Menu.WriteCentered(testSurvey.Title);
            IList<Question> questions = testSurvey.GetQuestions();
            foreach (Question q in questions)
            {
                Menu.WriteCentered(q.Title);
            }
        }

        public static Survey BuildSurvey()
        {
            Menu.WriteCentered("Enter the title of the survey");
            Console.CursorLeft = (Console.WindowWidth / 2) - 5;
            string title = Console.ReadLine();
            Survey survey1 = new(title);
            while (true)
            {
                Menu.WriteCentered("What type of question do you want to add?");
                Menu.WriteCentered("1. 1-to-10-question");
                Menu.WriteCentered("2. Freetext question");
                Menu.WriteCentered("3. Yes or no question");
                Menu.WriteCentered("4. Multiple choise question");
                Menu.WriteCentered("5. No more questions");
                Console.CursorLeft = (Console.WindowWidth / 2);
                string input = Console.ReadLine();
                if (input == "5") break;

                else
                {
                    Menu.WriteCentered("Enter the title of the question");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                    string qtitle = Console.ReadLine();

                    if (input == "1")
                    {
                        Menu.WriteCentered("Enter the label of number 1");
                        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                        string label1 = Console.ReadLine();
                        Menu.WriteCentered("Enter the label of value 10");
                        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                        string label10 = Console.ReadLine();
                        _1_to_10 _1_To_10question = new(qtitle, label1, label10);
                        survey1.AddQuestion(_1_To_10question);
                    }

                    else if (input == "2")
                    {
                        FreetextQuestion freetextQuestion = new(qtitle);
                        survey1.AddQuestion(freetextQuestion);
                    }

                    else if (input == "3")
                    {
                        YesOrNoQuestion yesOrNo = new(qtitle);
                        survey1.AddQuestion(yesOrNo);
                    }
                    else if (input == "4")
                    {
                        List<string> options = new();
                        while (true)
                        {
                            Menu.WriteCentered("Enter an option");
                            Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                            options.Add(Console.ReadLine());
                            Menu.WriteCentered("Add another option? (y/n)");
                            Console.CursorLeft = (Console.WindowWidth / 2);
                            string choise = Console.ReadLine();
                            if (choise.ToLower() == "n")
                            {
                                break;
                            }
                        }
                        MultipleChoiseQuestion mcq = new(qtitle, options);
                        survey1.AddQuestion(mcq);
                    }
                }
            }
            return survey1;


        }
        public static void DistributeSurvey(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            Menu.WriteCentered("Which survey do you want to distribute?");
            int counter = 1;
            foreach (Survey survey in surveyRepository.GetAllSurveys())
            {
                Console.Write(counter);
                Menu.WriteCentered(survey.Title);
                counter++;
            }
            Console.CursorLeft = (Console.WindowWidth / 2);
            int index = Convert.ToInt32(Console.ReadLine());
            Menu.WriteCentered("How would you like to distribute it?");
            Menu.WriteCentered("1. By age");
            Menu.WriteCentered("2. CoinFlip");
            Menu.WriteCentered("3. To everyone");
            Console.CursorLeft = (Console.WindowWidth / 2);
            string distributeChoice = Console.ReadLine();
            if (distributeChoice == "1")
            {
                Menu.WriteCentered("Minumum age: ");
                Console.CursorLeft = (Console.WindowWidth / 2);
                int minAge = Convert.ToInt32(Console.ReadLine());
                Menu.WriteCentered("Maximum age: ");
                Console.CursorLeft = (Console.WindowWidth / 2);
                int maxAge = Convert.ToInt32(Console.ReadLine());
                Distributor.DistributeByAge(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
            }
            else if (distributeChoice == "2")
            {
                Distributor.CoinFlipDistribution(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
            }
            else if (distributeChoice == "3")
            {
                Distributor.DistributeToAll(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
            }
        }
        public static void ListDistributions(User_Survey_Repository usr)
        {
            foreach (User_Survey us in usr.GetUser_Surveys())
            {
                Menu.WriteCentered(us.GetUserSsn() + " | " + us.GetUserCode() + " | " + us.GetSurvey().Title);
            }
        }

        public static void ListAllUsers(UserRepository userRepository)
        {
            Dictionary<string, UserRoles> users = userRepository.ListUsers();
            foreach (KeyValuePair<string, UserRoles> u in users)
            {
                Menu.WriteCentered(u.Key + " " + u.Value.ToString());
            }
        }
        public static void AddUser(UserRepository userRepository)
        {
            string roleAdd = "";
            string ssnAdd = "";
            string passwordAdd ="";
            Menu.WriteCentered("What role of user do you wish to add?");
            Menu.WriteCentered("1. Admin");
            Menu.WriteCentered("2. Participant");
                        Console.CursorLeft=(Console.WindowWidth/2);
            roleAdd = Console.ReadLine();
            while (roleAdd != "1" && roleAdd != "2")
            {
                Menu.WriteCentered("Enter a valid role");
                            Console.CursorLeft=(Console.WindowWidth/2);
                roleAdd = Console.ReadLine();
            }
            Menu.WriteCentered("Enter the SSN of the user (example : 199001015555");
                        Console.CursorLeft=(Console.WindowWidth/2)-5;
            ssnAdd = Console.ReadLine();
            while (ssnAdd.Length != 12)
            {
                Menu.WriteCentered("Invalid SSN, 12 digits.");
                            Console.CursorLeft=(Console.WindowWidth/2)-5;
                ssnAdd = Console.ReadLine();
                if (IsDigitsOnly(ssnAdd) == false)
                {
                    ssnAdd = "";
                }
            }
            if (roleAdd =="1")
            {
                Menu.WriteCentered("Enter password you wish to use:");
                Console.CursorLeft = (Console.WindowWidth / 2) - 5;
                passwordAdd = Console.ReadLine();
            }
            foreach (User u in userRepository.GetUsers())
            {
                if (ssnAdd == u.Ssn)
                {
                    Menu.WriteCentered("A user with this SSN already exists, aborting...");
                    roleAdd = "0";
                }
            }
            if (roleAdd == "1")
            {
                Admin addAdmin = new Admin(ssnAdd, passwordAdd);                
                userRepository.AddNewUser(addAdmin);
                userRepository.SaveUser(addAdmin);
                Menu.WriteCentered("Added an Admin with the SSN: " + ssnAdd);
            }
            else if (roleAdd == "2")
            {
                Participant addParticipant = new Participant(ssnAdd);
                userRepository.AddNewUser(addParticipant);
                userRepository.SaveUser(addParticipant);
                Menu.WriteCentered("Added a Participant with the SSN: " + ssnAdd);
            }
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
