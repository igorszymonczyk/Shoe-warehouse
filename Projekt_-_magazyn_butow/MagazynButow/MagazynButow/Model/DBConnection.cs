using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynButow.Model
{
    public class DBConnection
    {
        public string mysql_connection_string = $"Server={Properties.Settings.Default.server};Database={Properties.Settings.Default.database};User ID={Properties.Settings.Default.userID};Password={Properties.Settings.Default.password};SslMode=none;Charset=utf8mb4";
    }
}
