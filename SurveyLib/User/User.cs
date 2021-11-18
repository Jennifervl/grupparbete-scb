using System.Collections.Generic;

namespace SurveyLib
{
    public class User
    {
        private UserRoles userRoles;
        private string ssn;
        private string password;

        public string Ssn
        {
            get
            {
                return ssn;
            }
        }

        public string Password
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
        public User(string assn, UserRoles auserRoles, string apassword)
        {
            this.ssn = assn;
            this.userRoles = auserRoles;
            this.password = apassword;
        }

        //TODO: Remove this method
        public string GetUserSsn()
        {
            return ssn;
        }

        public UserRoles GetUserRole()
        {
            return userRoles;
        }


        public int getAge()
        {
            int yearBorn = System.Convert.ToInt32(Ssn.Substring(0, 4));
            int age = System.DateTime.Now.Year - yearBorn;
            return age;
        }
    }
}
