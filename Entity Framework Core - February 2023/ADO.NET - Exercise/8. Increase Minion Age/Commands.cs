using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._Increase_Minion_Age
{
    internal static class Commands
    {
        public static string connectionString = @"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;TrustServerCertificate=True";


        public static string selectMinions = @"SELECT Name, Age FROM Minions";

        public static string updateRecords = @" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";


    }
}
