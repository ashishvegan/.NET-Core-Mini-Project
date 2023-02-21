using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicEF
{
    public class ConnectionString
    {
        string connection = "Server=ASHISHL\\SQLEXPRESS01;User Id=;Password=;Database=students;Trusted_Connection=true;TrustServerCertificate=true;";
        public string Conn()
        {
            return connection;
        }
    }
}