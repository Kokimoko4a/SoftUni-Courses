using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Minion_Names
{
    internal static class Commands
    {
        public static string connectionString = @"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        public static string getNameOfVillian = @"SELECT Name FROM Villains WHERE Id = @Id";

        public static string getMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

    }
}
