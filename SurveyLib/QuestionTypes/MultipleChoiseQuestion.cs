using System.Collections.Generic;
using System.Linq;

namespace SurveyLib
{
    public class MultipleChoiseQuestion : Question
    {
        List<bool> answer = new();
        List<List<bool>> answers = new();
        List<string> options = new();

        public List<List<bool>> Answers
        {
            get
            {
                return answers;
            }
        }

        public MultipleChoiseQuestion(string title, List<string> options) : base(title)
        {
            this.options = options;
        }

        public void SetAnswer(List<int> answers)
        {
            for (int i = 1; i < options.Count + 1; i++)
            {
                if (answers.Contains(i)) this.answer.Add(true);
                else this.answer.Add(false);
            }


        }

        public IList<string> GetOptions()
        {
            return options.AsReadOnly();
        }

        public IList<bool> GetAnswer()
        {
            return answer.AsReadOnly();
        }

        public void SetAnswerFromDB(List<bool> answer)
        {
            answers.Add(answer);
        }
    }
}