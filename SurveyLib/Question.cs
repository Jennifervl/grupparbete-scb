namespace SurveyLib
{
    abstract class Question : iQuestion
    {
        string Question
        {
            get { return question; }
            set { question = value; }
        }
        string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

    }
}