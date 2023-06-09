using System;
using System.IO;
using System.Collections.Generic;

namespace SurveyLib
{
    public class txtfileDataManager
    {
        public static void SaveResult(Survey survey)
        {
            // Check if file exists for the survey, if not create it
            if (!(File.Exists($"..\\SurveyLib\\surveyData\\" + $"{survey.Title}")))
            {
                File.WriteAllText($"..\\SurveyLib\\surveyData\\" + $"{survey.Title}", BuildSurveyTxtFileString(survey));
            }

            // if file is created, input data from survey
            if (File.Exists($"..\\SurveyLib\\surveyData\\" + $"{survey.Title}"))
            {
                string data = File.ReadAllText($"..\\SurveyLib\\surveyData\\" + $"{survey.Title}");
                int i = 1;
                foreach (Question q in survey.GetQuestions())
                {
                    if (q is _1_to_10 oneToTen)
                    {
                        data = data.Insert(data.IndexOf("[", GetNthIndex(data, '[', i)) + 1, oneToTen.Answer.ToString() + ",");
                    }
                    else if (q is FreetextQuestion ftq)
                    {
                        data = data.Insert(data.IndexOf("[", GetNthIndex(data, '[', i)) + 1, ftq.GetAnswer() + "£");
                    }
                    else if (q is MultipleChoiseQuestion mcq)
                    {
                        string oneUsersAnswers = "";
                        foreach (bool a in mcq.GetAnswer())
                        {
                            oneUsersAnswers += a.ToString() + ",";
                        }
                        oneUsersAnswers += ";";

                        data = data.Insert(data.IndexOf("[", GetNthIndex(data, '[', i)) + 1, oneUsersAnswers);
                    }
                    else if (q is YesOrNoQuestion yesOrNo)
                    {
                        data = data.Insert(data.IndexOf("[", GetNthIndex(data, '[', i)) + 1, yesOrNo.GetAnswer().ToString() + ",");
                    }
                    i++;
                }
                File.WriteAllText($"..\\SurveyLib\\surveyData\\" + $"{survey.Title}", data);
            }
        }

        public static string BuildSurveyTxtFileString(Survey survey)
        {
            string txtfile = $":{survey.Title}:\n";
            foreach (Question q in survey.GetQuestions())
            {
                txtfile += "[]\n";
            }
            return txtfile;
        }

        public static string GetSurveyData(string title)
        {
            string path = $"..\\SurveyLib\\surveyData\\" + $"{title}";
            return File.ReadAllText(path);
        }

        public static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}