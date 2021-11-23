using System.Collections.Generic;
using System;

namespace SurveyLib
{
    public class SurveyRepository
    {
        List<Survey> surveys;
        SaveDataManager saveDataManager = new();
        public LoadDataManager loadDataManager = new();

        public SurveyRepository()
        {
            surveys = new List<Survey>();
        }

        public void AddSurvey(Survey survey)
        {
            surveys.Add(survey);
        }

        public IList<Survey> GetAllSurveys()
        {
            return surveys.AsReadOnly();
        }

        public Survey GetSurveyAtIndex(int index)
        {
            index -= 1;
            return surveys[index];
        }

        public void LoadSurveys()
        {
            foreach (Survey survey in loadDataManager.LoadAllSurveys())
            {
                AddSurvey(survey);
            }
        }

        public void SaveSurvey(Survey survey)
        {
            saveDataManager.SaveSurvey(survey);
        }

        public void IsUniqueTitle(string title)
        {
            foreach (Survey survey in surveys)
            {
                if (survey.Title == title)
                {
                    throw new Exception("Title already exists");
                }
            }
        }
    }
}