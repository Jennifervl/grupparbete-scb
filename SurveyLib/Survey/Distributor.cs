using System;
using System.Collections.Generic;

namespace SurveyLib
{
    public static class Distributor
    {

        public static void DistributeByAge(Survey survey, UserRepository userRepository, User_Survey_Repository usr, int minAge = 18, int maxAge = 999)
        {
            foreach (User user in userRepository.GetUsers())
            {
                if (user.getAge() >= minAge && user.getAge() <= maxAge)
                {
                    User_Survey user_survey = new User_Survey(user, survey);
                    usr.AddUserSurvey(user_survey);
                    usr.SaveUser_Survey(user_survey);
                }
            }
        }

        public static void CoinFlipDistribution(Survey survey, UserRepository userRepository, User_Survey_Repository usr)
        {
            Random random = new();
            foreach (User user in userRepository.GetUsers())
            {
                if (random.Next(0, 2) == 0)
                {
                    User_Survey user_survey = new User_Survey(user, survey);
                    usr.AddUserSurvey(user_survey);
                    usr.SaveUser_Survey(user_survey);
                }
            }
        }

        public static void DistributeToAll(Survey survey, UserRepository userRepository, User_Survey_Repository usr)
        {
            foreach (User user in userRepository.GetUsers())
            {
                User_Survey user_survey = new User_Survey(user, survey);
                usr.AddUserSurvey(user_survey);
                usr.SaveUser_Survey(user_survey);
            }
        }
    }
}