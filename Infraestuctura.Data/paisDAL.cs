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
    public class paisDAL
    {
        SqlConnection cn = new SqlConnection(
            "SERVER=.; DATABASE=Negocios2017; uid=sa; pwd=sql");

        public List<paisEntidad> listado()
        {
            List<paisEntidad> lista = new List<paisEntidad>();

            SqlCommand cmd = new SqlCommand("select * from tb_paises", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                paisEntidad reg = new paisEntidad();
                reg.idpais = dr.GetString(0);
                reg.nombrepais = dr.GetString(1);

                lista.Add(reg);
            }

            dr.Close();
            cn.Close();
            
            return lista;
        } 
    }
}
