using System.Collections.Generic;
namespace SurveyLib
{
    public class YesOrNoQuestion : Question
    {
        bool answer;
        List<bool> answers = new();

        public List<bool> Answers
        {
            get
            {
                return answers;
            }
        }

        public YesOrNoQuestion(string title) : base(title)
        {
        }

        public void SetAnswer(bool answer)
        {
            this.answer = answer;
        }

        public bool GetAnswer()
        {
            return answer;
        }

        public void SetAnswerFromDB(bool answer)
        {
            answers.Add(answer);
        }
    }
}