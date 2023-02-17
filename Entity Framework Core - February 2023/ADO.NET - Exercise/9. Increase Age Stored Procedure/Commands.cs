using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Increase_Age_Stored_Procedure
{
    internal static class Commands
    {
        public static string connectionString = @"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;TrustServerCertificate=True";

        public static string runStoredProcedure = @"dbo.usp_GetOlder @id";

    }
}
