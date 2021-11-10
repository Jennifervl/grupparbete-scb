using System.Collections.Generic;

namespace SurveyLib
{
    public class Survey
    {
        string title;

        string id;

        List<Question> questions;

        IDataManager datamanager;

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

        public string Id
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

        public IList<Question> Questions
        {
            get
            {
                return questions.AsReadOnly();
            }
        }

        public Survey(string title, string id, IDataManager datamanager)
        {
            this.title = title;
            this.id = id;
            this.datamanager = datamanager;
            questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }
    }
}