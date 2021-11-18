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
    }
}
