using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAnimate.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public decimal precioCosto { get; set; }
        public decimal precioVenta { get; set; }
        public string urlImagenProd { get; set; }
    }
}
