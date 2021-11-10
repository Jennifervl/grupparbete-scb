namespace SurveyLib
{
    class _1_to_10 : Question
    {
        string Value1
        {
            get { return value1; }
            set { value1 = value; }
        }
        string Value10
        {
            get { return value10; }
            set { value10 = value; }
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
            }

        }

    }
}
