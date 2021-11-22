using System;
using System.Collections.Generic;
using SurveyLib;
using System.Linq;

namespace ConsoleUI
{
    class AdminCommands
    {
        public static void ListAllSurveys(SurveyRepository surveyRepository)
        {
            foreach (Survey s in surveyRepository.GetAllSurveys())
            {
                Console.WriteLine(s.Title);

            }
        }
        public static void TestSurvey(Survey testSurvey)
        {
            Console.WriteLine(testSurvey.Title);
            IList<Question> questions = testSurvey.GetQuestions();
            foreach (Question q in questions)
            {
                Console.WriteLine(q.Title);
            }
        }

        public static Survey BuildSurvey(SurveyRepository surveyRepository)
        {
            string title = "";
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter the title of the survey");
                    title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("Title cannot be empty, press any key to try again.");
                        Console.ReadKey(true);
                        continue;
                    }
                    break;
                }
                try
                {
                    surveyRepository.IsUniqueTitle(title);
                }
                catch (Exception)
                {
                    Console.WriteLine("Title already exists, press any key to try again.");
                    Console.ReadKey(true);
                    continue;
                }
                break;
            }


            Survey survey1 = new(title);
            while (true)
            {
                Console.WriteLine("What type of question do you want to add?");
                Console.WriteLine("1. 1-to-10-question");
                Console.WriteLine("2. Freetext question");
                Console.WriteLine("3. Yes or no question");
                Console.WriteLine("4. Multiple choise question");
                Console.WriteLine("5. No more questions");
                string input = Console.ReadLine();
                if (input == "5") break;
                else if (input == "1" || input == "2" || input == "3" || input == "4")
                {
                    string qtitle = "";

                    while (true)
                    {
                        Console.WriteLine("Enter the title of the question");
                        qtitle = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(qtitle))
                        {
                            Console.WriteLine("Title cannot be empty, press any key to try again.");
                            Console.ReadKey(true);
                            continue;
                        }
                        break;
                    }

                    if (input == "1")
                    {
                        string label1 = "";
                        string label10 = "";

                        while (true)
                        {
                            Console.WriteLine("Enter the label of number 1");
                            label1 = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(label1))
                            {
                                Console.WriteLine("Label cannot be empty, press any key to try again.");
                                Console.ReadKey(true);
                                continue;
                            }
                            break;
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter the label of value 10");
                            label10 = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(label10))
                            {
                                Console.WriteLine("Label cannot be empty, press any key to try again.");
                                Console.ReadKey(true);
                                continue;
                            }
                            break;
                        }
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
                            string option = "";
                            while (true)
                            {
                                Console.WriteLine("Enter an option");
                                option = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(option))
                                {
                                    Console.WriteLine("Option cannot be empty, press any key to try again.");
                                    Console.ReadKey(true);
                                    continue;
                                }

                                options.Add(option);
                                break;
                            }
                            Console.WriteLine("Add another option? (y/n)");
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
                else
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }
            }
            return survey1;


        }

        internal static void ShowSurveyStatistics(SurveyRepository surveyRepository)
        {
            Console.Clear();
            int counter = 1;
            foreach (Survey s in surveyRepository.GetAllSurveys())
            {
                Console.WriteLine(counter + ": " + s.Title);
                counter++;
            }

            Console.WriteLine("Enter the number of the survey you want to see the statistics for");
            string input = Console.ReadLine();
            int surveyNumber = int.Parse(input);
            Survey survey = surveyRepository.GetSurveyAtIndex(surveyNumber);
            survey = surveyRepository.loadDataManager.LoadSurveyAnswers(survey);

            Console.Clear();
            Console.WriteLine("Survey: " + survey.Title);
            Console.WriteLine("Amount of questions: " + survey.GetQuestions().Count);
            Console.WriteLine("");
            Menu.PressToContinue();


            int questionCounter = 1;
            foreach (Question q in survey.GetQuestions())
            {
                Console.Clear();
                Console.WriteLine("Question: " + questionCounter);
                Console.WriteLine(q.Title);

                if (q is _1_to_10 oneToTen)
                {
                    int[] intResults = new int[10];

                    foreach (int answer in oneToTen.Answers)
                    {
                        intResults[answer - 1]++;
                    }

                    Console.WriteLine("One means: " + oneToTen.Value1);
                    Console.WriteLine("Ten means: " + oneToTen.Value10);

                    for (int i = 0; i < intResults.Length; i++)
                    {
                        Console.WriteLine((i + 1) + " Got " + intResults[i] + " Votes");
                    }

                }
                else if (q is FreetextQuestion ftq)
                {
                    foreach (string result in ftq.Answers)
                    {
                        Console.WriteLine(result);
                    }
                }

                else if (q is MultipleChoiseQuestion mcq)
                {
                    int[] intResult = new int[mcq.GetOptions().Count];
                    int aCounter = 0;
                    foreach (List<bool> answers in mcq.Answers)
                    {
                        foreach (bool answer in answers)
                        {
                            if (answer)
                            {
                                intResult[aCounter]++;
                            }
                        }
                        aCounter++;
                    }

                    for (int i = 0; i < intResult.Length; i++)
                    {
                        Console.WriteLine(mcq.GetOptions()[i] + " Got " + intResult[i] + " Votes");
                    }

                    questionCounter++;
                }
                else if (q is YesOrNoQuestion yOrNo)
                {
                    float fTrue = 0;
                    float fFalse = 0;
                    int percentTrue = 0;

                    foreach (bool result in yOrNo.Answers)
                    {
                        if (result)
                        {
                            fTrue++;
                        }
                        else
                        {
                            fFalse++;
                        }
                    }

                    percentTrue = Convert.ToInt32((fTrue / (fTrue + fFalse)) * 100);
                    Console.WriteLine(percentTrue + "% answered yes");
                }
                Console.WriteLine("");
                Menu.PressToContinue();
                questionCounter++;
            }
        }

        public static void DistributeSurvey(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            int index;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which survey do you want to distribute?");
                int counter = 1;
                foreach (Survey survey in surveyRepository.GetAllSurveys())
                {
                    Console.Write(counter + ": ");
                    Console.WriteLine(survey.Title);
                    counter++;
                }
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index < 1 || index > surveyRepository.GetAllSurveys().Count)
                    {
                        Console.WriteLine("Invalid index, press any key to try again.");
                        Console.ReadKey(true);
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Faulty input, press any key to try again.");
                Console.ReadKey(true);
            }
            while (true)
            {
                Console.WriteLine("How would you like to distribute it?");
                Console.WriteLine("1. By age");
                Console.WriteLine("2. CoinFlip");
                Console.WriteLine("3. To everyone");
                string distributeChoice = Console.ReadLine();
                int distributedTo = 0;
                if (distributeChoice == "1")
                {
                    Console.WriteLine("Minumum age: ");
                    int minAge;
                    if (int.TryParse(Console.ReadLine(), out minAge))
                    {
                        Console.WriteLine("Minimum age set to: " + minAge);
                    }
                    else
                    {
                        Console.WriteLine("Faulty input, press any key to try again.");
                        Console.ReadKey(true);
                        continue;
                    }
                    Console.WriteLine("Maximum age: ");
                    int maxAge;
                    if (int.TryParse(Console.ReadLine(), out maxAge))
                    {
                        Console.WriteLine("Maximum age set to: " + maxAge);
                    }
                    else
                    {
                        Console.WriteLine("Faulty input, press any key to try again.");
                        Console.ReadKey(true);
                        continue;
                    }
                    distributedTo = Distributor.DistributeByAge(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
                    break;
                }
                else if (distributeChoice == "2")
                {
                    Distributor.CoinFlipDistribution(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
                    Console.WriteLine("Form was submitted successfully.");
                    Console.WriteLine("Press Any key to return to Adminmenu.");
                    Console.ReadKey(true);
                    Menu.AdminMenu(userRepository, surveyRepository, usr);


                }
                else if (distributeChoice == "3")
                {
                    Distributor.DistributeToAll(surveyRepository.GetSurveyAtIndex(index), userRepository, usr);
                    Console.WriteLine("Form was submitted successfully.");
                    Console.WriteLine("Press Any key to return to Adminmenu.");
                    Console.ReadKey(true);
                    Menu.AdminMenu(userRepository, surveyRepository, usr);

                }
                else Console.WriteLine("Invalid input, press any key to try again.");

                Console.WriteLine("Distributed to " + distributedTo + " users.");
                Console.ReadKey(true);
                continue;
            }
        }
        public static void ListDistributions(User_Survey_Repository usr)
        {
            foreach (User_Survey us in usr.GetUser_Surveys())
            {
                Console.WriteLine(us.GetUserSsn() + " | " + us.GetUserCode() + " | " + us.GetSurvey().Title + " | " + "Is submitted: " + (us.IsSubmitted == true ? "Submitted" : "Pending"));
            }
        }

        public static void ListAllUsers(UserRepository userRepository)
        {
            Dictionary<string, string> users = userRepository.ListUsers();
            foreach (KeyValuePair<string, string> u in users)
            {
                Console.WriteLine(u.Key + " " + u.Value);
            }
        }
        public static void AddUser(UserRepository userRepository)
        {
            string roleAdd = "";
            string ssnAdd = "";
            string passwordAdd = "";
            Console.WriteLine("What role of user do you wish to add?");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Participant");
            roleAdd = Console.ReadLine();
            while (roleAdd != "1" && roleAdd != "2")
            {
                Console.WriteLine("Enter a valid role");
                roleAdd = Console.ReadLine();
            }
            Console.WriteLine("Enter the SSN of the user (example : 199001015555");
            ssnAdd = Console.ReadLine();
            while (ssnAdd.Length != 12)
            {
                Console.WriteLine("Invalid SSN, 12 digits.");
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
                    Console.WriteLine("A user with this SSN already exists, aborting...");
                    roleAdd = "0";
                }
            }
            if (roleAdd == "1")
            {
                while (true)
                {
                    Console.WriteLine("Enter password you wish to use:");
                    passwordAdd = Console.ReadLine();
                    if (passwordAdd != "") break;
                    else Console.WriteLine("You can not add an empty password");
                }

                Admin addAdmin = new Admin(ssnAdd, passwordAdd);
                userRepository.AddNewUser(addAdmin);
                userRepository.SaveUser(addAdmin);
                Console.WriteLine("Added an Admin with the SSN: " + ssnAdd);
            }
            else if (roleAdd == "2")
            {
                Participant addParticipant = new Participant(ssnAdd);
                userRepository.AddNewUser(addParticipant);
                userRepository.SaveUser(addParticipant);
                Console.WriteLine("Added a Participant with the SSN: " + ssnAdd);
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
        public static bool ConfirmAdmin(UserRepository userRepository)
        {
            int failedAttempts = 0;
            bool confirmed = false;
            bool passwordLoop = true;
            string ssn = "";
            string password = "";
            Console.Clear();
            Console.WriteLine("Admin Login");
            Console.WriteLine("Enter your SSN (12 digits)");
            ssn = Console.ReadLine();
            if (IsDigitsOnly(ssn) == false)
            {
                ssn = "";
            }
            while (ssn.Length != 12)
            {
                Console.WriteLine("Invalid SSN, 12 digits.");
                ssn = Console.ReadLine();
                if (IsDigitsOnly(ssn) == false)
                {
                    ssn = "";
                }
            }
            foreach (User u in userRepository.GetUsers())
            {
                if (u is Admin a)
                {
                    if (ssn == a.GetUserSsn())
                    {
                        Console.WriteLine("Enter your password:");
                        while (passwordLoop == true)
                        {
                            password = Console.ReadLine();
                            if (a.Pw.ValidatePassword(password) == true)
                            {
                                confirmed = true;
                                passwordLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Wrong password, try again");
                                failedAttempts++;
                                if (failedAttempts == 3)
                                {
                                    Console.WriteLine("Too many failed attempts");
                                    passwordLoop = false;
                                }
                            }
                        }
                    }
                }
            }
            if (confirmed == true)
            {

            }
            else
            {
                Console.WriteLine("No admin with that SSN exists");
            }
            Menu.ReturnToAdminMenu();
            return confirmed;
        }
    }
}
