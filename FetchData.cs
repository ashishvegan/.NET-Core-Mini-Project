using Microsoft.Data.SqlClient;
namespace BasicEF
{
    public class FetchData
    {
        public void DisplayStudents()
        {
            var ConnectionObject = new ConnectionString();
            var connectionString = ConnectionObject.Conn();
            //Console.WriteLine(ConnectionString);
          //string connectionString = "Server=ASHISHL\\SQLEXPRESS01;User Id=;Password=;Database=students;Trusted_Connection=true;TrustServerCertificate=true;";
                
                string query = "SELECT * FROM Students";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\n\n\t\t\t\tS A V E D     R E C O R D S");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("\n\t\t\t{0} [{1}]", reader["FullName"], reader["Email"]));
                    }
                     Console.WriteLine("\n\n\n\n\n");
                }
        }
    }
}