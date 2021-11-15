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

        public void ListUsers()
        {
            foreach (User u in userList)
            {
                u.UserInfo();
            }
        }
        public List<User> GetUsers()
        {
            return userList;
        }
    }
}