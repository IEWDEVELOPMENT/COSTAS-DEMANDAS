using COSTAS_DEMANDAS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace COSTAS_DEMANDAS.Soluciones
{
    public class RepositorioUsuarios
    {
        public dynamic RegistrarUsuario(string nombreUsuario, string contraseña)
        {
            string contraseñaCifrada = Contraseña.CifrarContraseña(contraseña);

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ups_RegistrarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.Add("@Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    bool registrado = Convert.ToBoolean(cmd.Parameters["@Registrado"].Value);
                    string mensaje = Convert.ToString(cmd.Parameters["@Mensaje"].Value);

                    return new { Registrado = registrado, Mensaje = mensaje };
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public dynamic ValidarUsuario(string nombreUsuario, string contraseña)
        {
            string contraseñaCifrada = Contraseña.CifrarContraseña(contraseña);

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ups_ValidarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int id = Convert.ToInt32(result);
                        return new { Id = id };
                    }
                    else
                    {
                        return new { Id = 0 };
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


    }
}
