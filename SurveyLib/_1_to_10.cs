using System;

namespace SurveyLib
{
    class _1_to_10 : Question, iQuestion
    {
        string value1;
        string value10;
        public string Value1
        {
            get => value1;
            set => value1 = value;
        }
        string Value10
        {
            get => value1;
            set => value1 = value;
        }
        public bool SetAnswer(string answer)
        {
            if (Int32.TryParse(answer, out int answerInt) == true)
            {
                if (answerInt < 11 && answerInt > 0)
                {
                    this.answer = answer;
                    return true;
                }
                else return false;
            }
            else return false;

        }
    }
}
