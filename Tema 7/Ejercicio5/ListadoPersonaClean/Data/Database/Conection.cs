using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    internal class Conection
    {
        public static string getConnectionString()
        {
            return "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";
        }
    }
}