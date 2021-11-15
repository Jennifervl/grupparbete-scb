namespace SurveyLib
{
    public class FreetextQuestion : Question
    {
        string answer;

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
    }
}
