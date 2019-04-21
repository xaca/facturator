using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Program {
        static void Main(string[] args) {

            Caja caja = new Caja();
            
            LectorArchivo temp = new LectorArchivo();
            caja.Facturas = temp.cargarFacturas();
            caja.ImprimirFactura(5);//REvisar que pasa con la factura 4
            Console.ReadKey();         
        }
    }
}
