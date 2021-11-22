using System.Collections.Generic;

namespace SurveyLib
{
    public class Admin : User
    {
        //TODO: Remove old password

        // private string password;

        Password pw;

        // public string Password
        // {
        //     get
        //     {
        //         return pw.HashedPassword;
        //     }
        // }
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
            // this.password = apassword;
            this.pw = new(apassword);
        }
    }
}