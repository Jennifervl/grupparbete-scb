using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class ServeyTest
    {
         public static void surveyTest()
        {
            Survey survey = new("Testsurvey", 1);


            _1_to_10 test1to10question = new _1_to_10("How much do you like this survey?", "Hate it", "Love it");
            survey.AddQuestion(test1to10question);

            List<string> options = new() { "Red", "Blue", "Green" };
            MultipleChoiseQuestion mcqtest = new("What is your favorite color?", options);

            survey.AddQuestion(mcqtest);

            Console.WriteLine("Your survey is: " + survey.Title);
            Console.WriteLine("Your survey has " + survey.GetQuestions().Count + " questions");

            foreach (Question q in survey.GetQuestions())
            {
                Console.WriteLine(q.Title);

                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;

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
            }




            Console.WriteLine("ANSWERS:");
            int qcounter = 1;
            foreach (Question q in survey.GetQuestions())
            {
                Console.WriteLine("Question " + qcounter);
                qcounter++;
                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;

                if (_1_to_10_question != null)
                {
                    Console.WriteLine(_1_to_10_question.Answer);
                }

                else if (mcq != null)
                {
                    foreach (bool a in mcq.GetAnswer())
                    {
                        Console.WriteLine(a);
                    }

                }
            }
            Console.ReadLine();
        }
    }
}