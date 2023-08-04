using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEC.EntityLayer
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string FechaAlta { get; set; }
        public string FechaBaja { get; set; }
    }
}
