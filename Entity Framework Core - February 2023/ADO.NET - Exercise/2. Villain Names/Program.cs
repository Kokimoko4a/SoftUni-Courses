using System.Data.SqlClient;

namespace _2._Villain_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT v.Name\r\n\t\t,COUNT(*) \r\n\t\tAS [Count]\r\n FROM Villains AS v\r\n JOIN MinionsVillains AS mv\r\n ON\r\n v.Id = mv.VillainId\r\n JOIN Minions AS m\r\n ON\r\n mv.MinionId = m.Id\r\n GROUP BY v.Name\r\n HAVING COUNT(*) > 3\r\n ORDER BY COUNT(*) DESC", connection);

                SqlDataReader read = command.ExecuteReader();

                using (read)
                {
                    while (read.Read())
                    {
                        Console.WriteLine($"{read["Name"]} - {read["Count"]}");
                    }
                }
            }
        }
    }
}