using System.Collections.Generic;

namespace SurveyLib
{
    public abstract class User
    {
        private string ssn;

        public string Ssn
        {
            get
            {
                return ssn;
            }
        }

        public User(string assn)
        {
            this.ssn = assn;
        }


        //TODO: Remove this method
        public string GetUserSsn()
        {
            return ssn;
        }
        public int getAge()
        {
            int yearBorn = System.Convert.ToInt32(Ssn.Substring(0, 4));
            int age = System.DateTime.Now.Year - yearBorn;
            return age;
        }
    }
}
