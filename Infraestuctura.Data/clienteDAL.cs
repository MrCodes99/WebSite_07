using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//REFERENCIA
using Dominio.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Infraestuctura.Data
{
    public class clienteDAL
    {
        SqlConnection cn = new SqlConnection(
            "SERVER=.; DATABASE=Negocios2017; uid=sa; pwd=sql");

        public string Agregar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();
            
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tb_clientes values(@cod,@nom,@dir,@pais,@fono)", cn);
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@fono", reg.telefono);

                cmd.ExecuteNonQuery();
                msj = "Registro exitoso";
            }
            catch(SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }
            return msj;
        }

        public string Actualizar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("update tb_clientes set nombrecia = @nom, direccion = @dir," +
                                                "idpais = @pais, telefono = @fono where idcliente = @cod", cn);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@fono", reg.telefono);
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                cmd.ExecuteNonQuery();
                msj = "Registro actualizado";
            }
            catch (SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }
            return msj;
        }

        public string Eliminar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("delete from tb_clientes where idcliente = @cod", cn);
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                cmd.ExecuteNonQuery();
                msj = "Registro eliminado";
            }
            catch (SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }
            return msj;
        }

        public List<clienteEntidad> listado()
        {
            List<clienteEntidad> lista = new List<clienteEntidad>();
       
                SqlCommand cmd = new SqlCommand("select * from tb_clientes",cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    clienteEntidad reg = new clienteEntidad();
                    reg.idcliente = dr.GetString(0);
                    reg.nombrecia = dr.GetString(1);
                    reg.direccion = dr.GetString(2);
                    reg.idpais = dr.GetString(3);
                    reg.telefono = dr.GetString(4);

                  lista.Add(reg);
                }

            dr.Close();
            cn.Close();
           
            return lista;
        }
    }
}
