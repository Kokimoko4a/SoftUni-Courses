using Microsoft.Data.SqlClient;

namespace _8._Increase_Minion_Age
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();

            int[]? iDs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            for (int i = 0; i < iDs.Length; i++)
            {
                SqlCommand updateRecords = new SqlCommand(Commands.updateRecords, connection);
                updateRecords.Parameters.AddWithValue("@Id", iDs[i]);
                updateRecords.ExecuteNonQuery();
            }

            SqlCommand selectMinions = new SqlCommand(Commands.selectMinions, connection);

            using SqlDataReader read = selectMinions.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine($"{read["Name"]} {read["Age"]}");
            }
        }
    }
}