using Microsoft.Data.SqlClient;

namespace _9._Increase_Age_Stored_Procedure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            SqlCommand runStoredProcedure = new SqlCommand(Commands.runStoredProcedure, connection);

            runStoredProcedure.Parameters.AddWithValue("@id", id);
            
            using SqlDataReader read = runStoredProcedure.ExecuteReader();

            read.Read();
            string name = (string)read["Name"];
            int age = (int)read["Age"];

            Console.WriteLine($"{name} – {age} years old");

        }
    }
}