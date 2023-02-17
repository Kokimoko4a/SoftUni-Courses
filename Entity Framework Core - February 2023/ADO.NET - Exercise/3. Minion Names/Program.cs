using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _3._Minion_Names
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Commands.connectionString);

            connection.Open();

            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                string nameOfVillian = GetNameOfVillian(id, connection);

                if (nameOfVillian == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                else 
                {
                    Console.WriteLine($"Villain: {nameOfVillian}");
                }

                string minionsNames = GetMinions(id, connection);

                Console.WriteLine(minionsNames);
            }
        }


        public static string GetNameOfVillian(int id,SqlConnection connection)
        {
            SqlCommand getName = new SqlCommand(Commands.getNameOfVillian, connection);
            getName.Parameters.AddWithValue("@Id", id);
            string nameOfVillian = (string)getName.ExecuteScalar();
            return nameOfVillian;
        }

        public static string GetMinions(int id, SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getMinions = new SqlCommand(Commands.getMinions,connection);

            getMinions.Parameters.AddWithValue("@Id", id);

            SqlDataReader read = getMinions.ExecuteReader();

            if (!read.HasRows)
            {
                return "(no minions)";
            }

            while (read.Read())
            {
                long rowNumber = (long)read["RowNum"];
                string nameOfMinion = (string)read["Name"];
                int age = (int)read["Age"];

                sb.AppendLine($"{rowNumber}. {nameOfMinion} {age}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
