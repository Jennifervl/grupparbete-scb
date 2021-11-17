using System.Collections.Generic;

namespace SurveyLib
{
    public class Survey
    {
        string title;

        List<Question> questions;

        List<User_Survey> userSurveys;

        public string Title
        {
            get
            {
                return title;
            }
        }

        public Survey(string title)
        {
            this.title = title;
            questions = new List<Question>();
            userSurveys = new List<User_Survey>();
        }

        public IList<Question> GetQuestions()
        {
            return questions.AsReadOnly();
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public void AddUserSurvey(User_Survey userSurvey)
        {
            userSurveys.Add(userSurvey);
        }

        public List<User_Survey> GetUser_Surveys()
        {
            return userSurveys;
        }
    }
}