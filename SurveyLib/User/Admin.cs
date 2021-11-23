using System.Collections.Generic;

namespace SurveyLib
{
    public class Admin : User
    {

        Password pw;

        public Password Pw
        {
            get
            {
                return pw;
            }
            set
            {
                pw = value;
            }
        }

        public Admin(string assn, string apassword) : base(assn)
        {
            this.pw = new(apassword);
        }
    }
}