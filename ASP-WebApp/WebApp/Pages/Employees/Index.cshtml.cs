using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {

        public List<EmployeeInfo> Employees = new List<EmployeeInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-BFK55O4;Initial Catalog=clients;Integrated Security=True";
               
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM EMPLOYEES";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                EmployeeInfo info = new EmployeeInfo();
                                info.id = reader.GetInt32(0);
                                info.name = reader.GetString(1);
                                info.maas = reader.GetString(2);
                                info.mesai = reader.GetString(3);
                                info.derece = reader.GetString(4);

                                Employees.Add(info);
                            }
                        }
                    }
                }
            
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public class EmployeeInfo 
        {
            public int id;
            public String name;
            public String maas;
            public String mesai;
            public String derece;
        }

    }
}
