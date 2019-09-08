using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            // using System.Data.SqlClient;
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Csharp_prj\\At_001\\ConsoleApplication9\\ConsoleApplication9\\Database2.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string SQLQuery = "SELECT Surname FROM Employees WHERE Age<23";
            string Result="Initial";

            List<string> ResultArray = new List<string>();
            //SqlCommand mycommand = new SqlCommand(SQLQuery, conn);
            //Result = (string)mycommand.ExecuteScalar();

            /**** It works. Single word return asa the result ****
            using (SqlCommand mycommand = new SqlCommand(SQLQuery, conn))
            {
                Result = (string)mycommand.ExecuteScalar();
            }
            */

            using (SqlCommand mycommand = new SqlCommand(SQLQuery, conn))
            {
                using (SqlDataReader reader = mycommand.ExecuteReader())
                    while (reader.Read())
                    {
                        ResultArray.Add((string)reader[0]);
                    }
            }

            conn.Close();
            //Console.WriteLine(Result);

            foreach (string i in ResultArray)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
