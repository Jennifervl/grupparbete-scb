using System.Collections.Generic;

namespace SurveyLib
{
    public class User
    {
        public UserRoles userRoles;
        private string ssn;
        private List<User_Survey> userSurveys;

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
            this.userSurveys = new List<User_Survey>();
        }
        public void UserInfo()
        {
            System.Console.WriteLine($"Personnummer: {ssn} \nAnvändartyp: {userRoles.ToString()}\n");
        }

        public void AddUserSurvey(User_Survey userSurvey)
        {
            userSurveys.Add(userSurvey);
        }

        public List<User_Survey> GetUserSurveys()
        {
            return userSurveys;
        }

        public int getAge()
        {
            int yearBorn = System.Convert.ToInt32(Ssn.Substring(0, 4));
            int age = System.DateTime.Now.Year - yearBorn;
            return age;
        }
    }
}
