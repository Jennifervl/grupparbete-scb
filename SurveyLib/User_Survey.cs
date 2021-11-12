namespace SurveyLib
{
    public class User_Survey
    {
        User user;
        Survey survey;
        string code;
        bool isSubmitted;

        public User_Survey(User user, Survey survey)
        {
            this.user = user;
            this.survey = survey;
            this.code = GenerateCode();
            this.isSubmitted = false;
        }

        private string GenerateCode()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}