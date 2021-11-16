using System;

namespace SurveyLib
{
    public static class Distributor
    {
        public static void DistributeByAge(Survey survey, UserList userList, int minAge = 18, int maxAge = 999)
        {
            foreach (User user in userList.GetUsers())
            {
                if (getAge(user) >= minAge && getAge(user) <= maxAge)
                {
                    User_Survey user_survey = new User_Survey(user, survey);
                    survey.AddUserSurvey(user_survey);
                    user.AddUserSurvey(user_survey);
                    Console.WriteLine(user_survey.GetUserCode() + " | " + user_survey.GetUserSsn());
                }
            }
        }

        public static void CoinFlipDistribution(Survey survey, UserList userList)
        {
            Random random = new();
            foreach (User user in userList.GetUsers())
            {
                if (random.Next(0, 2) == 0)
                {
                    User_Survey user_survey = new User_Survey(user, survey);
                    survey.AddUserSurvey(user_survey);
                    user.AddUserSurvey(user_survey);
                    Console.WriteLine(user_survey.GetUserCode() + " | " + user_survey.GetUserSsn());
                }
            }
        }

        public static void DistributeToAll(Survey survey, UserList userList)
        {
            foreach (User user in userList.GetUsers())
            {
                User_Survey user_survey = new User_Survey(user, survey);
                survey.AddUserSurvey(user_survey);
                user.AddUserSurvey(user_survey);
                Console.WriteLine(user_survey.GetUserCode() + " | " + user_survey.GetUserSsn());
            }
        }

        private static int getAge(User user)
        {
            int yearBorn = Convert.ToInt32(user.Ssn.Substring(0, 4));
            int age = DateTime.Now.Year - yearBorn;
            return age;
        }

    }
}