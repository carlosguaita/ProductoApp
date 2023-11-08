using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Models
{
    class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int cantidad { get; set; }
    }
}
