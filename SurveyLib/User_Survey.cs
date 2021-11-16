namespace SurveyLib
{
    public class User_Survey
    {
        User user;
        Survey survey;
        string code;
        bool isSubmitted;

        public bool IsSubmitted { set => isSubmitted = value; }

        public User_Survey(User user, Survey survey)
        {
            this.user = user;
            this.survey = survey;
            this.code = GenerateCode();
            this.IsSubmitted = false;
        }

        private string GenerateCode()
        {
            return System.Guid.NewGuid().ToString();
        }

        public Survey FindMatch(string code)
        {
            if (code == this.code)
            {
                return survey;
            }
            else return null;
        }
        public string GetUserCode()
        {
            return this.code;
        }

        public string GetUserSsn()
        {
            return this.user.Ssn;
        }
    }
}