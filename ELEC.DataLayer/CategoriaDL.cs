using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ELEC.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace ELEC.DataLayer
{
    public class CategoriaDL
    {
        public List<Categoria> Lista()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_categorias()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["id_categoria"].ToString()),
                                NombreCategoria = dr["nombre_categoria"].ToString()
                            });
                        }
                    }
                    return lista;
                } catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
