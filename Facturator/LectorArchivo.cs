using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class LectorArchivo {

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
                
        public void ProcesarNombres(string nombres) {
            char[] charSeparators = new char[] { '-' };
            string[] temp = nombres.Split(charSeparators);

            foreach (string author in temp) {
                Console.WriteLine(author);
            }
        }

        public void ProcesarPrecios(string precios) {
            char[] charSeparators = new char[] { '#' };
            string[] temp = precios.Split(charSeparators);

            foreach (string producto in temp) {
                Console.WriteLine(producto);
            }
        }

    }
}
