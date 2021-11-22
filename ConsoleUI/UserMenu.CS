using System;
using System.Collections.Generic;
using SurveyLib;
namespace ConsoleUI
{
    class UserMenu
    {

        public static void Questionaire(UserRepository userRepository, SurveyRepository surveyRepository, User_Survey_Repository usr)
        {
            Console.WriteLine("Enter the questionaire code");
            string code = Console.ReadLine();

            bool foundmatch = false;
            foreach (User_Survey US in usr.GetUser_Surveys())
            {
                if (US.FindMatch(code) != null && US.IsSubmitted == false)
                {
                    foundmatch = true;
                    AnswerSurvey(US.FindMatch(code));
                    usr.SetSubmittedTrue(US);
                    Console.WriteLine("Thanks for taking the survey!");
                    // PrintData.Print(US.FindMatch(code), usr);
                }
                else if (US.FindMatch(code) != null && US.IsSubmitted == true)
                {
                    Console.WriteLine("This survey has already been answered.");
                    Menu.PressToContinue();
                }
            }
            if (!foundmatch)
            {
                Console.WriteLine("No survey matched your code, press any key to return.");
            }
            Console.ReadLine();
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
                    Console.WriteLine("1 means: " + _1_to_10_question.Value1);
                    Console.WriteLine("10 means: " + _1_to_10_question.Value10);
                    _1_to_10_question.SetAnswer(Convert.ToInt32(Console.ReadLine()));
                }

                else if (mcq != null)
                {
                    Console.WriteLine("Options: ");
                    int optiondigit = 1;
                    foreach (string option in mcq.GetOptions())
                    {
                        Console.Write(optiondigit + ": ");
                        Console.WriteLine(option);
                        optiondigit++;
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
                    Console.Write("Y/N ? ");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        ynq.SetAnswer(true);
                    }
                    else ynq.SetAnswer(false);
                }
                else if (ftq != null)
                {
                    // Console.CursorLeft = (Console.WindowWidth / 2) -15;
                    string answer = Console.ReadLine();
                    ftq.SetAnswer(answer);
                }
                Console.WriteLine("");
            }
            SaveDataManager sdm = new SaveDataManager();
            sdm.SaveSurveyAnswers(survey);
            // txtfileDataManager.SaveResult(survey);
        }
    }
}