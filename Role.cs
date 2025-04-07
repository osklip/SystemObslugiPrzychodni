using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemObslugiPrzychodni
{
    public class Role
    {
        public int role_id { get; set; }
        public string name { get; set; }

        public static List<Role> roles = new List<Role>
        {
            new Role { role_id = 0, name = "User" },
            new Role { role_id = 1, name = "Admin" },
        };

        //lista uprawnien
    }

}
