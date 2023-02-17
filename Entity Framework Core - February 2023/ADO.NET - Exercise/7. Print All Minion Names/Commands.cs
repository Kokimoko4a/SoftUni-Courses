using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._Print_All_Minion_Names
{
    internal static class Commands
    {
        public static string connectionString = @"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=True";

        public static string selectNames = @"SELECT Name FROM Minions";

    }
}
