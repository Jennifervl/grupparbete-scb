using SurveyLib;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public static class PrintData
    {
        public static void Print(Survey survey, User_Survey_Repository usr)
        {
            string data = txtfileDataManager.GetSurveyData(survey.Title);

            int participants = 0;

            foreach (User_Survey US in usr.GetUser_Surveys())
            {
                if (US.GetSurvey() == survey)
                {
                    if (US.IsSubmitted == true)
                    {
                        participants++;
                    }
                }
            }

            Console.WriteLine("Survey: " + survey.Title);
            Console.WriteLine("Amount of participants: " + participants);
            Console.WriteLine("Amount of questions: " + survey.GetQuestions().Count);
            Console.WriteLine("");

            int questionCounter = 1;
            foreach (Question q in survey.GetQuestions())
            {
                Console.WriteLine("Question: " + questionCounter);
                Console.WriteLine(q.Title);

                if (q is _1_to_10 oneToTen)
                {
                    string oneToTenData = "";
                    int startIndex = txtfileDataManager.GetNthIndex(data, '[', questionCounter);
                    int endIndex = txtfileDataManager.GetNthIndex(data, ']', questionCounter);
                    int length = endIndex - startIndex;

                    oneToTenData = data.Substring(startIndex + 1, length - 2);

                    string[] sResults = oneToTenData.Split(',');
                    int[] intResults = new int[10];

                    foreach (string answer in sResults)
                    {
                        intResults[Convert.ToInt32(answer) - 1]++;
                    }

                    int average = 0;

                    for (int i = 1; i < intResults.Length; i++)
                    {
                        average += i * intResults[i];
                    }
                    average = average / participants;

                    Console.WriteLine("One means: " + oneToTen.Value1);
                    Console.WriteLine("Ten means: " + oneToTen.Value10);
                    Console.WriteLine("Average vote: " + average);

                    for (int i = 0; i < intResults.Length; i++)
                    {
                        Console.WriteLine((i + 1) + " Got " + intResults[i] + " Votes");
                    }

                }
                else if (q is FreetextQuestion ftq)
                {
                    string ftqData = "";
                    int startIndex = txtfileDataManager.GetNthIndex(data, '[', questionCounter);
                    int endIndex = txtfileDataManager.GetNthIndex(data, ']', questionCounter);
                    int length = endIndex - startIndex;

                    ftqData = data.Substring(startIndex + 1, length - 2);

                    String[] results = ftqData.Split('£');

                    foreach (string result in results)
                    {
                        Console.WriteLine(result);
                    }


                }
                else if (q is MultipleChoiseQuestion mcq)
                {
                    string mcqData = "";
                    int startIndex = txtfileDataManager.GetNthIndex(data, '[', questionCounter);
                    int endIndex = txtfileDataManager.GetNthIndex(data, ']', questionCounter);
                    int length = endIndex - startIndex;

                    mcqData = data.Substring(startIndex + 1, length - 2);

                    String[] results = mcqData.Split(';');

                    int[] intResult = new int[mcq.GetOptions().Count];

                    foreach (string result in results)
                    {
                        string[] sResults = result.Split(',');

                        for (int i = 0; i < sResults.Length; i++)
                        {
                            if (sResults[i] == "True")
                            {
                                intResult[i]++;
                            }
                        }
                    }

                    for (int i = 0; i < intResult.Length; i++)
                    {
                        Console.WriteLine(mcq.GetOptions()[i] + " Got " + intResult[i] + " Votes");
                    }

                    questionCounter++;
                }
                else if (q is YesOrNoQuestion)
                {
                    string ftqData = "";
                    float fTrue = 0;
                    float fFalse = 0;
                    int percentTrue = 0;
                    int startIndex = txtfileDataManager.GetNthIndex(data, '[', questionCounter);
                    int endIndex = txtfileDataManager.GetNthIndex(data, ']', questionCounter);
                    int length = endIndex - startIndex;

                    ftqData = data.Substring(startIndex + 1, length - 2);

                    String[] results = ftqData.Split(',');

                    foreach (string result in results)
                    {
                        if (result == "True") fTrue++;
                        else if (result == "False") fFalse++;
                        Console.WriteLine(result);
                    }
                    percentTrue = Convert.ToInt32((fTrue / (fTrue + fFalse)) * 100);
                    Console.WriteLine(percentTrue + "% answered yes");


                }
                Console.WriteLine("");
                questionCounter++;
            }
        }
    }
}