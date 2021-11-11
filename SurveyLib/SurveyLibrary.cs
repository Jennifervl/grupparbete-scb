using System.Collections.Generic;
using System;

namespace SurveyLib
{
    public class SurveyLibrary
    {
        List<Survey> surveys;

        public SurveyLibrary()
        {
            surveys = new List<Survey>();
        }

        public void AddSurvey(Survey survey)
        {
            surveys.Add(survey);
        }

        public List<Survey> GetAllSurveys()
        {
            return surveys;
        }

        public Survey GetSurvey(int id)
        {
            foreach (Survey survey in surveys)
            {
                if (survey.Id == id)
                {
                    return survey;
                }
            }
            throw new KeyNotFoundException();
        }
    }
}