using System.Collections.Generic;

namespace SurveyLib
{
    public class Admin : User
    {
        //TODO: Remove old password

        // private string password;

        Password pw;

        public string Password
        {
            get
            {
                return pw.HashedPassword;
            }
        }
        public Password Pw
        {
            get
            {
                return pw;
            }
        }

        public Admin(string assn, string apassword) : base(assn)
        {
            // this.password = apassword;
            this.pw = new(apassword);
        }
        public bool ValidateAdmin(string password)
        {
            if (this.Pw.HashPassword(password, this.Pw.Salt) == this.Pw.HashedPassword)
                return true;
            else return false;

        }
    }
}