using System;
using System.IO;
using System.Collections.Generic;

namespace SurveyLib
{
    public class txtfileDataManager
    {
        public static void SaveResult(Survey survey)
        {
            if (File.Exists("surveyData\"" + survey.Title))
            {

            }
        }
    }
}