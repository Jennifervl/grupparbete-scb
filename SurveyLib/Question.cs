namespace SurveyLib
{
    public abstract class Question
    {
        string title;
        protected string answer;
        public string Title
        {
            get => title;
            set => title = value;
        }
    }
}