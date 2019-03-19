using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Factura {
        private string fecha;
        private int estado_actual;
        private string medio_pago;
        private float iva;
        private float total;
        private Producto[] canasta;

        public Factura() {

        }
        public Factura(string fecha, int estado_actual, string medio_pago, float iva, float total) {
            this.fecha = fecha;
            this.estado_actual = estado_actual;
            this.medio_pago = medio_pago;
            this.iva = iva;
            this.total = total;
        }

        public void LlenarProductos() {
            canasta = new Producto[5];

            canasta[0] = new Producto("Leche", 5, 2500);
            canasta[1] = new Producto("Jamon", 1, 4500);
            canasta[2] = new Producto("Pan", 2, 6000);
            canasta[3] = new Producto("Queso", 1, 5200);
            canasta[4] = new Producto("Huevo", 12, 100);
        }
        
        public string Fecha { get => fecha; set => fecha = value; }
        public int Estado_actual { get => estado_actual; set => estado_actual = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        

    }

}
