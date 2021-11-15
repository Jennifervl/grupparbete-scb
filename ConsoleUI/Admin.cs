using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Admin
    {
        public static void ListAllSurveys(SurveyLibrary surveyLibrary)
        {

            foreach (Survey s in surveyLibrary.GetAllSurveys())
            {
                System.Console.WriteLine(s.Title);
            }
        }
        public static void TestSurvey(Survey testSurvey)
        {
            System.Console.WriteLine(testSurvey.Title);
            List<Question> questions = new();
            questions = testSurvey.GetQuestions();
            foreach (Question q in questions)
            {
                System.Console.WriteLine(q.Title);
            }
        }

        public static Survey BuildSurvey()
        {
            Console.WriteLine("Enter the title of the survey");
            string title = Console.ReadLine();
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

                else
                {
                    Console.WriteLine("Enter the title of the question");
                    string qtitle = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.WriteLine("Enter the label of number 1");
                        string label1 = Console.ReadLine();
                        Console.WriteLine("Enter the label of value 10");
                        string label10 = Console.ReadLine();
                        _1_to_10 _1_To_10question = new(qtitle, label1, label10);
                        survey1.AddQuestion(_1_To_10question);
                    }

                    else if (input == "2")
                    {
                        FreetextQuestion freetextQuestion = new(title);
                        survey1.AddQuestion(freetextQuestion);
                    }

                    else if (input == "3")
                    {
                        YesOrNoQuestion yesOrNo = new(title);
                        survey1.AddQuestion(yesOrNo);
                    }
                    else if (input == "4")
                    {
                        List<string> options = new();
                        while (true)
                        {
                            Console.WriteLine("Enter an option");
                            options.Add(Console.ReadLine());
                            Console.WriteLine("Add another option? (y/n)");
                            string choise = Console.ReadLine();
                            if (choise.ToLower() == "n")
                            {
                                break;
                            }
                        }
                        MultipleChoiseQuestion mcq = new(title, options);
                        survey1.AddQuestion(mcq);
                    }
                }
            }
            return survey1;


        }
    }
}
