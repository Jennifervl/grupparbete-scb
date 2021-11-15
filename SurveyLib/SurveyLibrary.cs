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
    }
}