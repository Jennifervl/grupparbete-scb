using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static Menu menu = new();
        static void Main(string[] args)
        {

            // Login login = new();
            // login.LoginRun();
            menu.MyMenu();
            // Survey survey = Admin.BuildSurvey();
            // AnswerSurvey(survey);

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
                            Console.WriteLine("Enter an option");
                            options.Add(Console.ReadLine());
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
            }
            return survey1;
        }

    }
}
