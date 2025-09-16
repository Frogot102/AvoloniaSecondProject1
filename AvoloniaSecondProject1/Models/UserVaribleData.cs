using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvoloniaSecondProject1.Data;

namespace AvoloniaSecondProject1.Models
{
    static class UserVaribleData
    {
        public static User selectedUserInMainWindow { get; set; }
        public static Item selectedItemInMainWindow { get; set; }
        public static Bascket selectedBacketInMainWindow { get; set; }
        public static Login selectedLoginInMainWindow { get; set; }
    }
}
