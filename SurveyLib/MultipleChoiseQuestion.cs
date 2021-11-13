using System.Collections.Generic;
using System.Linq;

namespace SurveyLib
{
    public class MultipleChoiseQuestion : Question
    {
        List<bool> answer = new();
        List<string> options = new();

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
        // public void SetAnswer(string answer)
        // {
        //     foreach (char i in answer)
        //     {
        //         if (Int32.TryParse(i.ToString(), out int iInt) == true)
        //         {
        //             iInt--;
        //             if (iInt < options.Count() && iInt >= 0)
        //             {
        //                 if (!(this.answer.Contains(iInt)))
        //                 {
        //                     this.answer.Add(iInt);
        //                 }
        //             }
        //         }
        //     }
        // }

        public IList<string> GetOptions()
        {
            return options.AsReadOnly();
        }

        public IList<bool> GetAnswer()
        {
            return answer.AsReadOnly();
        }
    }
}