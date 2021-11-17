using System.Collections.Generic;

namespace SurveyLib
{

    public class User_Survey_Repository
    {
        List<User_Survey> User_Surveys;

        public User_Survey_Repository()
        {
            User_Surveys = new();
        }

        public void AddUserSurvey(User_Survey us)
        {
            User_Surveys.Add(us);
        }

        public List<User_Survey> GetUser_Surveys()
        {
            return User_Surveys;
        }








    }

}
