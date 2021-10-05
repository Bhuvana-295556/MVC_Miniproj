using DailyDAL;
using DailyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyBL
{
    public class UserBL
    {
        UserDAL dalObj = new UserDAL();
        public List<UserDTO> GetAllUser()
        {
            return dalObj.FetchAllUser();
        }
        public List<UserDTO> GetUserByName(string name)
        {
            return dalObj.FetchUserByName(name);

        }
        public int AddNewUser(UserDTO dtObj)
        {
            return dalObj.InsertUser(dtObj);
        }
    }
}
