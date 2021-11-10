using System.Collections.Generic;

namespace SurveyLib
{
    public class User
    {
        private List<User> users;
        UserRoles userRoles;
        private string ssn;
        public int userCount;
        public string Ssn
        {
            get
            {
                return ssn;
            }
        }
        public User(string assn, UserRoles auserRoles)
        {
            this.ssn = assn;
            this.userRoles = auserRoles;
        }
        public void AddNewUser(User user)
        {
            users.Add(user);
            userCount = users.Count;
        }
        public List<User> ListUsers()
        {
            List<User> userList = new();
            foreach (User u in users)
            {
                userList.Add(u);
            }
            return userList;
        }
    }
}
