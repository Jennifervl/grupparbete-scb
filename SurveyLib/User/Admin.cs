using System.Collections.Generic;

namespace SurveyLib
{
    public class Admin : User
    {

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
        }

        public Admin(string assn, string apassword) : base(assn)
        {
            this.password = apassword;
        }
    }
}