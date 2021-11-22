using System.Collections.Generic;

namespace SurveyLib
{
    public class Admin : User
    {
        //TODO: Remove old password

        private string password;

        Password pw;

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
            this.pw = new(apassword);
        }
    }
}