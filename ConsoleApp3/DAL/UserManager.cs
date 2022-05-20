using ConsoleApp3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.DAL
{
    class UserManager
    {
        private static List<Users> users = new List<Users>();

        public void Add(Users us)
        {
            users.Add(us);
        }

        public void Update(int index, Users us)
        {
            users.Insert(index, us);
        }

        public void Delete(Users us)
        {
            users.Remove(us);
        }

        public List<Users> Show()
        {
            return users;
        }
    }
}
