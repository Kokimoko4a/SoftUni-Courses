using Microsoft.Data.SqlClient;

namespace _7._Print_All_Minion_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();

            List<string> names = new List<string>();
            SqlCommand command = new SqlCommand(Commands.selectNames, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                names.Add((string)reader["Name"]);
            }

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count-i-1]);
            }

        }
    }
}