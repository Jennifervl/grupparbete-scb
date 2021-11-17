using System.Collections.Generic;

namespace SurveyLib
{
    public class Survey
    {
        string title;

        List<Question> questions;

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
        }

        public IList<Question> GetQuestions()
        {
            return questions.AsReadOnly();
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

    }
}