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
            // User testAdminUser = new User("199001014444", UserRoles.Admin);
            // User testUserUser = new User("198002025555", UserRoles.Participant);
            // this.AddNewUser(testAdminUser);
            // this.AddNewUser(testUserUser);
            foreach (User u in loadDataManager.LoadAllUsers())
            {
                userRepository.Add(u);
            }
        }

        public void SaveUser(User user)
        {
            saveDataManager.SaveUser(user);
        }

        public Dictionary<string, Type> ListUsers()
        {
            Dictionary<string, Type> users = new();
            foreach (User u in userRepository)
            {

                users.Add(u.Ssn, u.GetType());
            }
            return users;
        }
        public IList<User> GetUsers()
        {
            return userRepository.AsReadOnly();
        }
    }
}