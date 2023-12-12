using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static WebApp.Pages.Employees.IndexModel;

namespace WebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        public EmployeeInfo employeeInfo = new EmployeeInfo();
        public String errorMessage = "";
        public String confirmMessage = "";
        public void OnGet()
        {
        }

        public void onPost()
        {
            employeeInfo.name = Request.Form["name"];
            employeeInfo.maas = Request.Form["maas"];
            employeeInfo.mesai = Request.Form["mesai"];
            employeeInfo.derece = Request.Form["derece"];
            
            
            if(employeeInfo.name.Length == 0 || employeeInfo.maas.Length == 0 || 
                employeeInfo.mesai.Length == 0 || employeeInfo.derece.Length == 0)
            {
                errorMessage = "Tüm alanlarý doldurun.";
                return;
            }

            try
            {
                string connectionString = "Data Source=DESKTOP-BFK55O4;Initial Catalog=clients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO EMPLOYEES VALUES " + "(@name, @maas, @mesai, @derece);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", employeeInfo.name);
                        command.Parameters.AddWithValue("@maas", employeeInfo.maas);
                        command.Parameters.AddWithValue("@mesai", employeeInfo.mesai);
                        command.Parameters.AddWithValue("@derece", employeeInfo.derece);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return; 
            }

            employeeInfo.name = "";
            employeeInfo.maas = "";
            employeeInfo.mesai = "";
            employeeInfo.derece = "";
            confirmMessage = "Çalýþan baþarýyla eklendi.";

            Response.Redirect("Clients/Index");
        }
    }
}
