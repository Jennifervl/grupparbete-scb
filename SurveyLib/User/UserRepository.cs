using System;
using System.Collections.Generic;
namespace SurveyLib
{
    public class UserRepository
    {
        private LoadDataManager loadDataManager = new LoadDataManager();
        private SaveDataManager saveDataManager = new SaveDataManager();

        private List<User> userRepository;
        public int userCount;
        public UserRepository()
        {
            userRepository = new();
        }
        public void AddNewUser(User user)
        {
            userRepository.Add(user);
            userCount = userRepository.Count;
        }

        public void LoadUsers()
        {
            // Admin SuperAdmin = new Admin("123123123123", "admin");
            // userRepository.Add(SuperAdmin);

            foreach (User u in loadDataManager.LoadAllUsers())
            {
                userRepository.Add(u);
            }
        }

        public void SaveUser(User user)
        {
            saveDataManager.SaveUser(user);
        }

        public Dictionary<string, string> ListUsers()
        {
            Dictionary<string, string> users = new();
            foreach (User u in userRepository)
            {

                users.Add(u.Ssn, u.GetType().Name);
            }
            return users;
        }

        public IList<User> GetUsers()
        {
            return userRepository.AsReadOnly();
        }
    }
}