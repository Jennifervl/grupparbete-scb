using System;
using System.Collections.Generic;
using SurveyLib;

namespace ConsoleUI
{
    class ServeyTest
    {
        public static void surveyTest()
        {
            Survey survey = new("Testsurvey");

            _1_to_10 test1to10question = new _1_to_10("How much do you like this survey?", "Hate it", "Love it");
            survey.AddQuestion(test1to10question);

            List<string> options = new() { "Red", "Blue", "Green" };
            MultipleChoiseQuestion mcqtest = new("What is your favorite color?", options);

            survey.AddQuestion(mcqtest);

            Menu.WriteCentered("Your survey is: " + survey.Title);
            Menu.WriteCentered("Your survey has " + survey.GetQuestions().Count + " questions");

            foreach (Question q in survey.GetQuestions())
            {
                Menu.WriteCentered(q.Title);

                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;

                if (_1_to_10_question != null)
                {
                    Menu.WriteCentered("1 means: " + _1_to_10_question.Value1 + " 10 means: " + _1_to_10_question.Value10);
                    Console.CursorLeft = (Console.WindowWidth / 2);
                    _1_to_10_question.SetAnswer(Convert.ToInt32(Console.ReadLine()));
                }

                else if (mcq != null)
                {
                    Menu.WriteCentered("Options: ");
                    foreach (string option in mcq.GetOptions())
                    {
                        Menu.WriteCentered(option);
                    }
                    List<int> answers = new();
                    while (true)
                    {
                        Menu.WriteCentered("Enter a number and press enter to add more answers. Press enter without writing anything to stop adding answers.");
                        Console.CursorLeft = (Console.WindowWidth / 2);
                        string input = Console.ReadLine();
                        if (input == "") break;

                        if (Int32.TryParse(input, out int answerInt) == true)
                        {
                            answers.Add(answerInt);
                        }
                        else Menu.WriteCentered("You must enter a digit");
                    }
                    mcq.SetAnswer(answers);
                }
            }

            Menu.WriteCentered("ANSWERS:");
            int qcounter = 1;
            foreach (Question q in survey.GetQuestions())
            {
                Menu.WriteCentered("Question " + qcounter);
                qcounter++;
                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;

                if (_1_to_10_question != null)
                {

                    Menu.WriteCentered(_1_to_10_question.Answer.ToString());
                }

                else if (mcq != null)
                {
                    foreach (bool a in mcq.GetAnswer())
                    {
                        Menu.WriteCentered(a.ToString());
                    }

                }
            }
            Console.ReadLine();
        }
    }
}