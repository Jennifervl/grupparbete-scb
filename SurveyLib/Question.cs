namespace SurveyLib
{
    public abstract class Question
    {
        string title;
        public string Title
        {
            get => title;
            set => title = value;
        }

        public abstract void SetAnswer(string answer);
    }
}