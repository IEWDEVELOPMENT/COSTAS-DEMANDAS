using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace COSTAS_DEMANDAS
{
    public class Contraseña
    {
        public static string CifrarContraseña(string contraseña)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(contraseña);
            byte[] inArray = HashAlgorithm.Create("SHA1")!.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
