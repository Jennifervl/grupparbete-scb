using System.Collections.Generic;

namespace SurveyLib
{

    public class User_Survey_Repository
    {
        List<User_Survey> User_Surveys;
        LoadDataManager loadDataManager = new();
        SaveDataManager saveDataManager = new();

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

        public void SaveUser_Survey()
        {

        }
        public void LoadAllUser_Surveys()
        {
            foreach (User_Survey us in loadDataManager.LoadAllUser_Surveys())
            {
                User_Surveys.Add(us);
            }
        }
    }
}
