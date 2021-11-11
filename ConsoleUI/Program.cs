using System;
using SurveyLib;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // Login login = new();
            // login.LoginRun();
            surveyTest();

            Menu menu = new();
            menu.MyMenu();
        }
        public static void surveyTest()
        {
            Survey survey = new("Testsurvey", 1);


            _1_to_10 test1to10question = new _1_to_10();
            test1to10question.Title = "How much do you like this survey?";
            test1to10question.Value1 = "Hate it";
            test1to10question.Value10 = "Love it";
            survey.AddQuestion(test1to10question);

            MultipleChoiseQuestion mcqtest = new();
            mcqtest.Title = "What is your favorite color?";
            mcqtest.AddOption("Red");
            mcqtest.AddOption("Blue");
            mcqtest.AddOption("Green");

            survey.AddQuestion(mcqtest);

            Console.WriteLine("Your survey is: " + survey.Title);
            Console.WriteLine("Your survey has " + survey.GetQuestions().Count + " questions");

            foreach (Question q in survey.GetQuestions())
            {
                Console.WriteLine(q.Title);
                if (q is _1_to_10 test110)
                {
                    Console.WriteLine("1 means: " + test110.Value1 + " 10 means: " + test110.Value10);
                    q.SetAnswer(Console.ReadLine());
                }
                else if (q is MultipleChoiseQuestion mpc)
                {
                    Console.WriteLine("Options: ");
                    foreach (string option in mpc.GetOptions())
                    {
                        Console.WriteLine(option);
                    }
                    Console.WriteLine("Enter answer:");
                    q.SetAnswer(Console.ReadLine());
                }
            }




            Console.WriteLine("ANSWERS:");
            int qcounter = 1;
            foreach (Question q in survey.GetQuestions())
            {
                Console.WriteLine("Question " + qcounter);
                qcounter++;
                if (q is _1_to_10 test110)
                {
                    Console.WriteLine(test110.GetAnswer());
                }
                else if (q is MultipleChoiseQuestion mpc)
                {
                    foreach (int a in mpc.GetAnswer())
                    {
                        Console.WriteLine(a + 1);
                    }
                }
            }
        }
    }
}
