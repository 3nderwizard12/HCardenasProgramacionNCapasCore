using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {
            return "Data Source=.;Initial Catalog=HCardenasProgramcionNCapas;Persist Security Info=True;Encrypt=false;TrustServerCertificate=true;User ID=sa;Password=pass@word1;";
            //return ConfigurationManager.ConnectionStrings["HCardenasProgramcionNCapas"].ToString();
        }
    }
}
