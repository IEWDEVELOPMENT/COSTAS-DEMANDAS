using COSTAS_DEMANDAS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace COSTAS_DEMANDAS.Soluciones
{
    public class RepositorioCosta
    {
        public dynamic Obtener(string Obligacion)
        {
            try
            {

                var consulta = new List<dynamic>();

                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ups_ObtenerObligacionMonitor", conexion); //Comandos a ejecutar 
                    cmd.Parameters.AddWithValue("@NumeroObligacion", Obligacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())

                    {
                        while (dr.Read())
                        {
                            consulta.Add(new
                            {

                                NUMERO_SAPRO = Convert.ToString(dr["NUMERO_SAPRO"] is DBNull ? 0 : dr["NUMERO_SAPRO"]),
                                IDENTIFICACION_CLIENTE = Convert.ToString(dr["IDENTIFICACION_CLIENTE"] is DBNull ? 0 : dr["IDENTIFICACION_CLIENTE"]),
                                NOMBRE_TITULAR = Convert.ToString(dr["NOMBRE_TITULAR"] is DBNull ? "" : dr["NOMBRE_TITULAR"]),
                                NOMBRE_RECUPERADOR_JURIDICO = Convert.ToString(dr["NOMBRE_RECUPERADOR_JURIDICO"] is DBNull ? "" : dr["NOMBRE_RECUPERADOR_JURIDICO"]),
                                TIPO_PROCESO_JURIDICO = Convert.ToString(dr["TIPO_PROCESO_JURIDICO"] is DBNull ? "" : dr["TIPO_PROCESO_JURIDICO"]),

                            });
                        }

                    }

                }
                return consulta;
            }
            catch (Exception e)
            {
                return e;

            }

        }

        public dynamic Guardar(List<CostaModel> COSTAS)
        {
            bool rpta;

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();

                    foreach (var COSTA in COSTAS)
                    {
                        SqlCommand cmd = new SqlCommand("ups_GuardarObligacionCosta", conexion); //Comandos a ejecutar 
                        cmd.Parameters.AddWithValue("@NRO_DE_CREDITO", COSTA.NRO_DE_CREDITO);
                        cmd.Parameters.AddWithValue("@ETAPA", COSTA.ETAPA);
                        cmd.Parameters.AddWithValue("@TIPO_DE_COSTA", COSTA.TIPO_DE_COSTA);
                        cmd.Parameters.AddWithValue("@FECHA_COSTA", COSTA.FECHA_COSTA);
                        cmd.Parameters.AddWithValue("@VALOR_DE_LA_COSTA", COSTA.VALOR_DE_LA_COSTA);
                        cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO_DE_COBRO", COSTA.TIPO_DOCUMENTO_DE_COBRO);
                        cmd.Parameters.AddWithValue("@NRO_DE_DOCUMENTO", COSTA.NRO_DE_DOCUMENTO);
                        cmd.Parameters.AddWithValue("@NOMBRE_DEL_PROVEEDOR", COSTA.NOMBRE_DEL_PROVEEDOR);
                        cmd.Parameters.AddWithValue("@OBSERVACIONES", COSTA.OBSERVACIONES); // Corregir el nombre del parámetro aquí
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

    }


}



