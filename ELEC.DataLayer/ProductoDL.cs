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
    public class ProductoDL
    {
        public List<Producto> Lista()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_productos()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                IdProducto = Convert.ToInt32(dr["id_producto"].ToString()),
                                IdCategoria = new Categoria
                                {
                                    IdCategoria = Convert.ToInt32(dr["id_categoria"].ToString()),
                                    NombreCategoria = dr["nombre_categoria"].ToString()
                                },
                                NombreProducto = dr["nombre_producto"].ToString(),
                                FechaAlta = dr["fechaContrato"].ToString(),
                                FechaBaja = dr["fechaBaja"].ToString(),
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Producto Obtener( int IdProducto )
        {
            Producto entidad = new Producto();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM fn_producto(@idProducto)", oConexion);
                cmd.Parameters.AddWithValue("@idProducto", IdProducto);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdProducto = Convert.ToInt32(dr["id_producto"].ToString());
                            entidad.IdCategoria = new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["id_categoria"].ToString()),
                                NombreCategoria = dr["nombre_categoria"].ToString()
                            };
                            entidad.NombreProducto = dr["nombre_producto"].ToString();
                            entidad.FechaAlta = dr["fechaContrato"].ToString();
                            entidad.FechaBaja = dr["fechaBaja"].ToString();
                        }
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Crear(Producto entidad)
        {
            bool res = false;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_crearProducto", oConexion);
                cmd.Parameters.AddWithValue("@NombreProducto", entidad.NombreProducto);
                cmd.Parameters.AddWithValue("@IdCategoria", entidad.IdCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@FechaAlta", entidad.FechaAlta);
                cmd.Parameters.AddWithValue("@FechaBaja", entidad.FechaBaja);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int fila = cmd.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        res = true;
                    }
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Editar(Producto entidad)
        {
            bool res = false;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_editarProducto", oConexion);
                cmd.Parameters.AddWithValue("@IdProducto", entidad.IdProducto);
                cmd.Parameters.AddWithValue("@NombreProducto", entidad.NombreProducto);
                cmd.Parameters.AddWithValue("@IdCategoria", entidad.IdCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@FechaAlta", entidad.FechaAlta);
                cmd.Parameters.AddWithValue("@FechaBaja", entidad.FechaBaja);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();

                    int fila = cmd.ExecuteNonQuery();

                    if (fila > 0)
                    {
                        res = true;
                    }
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Eliminar(int IdProducto)
        {
            bool res = false;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_eliminarProducto", oConexion);
                cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();

                    int fila = cmd.ExecuteNonQuery();

                    if (fila > 0)
                    {
                        res = true;
                    }
                    return res;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
