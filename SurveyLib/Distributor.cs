using System;
using System.Collections.Generic;

namespace SurveyLib
{
    public static class Distributor
    {
        public static void DistributeByAge(Survey survey, UserList userList, int minAge = 18, int maxAge = 999)
        {
            foreach (User user in userList.GetUsers())
            {
                if (user.getAge() >= minAge && user.getAge() <= maxAge)
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

        public static Dictionary<string, string> GetAllDistributions(UserList userlist)
        {
            Dictionary<string, string> distributions = new();
            foreach (User user in userlist.GetUsers())
            {
                foreach (User_Survey userservey in user.GetUserSurveys())
                {
                    if (userservey.GetUserSsn() == user.Ssn) distributions.Add(userservey.GetUserCode(), userservey.GetUserSsn());
                }

            }
            return distributions;
        }

    }
}