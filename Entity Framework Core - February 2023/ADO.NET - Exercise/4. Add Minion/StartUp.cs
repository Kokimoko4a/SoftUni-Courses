using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Add_Minion
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();
            string[] minionInfo = Console.ReadLine().Split(new Char[] { ':', ' '},StringSplitOptions.RemoveEmptyEntries);
            string nameOfMinion = minionInfo[1];
            int ageOfMinion = int.Parse(minionInfo[2]);
            string townOfMinion = minionInfo[3];

            string[] villianInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string villianName = villianInfo[1];

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string addingTown = AddTownIfNeeded(townOfMinion, connection);
                string addingVilain = AddVillian(villianName, connection);
                int townId = GetTownId(townOfMinion, connection);
                AddMinion(nameOfMinion, ageOfMinion, townId, connection);
                int idOfMinion = GetMinionId(nameOfMinion, townId, connection);
                int villainId = GetVillainId(villianName, connection);
                AddMinionToVillain(idOfMinion, villainId, connection);
                Console.WriteLine(addingTown);
                Console.WriteLine(addingVilain);
                Console.WriteLine($"Successfully added {nameOfMinion} to be minion of {villianName}.");
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                
            }
      
                
        }

        static string AddTownIfNeeded(string town, SqlConnection connection)
        {


            StringBuilder sb = new StringBuilder();
            SqlCommand getTown = new SqlCommand(Commands.getTown, connection);
            getTown.Parameters.AddWithValue("@townName", town);

            object? idOfTownObj = getTown.ExecuteScalar();

            if (idOfTownObj == null)
            {
                SqlCommand addTown = new SqlCommand(Commands.insertTown, connection);
                addTown.Parameters.AddWithValue("@townName", town);
                addTown.ExecuteNonQuery();
                sb.AppendLine($"Town {town} was added to the database.");
            }

            return sb.ToString().TrimEnd();
        }

        static string AddVillian(string name, SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            SqlCommand getVillian = new SqlCommand(Commands.getNameOfVillian, connection);
            getVillian.Parameters.AddWithValue("@Name", name);

            object IdOfVillian = getVillian.ExecuteScalar();

            if (IdOfVillian == null) 
            {
                SqlCommand addVillian = new SqlCommand(Commands.insertVillian, connection);
                addVillian.Parameters.AddWithValue(@"villainName", name);
                addVillian.ExecuteNonQuery();
                sb.AppendLine($"Villain {name} was added to the database.");
            }

            return sb.ToString().TrimEnd(); 

        }

        static void AddMinion(string name,int age,int townId, SqlConnection connection)
        {
            SqlCommand addMinion = new SqlCommand(Commands.insertMinion,connection);
            addMinion.Parameters.AddWithValue("@name",name);
            addMinion.Parameters.AddWithValue("@age",age);
            addMinion.Parameters.AddWithValue("@townId",townId);
            addMinion.ExecuteNonQuery();
        }

        static int GetTownId(string name, SqlConnection connection)
        {
            SqlCommand getTown = new SqlCommand(Commands.getTown, connection);
            getTown.Parameters.AddWithValue("@townName", name);
            object id = getTown.ExecuteScalar();
            int ddd = (int) id;
            return ddd;
        }
        static void AddMinionToVillain(int minionId, int villainId,SqlConnection connection)
        {
            SqlCommand addMinionToVillain = new SqlCommand(Commands.addToMappingTable, connection);
            addMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
            addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillain.ExecuteNonQuery();
        }

        static int GetMinionId(string name,int townId, SqlConnection connection)
        { 
            SqlCommand getMinionId = new SqlCommand(Commands.getMinionId, connection);
            getMinionId.Parameters.AddWithValue("@Name", name);
            getMinionId.Parameters.AddWithValue("@TownId", townId);
            return (int)getMinionId.ExecuteScalar();
        }

        static int GetVillainId(string name, SqlConnection connection)
        {
            SqlCommand getVillainId = new SqlCommand(Commands.getVillainId, connection);
            getVillainId.Parameters.AddWithValue("@Name", name);
            return (int)getVillainId.ExecuteScalar();
        }
    }
}