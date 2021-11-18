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
                string input = Console.ReadLine();
                if (input == "5") break;

                else
                {
                    Menu.WriteCentered("Enter the title of the question");
                    string qtitle = Console.ReadLine();

                    if (input == "1")
                    {
                        Menu.WriteCentered("Enter the label of number 1");
                        string label1 = Console.ReadLine();
                        Menu.WriteCentered("Enter the label of value 10");
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
                            options.Add(Console.ReadLine());
                            Menu.WriteCentered("Add another option? (y/n)");
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
            Console.WriteLine("Which survey do you want to distribute?");
            int counter = 1;
            foreach (Survey survey in surveyRepository.GetAllSurveys())
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
                Console.WriteLine(us.GetUserSsn() + " | " + us.GetUserCode() + " | " + us.GetSurvey().Title);
            }
        }

        public static void ListAllUsers(UserRepository userRepository)
        {
            Dictionary<string, UserRoles> users = userRepository.ListUsers();
            foreach (KeyValuePair<string, UserRoles> u in users)
            {
                Console.WriteLine(u.Key + " " + u.Value.ToString());
            }
        }
        public static void AddUser(UserRepository userRepository)
        {
            string roleAdd = "";
            string ssnAdd = "";
            System.Console.WriteLine("What role of user do you wish to add?");
            System.Console.WriteLine("1. Admin");
            System.Console.WriteLine("2. Participant");
            roleAdd = Console.ReadLine();
            while (roleAdd != "1" && roleAdd != "2")
            {
                System.Console.WriteLine("Enter a valid role");
                roleAdd = Console.ReadLine();
            }
            System.Console.WriteLine("Enter the SSN of the user (example : 199001015555");
            ssnAdd = Console.ReadLine();
            while (ssnAdd.Length != 12)
            {
                System.Console.WriteLine("Invalid SSN, 12 digits.");
                ssnAdd = Console.ReadLine();
                if (IsDigitsOnly(ssnAdd) == false)
                {
                    ssnAdd = "";
                }
            }
            foreach (User u in userRepository.GetUsers())
            {
                if (ssnAdd == u.Ssn)
                {
                    System.Console.WriteLine("A user with this SSN already exists, aborting...");
                    roleAdd = "0";
                }
            }
            if (roleAdd == "1")
            {
                User addUser = new User(ssnAdd, UserRoles.Admin);
                userRepository.AddNewUser(addUser);
                System.Console.WriteLine("Added an Admin with the SSN: " + ssnAdd);
            }
            else if (roleAdd == "2")
            {
                User addUser = new User(ssnAdd, UserRoles.Participant);
                userRepository.AddNewUser(addUser);
                System.Console.WriteLine("Added a Participant with the SSN: " + ssnAdd);
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
