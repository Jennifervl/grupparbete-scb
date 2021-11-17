namespace SurveyLib
{
    public class User_Survey
    {
        User user;
        Survey survey;
        string code;
        bool isSubmitted;

        public bool IsSubmitted
        {
            get
            {
                return isSubmitted;
            }
            set
            {
                isSubmitted = value;
            }
        }

        public User_Survey(User user, Survey survey)
        {
            this.user = user;
            this.survey = survey;
            this.code = GenerateCode();
            this.IsSubmitted = false;
        }

        public Survey GetSurvey()
        {
            return this.survey;
        }
        public User_Survey(User user, Survey survey, string code, bool isSubmitted)
        {
            this.user = user;
            this.survey = survey;
            this.code = code;
            this.IsSubmitted = isSubmitted;
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