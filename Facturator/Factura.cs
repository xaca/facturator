﻿using System;
using System.CodeDom.Compiler;
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
            Console.Write(Utilitario.FomatearDigito(cantidad.ToString()));//Se hace de esta forma, para que la función de convertir digitos sea versátil
            Utilitario.ImprimirEspacios(1);
            Console.Write(Utilitario.ImprimirEspaciosFin(canasta[indice].Nombre,Constantes.CANTIDAD_CARACTERES_NOMBRE_PRODUCTO));
            Utilitario.ImprimirEspacios(1);
            Console.Write(Utilitario.ImprimirEspaciosInicio(canasta[indice].Precio.ToString(), Constantes.CANTIDAD_CARACTERES_PRECIO_UNITARIO));
            Utilitario.ImprimirEspacios(1);
            Console.WriteLine(Utilitario.ImprimirEspaciosInicio((canasta[indice].Precio*cantidad).ToString(),Constantes.CANTIDAD_CARACTERES_PRECIO_SUBTOTAL));

        }

        public void ImprimirCabezote()
        {
            Utilitario.ImprimirSeparador('*',Constantes.ANCHO_TIRILLA);
            Utilitario.CentrarPalabra(Constantes.NOMBRE_NEGOCIO, Constantes.ANCHO_TIRILLA);
            Utilitario.CentrarPalabra("#"+numero_factura,Constantes.ANCHO_TIRILLA);
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);
        }

        public float CalcularImpuesto(float subtotal)
        {             
            return subtotal * Constantes.IMPUESTO;
        }

        public string formatearProductos()
        {
            StringBuilder temp = new StringBuilder();
            Producto p;
            //PanDeLaMigueria - MiloDeLaMigueria
            for(int i = 0;i<canasta.Length;i++)
            {
                p = canasta[i];
                temp.Append(Utilitario.MinificarNombre(p.Nombre));
                if(i+1<canasta.Length)
                {
                    temp.Append(IODatos.SEPARADOR_NOMBRES);
                }
            }
            return temp.ToString();
        }

        public string formatearPrecios()
        {
            StringBuilder temp = new StringBuilder();
            Producto p;
            //8000C1#2000C2
            for (int i = 0; i < canasta.Length; i++)
            {
                p = canasta[i];
                temp.Append(p.Precio);
                temp.Append(IODatos.SEPARADOR_CANTIDAD);
                temp.Append(p.Cantidad);
                if(i+1<canasta.Length)
                {
                    temp.Append(IODatos.SEPARADOR_PRECIOS);
                }
            }
            return temp.ToString();
        }

        public void ImprimirPata()
        {
            float subtotal = CalcularSubtotal();
            string texto_subtotal = "Subtotal $" + subtotal;
            string texto_impuesto = "Impuesto $" + CalcularImpuesto(subtotal);
            Utilitario.ImprimirSeparador('*', Constantes.ANCHO_TIRILLA);
            Utilitario.ImprimirEspacios(Constantes.ANCHO_TIRILLA - (texto_subtotal.Length));
            Console.WriteLine(texto_subtotal);
            Utilitario.ImprimirEspacios(Constantes.ANCHO_TIRILLA - (texto_impuesto.Length));
            Console.Write(texto_impuesto);
        }

        public void ImprimirTirilla()
        {
            ImprimirCabezote();
           
            for (int i = 0; i < indice; i++)
            {
                MostrarProducto(i);
            }
            //Pendiente calcular la propina, el impuesto, el método de pago y si aplica devuelta.
            ImprimirPata();
        }

        public void AgregarProducto(Producto producto) {
            
            if (indice+1 <= canasta.Length)
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
                precio_cantidad = Utilitario.SepararCadena(precios[i], IODatos.SEPARADOR_CANTIDAD);
                precio = Utilitario.ConvertirFlotante(precio_cantidad[0]);
                cantidad = Utilitario.ConvertirEntero(precio_cantidad[1]);

                if(precio > 0 && cantidad>0)
                {
                    AgregarProducto(nombres[i], precio, cantidad);
                }
                else
                {
                    Console.WriteLine("Error al leer el dato:" + nombres[i]);//Cambiar por una exepcion
                }
            }
        }

        public float CalcularSubtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < canasta.Length; i++)
            {
                subtotal += canasta[i].Precio*canasta[i].Cantidad;
            }

            return subtotal;
        }

        public string Fecha { get => fecha; set => fecha = value; }
        public int Estado_actual { get => estado_actual; set => estado_actual = value; }
        public string Medio_pago { get => medio_pago; set => medio_pago = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
    }

}
