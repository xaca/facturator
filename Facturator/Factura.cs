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
        private int indice;
        private string nombre_negocio;
        private int numero_factura;

        public Factura() {
            
        }

        public Factura(int cantidad_productos)
        {
            canasta = new Producto[cantidad_productos];
        }

        public Factura(string fecha, int estado_actual, string medio_pago, float iva, float total) {
            this.fecha = fecha;
            this.estado_actual = estado_actual;
            this.medio_pago = medio_pago;
            this.iva = iva;
            this.total = total;
        }

        public void MostrarProducto(int indice)
        {
            int cantidad = canasta[indice].Cantidad;
            Console.Write(canasta[indice].Nombre);
            Console.Write(cantidad);
            Console.WriteLine(canasta[indice].Precio*cantidad);

        }

        public void ImprimirCabezote()
        {
            Utilitario.ImprimirSeparador('*',30);
            Console.WriteLine(nombre_negocio);
            Console.WriteLine("#"+numero_factura);
            Utilitario.ImprimirSeparador('*', 30);
        }

        public void ImprimirTirilla()
        {
            ImprimirCabezote();

            //Pendiente calcular espacios y formato segun el nombre del producto

            for (int i = 0; i < indice; i++)
            {
                MostrarProducto(i);
            }
        }

        public void AgregarProducto(Producto producto) {
            
            if(indice+1 < canasta.Length)
            {
                canasta[indice++] = producto; 
            }
        }

        public void AgregarProducto(string nombre,float precio, int cantidad)
        {
            AgregarProducto(new Producto(nombre, precio, cantidad));
        }

        public void AgregarProductos(string[] nombres,string[] precios)
        {
            float precio;
            int cantidad;
            string[] precio_cantidad;

            for (int i = 0; i < nombres.Length; i++)
            {                
                precio_cantidad = Utilitario.SepararCadena(precios[i], LectorArchivo.SEPARADOR_CANTIDAD);
                precio = Utilitario.ConvertirFlotante(precio_cantidad[0]);
                cantidad = Utilitario.ConvertirEntero(precio_cantidad[1]);

                if(precio > 0 && cantidad>0)
                {
                    AgregarProducto(nombres[i], precio, cantidad);
                }
                else
                {
                    Console.WriteLine("Error al leer el dato:" + nombres[i]);
                }
            }
        }

        public string Fecha { get => fecha; set => fecha = value; }
        public int Estado_actual { get => estado_actual; set => estado_actual = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
    }

}
