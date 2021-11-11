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
        public List<User> GetUsers(List<User> inList)
        {
            foreach (User u in userList)
            {
                inList.Add(u);
            }
            return inList;
        }
    }
}