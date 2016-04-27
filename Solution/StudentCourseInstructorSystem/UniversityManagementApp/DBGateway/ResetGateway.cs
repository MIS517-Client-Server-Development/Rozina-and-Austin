using System.Data.SqlClient;

namespace UniversityManagementApp.DBGateway
{
    public class ResetGateway : Gateway
    {
        public void Reset(string tblName)
        {
            string query = "UPDATE " + tblName + " SET IsCurrent =0 WHERE IsCurrent=1";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}