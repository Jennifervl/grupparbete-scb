namespace SurveyLib
{
    public abstract class Question
    {
        string title;
        public string Title
        {
            get => title;
        }

        public Question(string title)
        {
            this.title = title;
        }
    }
}