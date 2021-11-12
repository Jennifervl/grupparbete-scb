namespace SurveyLib
{
    public class User
    {
        public UserRoles userRoles;
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
        public void UserInfo()
        {
            System.Console.WriteLine($"Personnummer: {ssn} \nAnvändartyp: {userRoles.ToString()}\n");
        }
    }
}
