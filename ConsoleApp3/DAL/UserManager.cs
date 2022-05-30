using ConsoleApp3.DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3.DAL
{
    class UserManager
    {
        private static List<Users> users = new List<Users>();

        public static void Add(Users us, String lista)
        {

            StreamWriter listado = new StreamWriter(lista, true);
            listado.WriteLine(us.ToString());
            listado.Close();
        }

        public static void Update(int index, Users us)
        {
            users.Insert(index, us);
        }

        public static void Delete(Users us)
        {
            users.Remove(us);
        }

        public static List<Users> Show()
        {
            return users;
        }
        
    }
}
