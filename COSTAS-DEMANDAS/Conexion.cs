using System.Data.SqlClient; // agrego paquete NUGET

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace COSTAS_DEMANDAS
{
    public class Conexion
    {
        private string CadenaSQL = string.Empty;

        public Conexion() //Constructor, primer metodo que se ejecuta
        {
            //creamos variable var que permite determinar el tipo de dato 

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();  //Voy a obtener la cadena de conexion de mi archivo .json
            
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return CadenaSQL;

        }
       
    }
}
