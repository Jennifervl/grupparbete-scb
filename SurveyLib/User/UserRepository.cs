using System;
using System.Collections.Generic;
namespace SurveyLib
{
    public class UserRepository
    {
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
            User testAdminUser = new User("199001014444", UserRoles.Admin, "admin");
            User testUserUser = new User("198002025555", UserRoles.Participant);
            this.AddNewUser(testAdminUser);
            this.AddNewUser(testUserUser);
        }

        public Dictionary<string, UserRoles> ListUsers()
        {
            Dictionary<string, UserRoles> users = new();
            foreach (User u in userRepository)
            {
                users.Add(u.Ssn, u.GetUserRole());
            }
            return users;
        }
        public IList<User> GetUsers()
        {
            return userRepository.AsReadOnly();
        }
    }
}