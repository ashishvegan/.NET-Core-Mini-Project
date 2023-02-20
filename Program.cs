using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
namespace BasicEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Full Name: ");
            string? fullName = Console.ReadLine();
            Console.WriteLine("Enter Email Id: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string? plainPassword = Console.ReadLine();
            string? password = GenerateHMACSHA512(plainPassword, "Area51");
            // Console.WriteLine(password);
            using (var db = new StudentContext())
            {
                var student = new Student
                {
                    FullName = fullName,
                    Email = email,
                    Password = password
                };
                db.Students.Add(student);
                db.SaveChanges();
            }

          


           // Fetch Saved Records
                string connectionString = "Server=ASHISHL\\SQLEXPRESS01;User Id=;Password=;Database=students;Trusted_Connection=true;TrustServerCertificate=true;";
                string query = "SELECT * FROM Students";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", reader["FullName"], reader["Email"]));
                    }
                }

        string GenerateHMACSHA512(string message, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (HMACSHA512 hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(messageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }


}

}
