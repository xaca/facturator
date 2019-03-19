using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Producto {
        private string nombre;
        private int tamano;
        private float precio;
        private float peso;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Tamano { get => tamano; set => tamano = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Peso { get => peso; set => peso = value; }
        

        public Producto() 
        {

        }

        public Producto(string nombre, int tamano, float precio, float peso) 
        {
            this.nombre = nombre;
            this.tamano = tamano;
            this.precio = precio;
            this.peso = peso;
        

        }
    }
}
