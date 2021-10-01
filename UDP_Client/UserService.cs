using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    static class UserService
    {
        public static User FormUser()
        {

            User user = new User();
            Console.Write("Nickname: ");
            user.Nickname = Console.ReadLine();
           

            

            return user;
        }
    }
}
