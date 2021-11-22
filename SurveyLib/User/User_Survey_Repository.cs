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

        public void SaveUser_Survey(User_Survey us)
        {
            saveDataManager.SaveUser_Survey(us);
        }

        public void LoadAllUser_Surveys()
        {
            foreach (User_Survey us in loadDataManager.LoadAllUser_Surveys())
            {
                User_Surveys.Add(us);
            }
        }

        public void SetSubmittedTrue(User_Survey us)
        {
            us.IsSubmitted = true;
            saveDataManager.UpdateUser_Survey(us);
        }

        public User_Survey GetUser_SurveyByCode(string code)
        {
            foreach (User_Survey us in User_Surveys)
            {
                if (us.GetUserCode() == code)
                {
                    return us;
                }
            }

            return null;
        }
    }
}
