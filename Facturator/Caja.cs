using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Caja {
        private Factura[] facturas;

        public Caja() 
        {

        }

        public Factura[] Facturas { get => facturas; set => facturas = value; }

        public void ImprimirFactura(int id_factura)
        {
            Factura f = facturas[id_factura];
            f.MostrarProducto(0);
        }
    }
}
