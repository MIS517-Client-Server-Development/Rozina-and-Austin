using System.Data.SqlClient;
using System.Web.Configuration;

namespace UniversityManagementApp.DBGateway
{
    public class Gateway
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementDBConnectionString"].ConnectionString;
        protected SqlConnection connection;
    }
}