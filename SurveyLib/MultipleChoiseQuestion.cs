using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib
{
    public class MultipleChoiseQuestion : Question
    {
        List<int> answer = new();
        List<string> options = new();



        public override bool SetAnswer(string answer)
        {
            bool success = false;
            foreach (char i in answer)
            {
                if (Int32.TryParse(i.ToString(), out int iInt) == true)
                {
                    iInt--;
                    if (iInt < options.Count() && iInt >= 0)
                    {
                        if (!(this.answer.Contains(iInt)))
                        {
                            this.answer.Add(iInt);
                            success = true;

                        }
                    }
                }
            }
            return success;
        }

        public bool AddOption(string answer)
        {
            if (!this.options.Contains(answer))
            {
                options.Add(answer);
                return true;
            }
            else return false;
        }

        public IList<string> GetOptions()
        {
            return options.AsReadOnly();
        }

        public IList<int> GetAnswer()
        {
            return answer.AsReadOnly();
        }
    }
}