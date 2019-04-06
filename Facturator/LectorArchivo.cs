using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class LectorArchivo {

        public const char SEPARADOR_NOMBRES = '-';
        public const char SEPARADOR_PRECIOS = '#';
        public const char SEPARADOR_REGISTROS = ',';

        private Factura[] facturas;//Pendiente hacer refactoring, la clase LectorArchivo solo debe leer el archivo y retornarlo

        /*
            En este primer ejemplo, vamos a leer todas las lineas de un archivo, para empezar a revisar el tema de lectura de datos externos,
            sin embargo aclaro que este enfoque no es el más recomendable, sobretodo para archivos que pueden ser grandes, más adelante usaremos
            un buffer, que es una mejor forma de procesar un archivo.

            tomado de: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
        */

        public void LeerArchivoCompleto()
        {
            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"../../archivo/facturas.csv");

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contenido del archivo facturas = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                
            }
            Console.ReadKey();
        }
        
        public void ProcesarLinea(string linea) {
            char[] separador_linea = new char[] { SEPARADOR_REGISTROS };
            string[] temp = linea.Split(separador_linea);
            string[] nombres, precios;

            facturas = new Factura[temp.Length];

            for (int i = 0; i < facturas.Length; i++)
            {
                //temp[0] Fecha
                nombres = ProcesarRegistro(temp[1], SEPARADOR_NOMBRES);
                precios = ProcesarRegistro(temp[2], SEPARADOR_PRECIOS);
                facturas[i].AgregarProductos(nombres,precios);
                //temp[3] Medio de pago
                //temp[4] Estado actual
            }

        }
        
        public string[] ProcesarRegistro(string registro,char separador) {
            char[] separador_registro = new char[] { separador };
            string[] temp = registro.Split(separador_registro);
            string[] salida = new string[temp.Length];

            for(int i=0;i<temp.Length;i++) {
                salida[i] = temp[i];
            }

            return salida;
        }

    }
}
