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

            set
            {
                title = value;
            }
        }

        public Survey(string title)
        {
            this.title = title;
            questions = new List<Question>();
        }

        public List<Question> GetQuestions()
        {
            return questions;
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public void AddUserSurvey(User_Survey userSurvey)
        {
            userSurveys.Add(userSurvey);
        }
    }
}