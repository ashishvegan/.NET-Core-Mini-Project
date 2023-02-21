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
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter Email Id: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string plainPassword = Console.ReadLine();
            string password = GenerateHMACSHA512(plainPassword, "Area51");
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
             FetchData AllStudents = new FetchData();   
             AllStudents.DisplayStudents();

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
