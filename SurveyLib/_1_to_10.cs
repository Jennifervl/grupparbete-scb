using System;

namespace SurveyLib
{
    public class _1_to_10 : Question
    {
        string value1;
        string value10;
        int answer;
        public string Value1
        {
            get => value1;
            set => value1 = value;
        }
        public string Value10
        {
            get => value10;
            set => value10 = value;
        }
        public override bool SetAnswer(string answer)
        {
            if (Int32.TryParse(answer, out int answerInt) == true)
            {
                if (answerInt < 11 && answerInt > 0)
                {
                    this.answer = answerInt;
                    return true;
                }
                else return false;
            }
            else return false;

        }
        public int GetAnswer()
        {
            return answer;
        }
    }
}
