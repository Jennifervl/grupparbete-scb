using System;

namespace SurveyLib
{
    public class _1_to_10 : Question
    {
        string value1;
        string value10;
        int answer;

        public _1_to_10(string title, string value1, string value10) : base(title)
        {
            this.value1 = value1;
            this.value10 = value10;
        }

        public string Value1
        {
            get => value1;
        }
        public string Value10
        {
            get => value10;
        }

        public int Answer
        {
            get => answer;
        }
        public void SetAnswer(int answer)
        {
            if (answer > 0 && answer < 11)
            {
                this.answer = answer;
            }
            else throw new ArgumentOutOfRangeException();
        }
    }
}
