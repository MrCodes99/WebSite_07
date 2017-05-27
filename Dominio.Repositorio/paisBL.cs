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
    public class paisBL
    {
        paisDAL pais = new paisDAL();
        
        public List<paisEntidad> listado()
        {
            return pais.listado();
        }   
    }
}
