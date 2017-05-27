using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//REFERENCIA
using Dominio.Entidades;
using Infraestuctura.Data;

namespace Dominio.Repositorio
{
    public class clienteBL
    {
        clienteDAL cliente = new clienteDAL();

        public List<clienteEntidad> listado()
        {
            return cliente.listado();
        }

        public string Agregar(clienteEntidad reg)
        {
            return cliente.Agregar(reg);
        }

        public string Actualizar(clienteEntidad reg)
        {
            return cliente.Actualizar(reg);
        }

        public string Eliminar(clienteEntidad reg)
        {
            return cliente.Eliminar(reg);
        }
    }
}
