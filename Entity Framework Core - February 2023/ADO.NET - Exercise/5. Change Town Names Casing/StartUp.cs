using Microsoft.Data.SqlClient;
using System.Text;

namespace _5._Change_Town_Names_Casing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Commands.connectionString);
            connection.Open();

            string? country = Console.ReadLine();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                Console.WriteLine(UpperTowns(country,connection,transaction));
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

        }

        static string UpperTowns(string country, SqlConnection connection, SqlTransaction transaction)
        {
            StringBuilder sb = new StringBuilder();
            List<string> townsAffected = new List<string>();

            SqlCommand upperTowns = new SqlCommand(Commands.upperTowns, connection, transaction);
            upperTowns.Parameters.AddWithValue("@countryName", country);

            int countOfAffectedTowns = upperTowns.ExecuteNonQuery();

            if (countOfAffectedTowns == 0)
            {
                return "No town names were affected.";
            }

            sb.AppendLine($"{countOfAffectedTowns} town names were affected.");

            SqlCommand selectTowns = new SqlCommand(Commands.selectTowns, connection, transaction);
            selectTowns.Parameters.AddWithValue("@countryName", country);

          using  SqlDataReader read = selectTowns.ExecuteReader();

            while (read.Read())
            {
                townsAffected.Add((string)read["Name"]);
            }

            sb.AppendLine($"[{string.Join(", ", townsAffected)}]");

            return sb.ToString().TrimEnd();
        }
    }
}