using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._Add_Minion
{
    internal static class Commands
    {
        public static string connectionString = @"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=True";

        public static string getNameOfVillian = @"SELECT Id FROM Villains WHERE Name = @Name";

        public static string getTown = @"SELECT Id FROM Towns WHERE Name = @townName";

        public static string insertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public static string insertVillian = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public static string insertMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public static string addToMappingTable = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public static string getMinionId = @"SELECT Id FROM Minions WHERE Name = @Name AND TownId = @TownId";

        public static string getVillainId = @"SELECT Id FROM Villains WHERE Name = @Name";



    }
}
