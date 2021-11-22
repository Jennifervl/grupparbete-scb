using System.Collections.Generic;

namespace SurveyLib
{
    public class FreetextQuestion : Question
    {
        string answer;
        List<string> answers = new();

        public FreetextQuestion(string title) : base(title)
        {
        }

        public void SetAnswer(string answer)
        {
            this.answer = answer;
        }

        public string GetAnswer()
        {
            return answer;
        }
        public void SetAnswerFromDB(string answer)
        {
            answers.Add(answer);
        }
    }
}
