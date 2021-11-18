using System;
using System.Collections.Generic;
using SurveyLib;
namespace ConsoleUI
{
    class UserMenu
    {

        public static void Questionaire(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            Menu.WriteCentered("Enter the questionaire code: ");
            Console.CursorLeft = (Console.WindowWidth / 2) - 10;
            string code = Console.ReadLine();

            foreach (User_Survey US in usr.GetUser_Surveys())
            {
                if (US.FindMatch(code) != null)
                {
                    AnswerSurvey(US.FindMatch(code));
                    US.IsSubmitted = true;
                    Menu.WriteCentered("Thanks for taking the survey!");
                    PrintData.Print(US.FindMatch(code), usr);
                    Console.ReadLine();
                }
            }

        }

        public static void AnswerSurvey(Survey survey)
        {
            Console.Clear();
            Menu.WriteCentered(survey.Title);
            Menu.WriteCentered("");

            int questionCounter = 0;

            foreach (Question q in survey.GetQuestions())
            {
                questionCounter++;
                Menu.WriteCentered("Question " + questionCounter);
                Menu.WriteCentered(q.Title);

                _1_to_10 _1_to_10_question = q as _1_to_10;
                MultipleChoiseQuestion mcq = q as MultipleChoiseQuestion;
                YesOrNoQuestion ynq = q as YesOrNoQuestion;
                FreetextQuestion ftq = q as FreetextQuestion;

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
                else if (ynq != null)
                {
                    Menu.WriteCentered("Y/N ?");
                    Console.CursorLeft = (Console.WindowWidth / 2);
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        ynq.SetAnswer(true);
                    }
                    else ynq.SetAnswer(false);
                }
                else if (ftq != null)
                {
                    Console.CursorLeft = (Console.WindowWidth / 2) -15;
                    string answer = Console.ReadLine();
                    ftq.SetAnswer(answer);
                }
            }
            txtfileDataManager.SaveResult(survey);
        }



    }
}