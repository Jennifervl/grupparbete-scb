using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyLib
{
    public static class Distributor
    {

        public static int DistributeByAge(Survey survey, UserRepository userRepository, User_Survey_Repository usr, int minAge = 18, int maxAge = 999)
        {

            int count = 0;
            List<User> users = CheckIfDistributed(usr, userRepository, survey);

            foreach (User user in userRepository.GetUsers())
            {
                foreach (User_Survey us in usr.GetUser_Surveys())
                {
                    if (!(users.Contains(user)))
                    {
                        if (user.getAge() >= minAge && user.getAge() <= maxAge)
                        {
                            User_Survey user_survey = new User_Survey(user, survey);
                            usr.AddUserSurvey(user_survey);
                            usr.SaveUser_Survey(user_survey);
                            count++;
                        }
                    }
                }
            }
            users.Clear();
            return count;
        }

        public static int CoinFlipDistribution(Survey survey, UserRepository userRepository, User_Survey_Repository usr)
        {
            Random random = new();
            int count = 0;
            List<User> users = CheckIfDistributed(usr, userRepository, survey);
            foreach (User user in userRepository.GetUsers())
            {
                if (!(users.Contains(user)))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        User_Survey user_survey = new User_Survey(user, survey);
                        usr.AddUserSurvey(user_survey);
                        usr.SaveUser_Survey(user_survey);
                        count++;
                    }
                }
            }
            users.Clear();
            return count;
        }

        public static int DistributeToAll(Survey survey, UserRepository userRepository, User_Survey_Repository usr)
        {
            int count = 0;
            List<User> users = CheckIfDistributed(usr, userRepository, survey);

            foreach (User user in userRepository.GetUsers())
            {
                if (!(users.Contains(user)))
                {
                    User_Survey user_survey = new User_Survey(user, survey);
                    usr.AddUserSurvey(user_survey);
                    usr.SaveUser_Survey(user_survey);
                    count++;
                }
            }
            return count;
        }

        private static List<User> CheckIfDistributed(User_Survey_Repository usr, UserRepository userRepository, Survey survey)
        {
            List<User> users = new();
            foreach (User_Survey us in usr.GetUser_Surveys())
            {
                foreach (User u in userRepository.GetUsers())
                {
                    if ((us.GetUserSsn() == u.Ssn))
                        if (us.GetSurvey().Title == survey.Title) users.Add(u);
                }
            }
            return users;
        }
    }
}