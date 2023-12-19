using DataManagementTools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableware
{
    static internal class ManageManufacturer
    {
        public static string[] Manufacturer()
        {
            List<string> manufacturer = new List<string>();
            ManageData data = new ManageData();
            SqlDataReader reader = data.SqlRequestReader("select Manufacturer from [Product] " +
                "group by Manufacturer");
            while(reader.Read())
            {
                manufacturer.Add(reader.GetString(0));
            }
            return manufacturer.ToArray();
        }
    }
}
