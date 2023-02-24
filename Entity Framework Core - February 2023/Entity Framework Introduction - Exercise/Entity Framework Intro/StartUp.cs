using SoftUni;
using Microsoft.EntityFrameworkCore;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                    x.EmployeeId
                })
                .OrderBy(x => x.EmployeeId).ToArray();


            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new { x.FirstName, x.Salary })
                .Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x=> new {x.Salary,x.Department , x.FirstName, x.LastName })
                .Where(x => x.Department.Name == "Research and Development").OrderBy(x=>x.Salary)
                .ThenByDescending(x=>x.FirstName).ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from Research and Development - ${item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
