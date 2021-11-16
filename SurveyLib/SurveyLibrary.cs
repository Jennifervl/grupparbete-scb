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
            Survey testsurvey = new("TestSurvey");
            Question YoNQ = new YesOrNoQuestion("Is this working?");
            Question freeTxtQ = new FreetextQuestion("Say something nice!");
            Question OTT = new _1_to_10("OneToTen test", "Test1", "test10");
            testsurvey.AddQuestion(YoNQ);
            testsurvey.AddQuestion(freeTxtQ);
            testsurvey.AddQuestion(OTT);
            AddSurvey(testsurvey);
        }
    }
}