using System.Collections.Generic;

namespace SurveyLib
{
    public class Survey
    {
        string title;

        int id;

        List<Question> questions;

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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Survey(string title, int id)
        {
            this.title = title;
            this.id = id;
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
    }
}