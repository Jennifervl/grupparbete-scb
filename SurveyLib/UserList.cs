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
        public void ListUsers()
        {
            foreach (User u in userList)
            {
                u.UserInfo();
            }
        }

        public void GetUsers(List<User> testList)
        {
            throw new NotImplementedException();
        }
    }
}