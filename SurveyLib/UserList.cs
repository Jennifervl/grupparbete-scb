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
        public List<User> ListUsers()
        {
            List<User> userList = new();
            foreach (User u in userList)
            {
                userList.Add(u);
            }
            return userList;
        }
    }
}