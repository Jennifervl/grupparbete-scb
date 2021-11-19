using System.Collections.Generic;
namespace SurveyLib
{
    public class YesOrNoQuestion : Question
    {
        bool answer;
        List<bool> answers = new();
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
    }
}