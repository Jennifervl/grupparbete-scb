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

        public int getAge()
        {
            int yearBorn = System.Convert.ToInt32(Ssn.Substring(0, 4));
            int age = System.DateTime.Now.Year - yearBorn;
            return age;
        }
    }
}
