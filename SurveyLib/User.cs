namespace SurveyLib
{
    public class User
    {
        UserRoles userRoles;
        private string ssn;
        public string Ssn
        {
            get
            {
                return ssn;
            }
        }
        public User(string assn, UserRoles auserRoles)
        {
            this.ssn = assn;
            this.userRoles = auserRoles;
        }
    }
}
