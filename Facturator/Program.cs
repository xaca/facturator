using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Program {
        static void Main(string[] args) {

            Caja caja = new Caja();
            IODatos temp = new IODatos();
            caja.Facturas = temp.cargarFacturas();
            caja.ImprimirFactura(7);
            temp.GuardarFacturas(temp.FormatearLineasFacturas(caja.Facturas));
            //UI.Menu(caja);
            Console.ReadKey();         
        }
    }
}
