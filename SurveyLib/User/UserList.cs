using System;
using System.Collections.Generic;
namespace SurveyLib
{
    public class UserList
    {
        private List<User> userList;
        public int userCount;
        public UserList()
        {
            userList = new();
        }
        public void AddNewUser(User user)
        {
            userList.Add(user);
            userCount = userList.Count;
        }

        public void LoadUsers()
        {
            User testAdminUser = new User("199001014444", UserRoles.Admin);
            User testUserUser = new User("198002025555", UserRoles.Participant);
            this.AddNewUser(testAdminUser);
            this.AddNewUser(testUserUser);
        }

        public Dictionary<string, UserRoles> ListUsers()
        {
            Dictionary<string, UserRoles> users = new();
            foreach (User u in userList)
            {
                users.Add(u.GetUserSsn(), u.GetUserRole());
            }
            return users;
        }
        public IList<User> GetUsers()
        {
            return userList.AsReadOnly();
        }
    }
}