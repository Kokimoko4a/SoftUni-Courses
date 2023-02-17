using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace _4._Add_Minion
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();
            string[] minionInfo = Console.ReadLine().Split(new Char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameOfMinion = minionInfo[1];
            int ageOfMinion = int.Parse(minionInfo[2]);
            string townOfMinion = minionInfo[3];

            string[] villianInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string villianName = villianInfo[1];

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string addingTown = AddTownIfNeeded(townOfMinion, connection, transaction);
                string addingVilain = AddVillian(villianName, connection, transaction);
                int townId = GetTownId(townOfMinion, connection, transaction);
                AddMinion(nameOfMinion, ageOfMinion, townId, connection, transaction);
                int idOfMinion = GetMinionId(nameOfMinion, townId, connection, transaction);
                int villainId = GetVillainId(villianName, connection, transaction);
                AddMinionToVillain(idOfMinion, villainId, connection, transaction);

                if (addingTown != "")
                {
                    Console.WriteLine(addingTown);
                }

                if (addingVilain != "")
                {
                    Console.WriteLine(addingVilain);
                }

                Console.WriteLine($"Successfully added {nameOfMinion} to be minion of {villianName}.");
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

            }

        }
        static string AddTownIfNeeded(string town, SqlConnection connection, SqlTransaction transaction)
        {


            StringBuilder sb = new StringBuilder();
            SqlCommand getTown = new SqlCommand(Commands.getTown, connection, transaction);
            getTown.Parameters.AddWithValue("@townName", town);

            object? idOfTownObj = getTown.ExecuteScalar();

            if (idOfTownObj == null)
            {
                SqlCommand addTown = new SqlCommand(Commands.insertTown, connection, transaction);
                addTown.Parameters.AddWithValue("@townName", town);
                addTown.ExecuteNonQuery();
                sb.AppendLine($"Town {town} was added to the database.");
            }

            return sb.ToString().TrimEnd();
        }

        static string AddVillian(string name, SqlConnection connection, SqlTransaction transaction)
        {
            StringBuilder sb = new StringBuilder();
            SqlCommand getVillian = new SqlCommand(Commands.getNameOfVillian, connection, transaction);
            getVillian.Parameters.AddWithValue("@Name", name);

            object IdOfVillian = getVillian.ExecuteScalar();

            if (IdOfVillian == null)
            {
                SqlCommand addVillian = new SqlCommand(Commands.insertVillian, connection, transaction);
                addVillian.Parameters.AddWithValue(@"villainName", name);
                addVillian.ExecuteNonQuery();
                sb.AppendLine($"Villain {name} was added to the database.");
            }

            return sb.ToString().TrimEnd();
        }

        static void AddMinion(string name, int age, int townId, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand addMinion = new SqlCommand(Commands.insertMinion, connection, transaction);
            addMinion.Parameters.AddWithValue("@name", name);
            addMinion.Parameters.AddWithValue("@age", age);
            addMinion.Parameters.AddWithValue("@townId", townId);
            addMinion.ExecuteNonQuery();
        }

        static int GetTownId(string name, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand getTown = new SqlCommand(Commands.getTown, connection, transaction);
            getTown.Parameters.AddWithValue("@townName", name);
            object idObj = getTown.ExecuteScalar();
            int id = (int)idObj;
            return id ;
        }
        static void AddMinionToVillain(int minionId, int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand addMinionToVillain = new SqlCommand(Commands.addToMappingTable, connection, transaction);
            addMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
            addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillain.ExecuteNonQuery();
        }

        static int GetMinionId(string name, int townId, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand getMinionId = new SqlCommand(Commands.getMinionId, connection, transaction);
            getMinionId.Parameters.AddWithValue("@Name", name);
            getMinionId.Parameters.AddWithValue("@TownId", townId);
            return (int)getMinionId.ExecuteScalar();
        }

        static int GetVillainId(string name, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand getVillainId = new SqlCommand(Commands.getVillainId, connection, transaction);
            getVillainId.Parameters.AddWithValue("@Name", name);
            return (int)getVillainId.ExecuteScalar();
        }
    }
}