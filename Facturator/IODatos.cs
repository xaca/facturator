using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class IODatos {

        public const char SEPARADOR_NOMBRES = '-';
        public const char SEPARADOR_PRECIOS = '#';
        public const char SEPARADOR_REGISTROS = ';';//Revisar cual es el separado de un archivo csv dependiendo del sistema operativo
        public const char SEPARADOR_CANTIDAD = 'C';

        /*
            En este primer ejemplo, vamos a leer todas las lineas de un archivo, para empezar a revisar el tema de lectura de datos externos,
            sin embargo aclaro que este enfoque no es el más recomendable, sobretodo para archivos que pueden ser grandes, más adelante usaremos
            un buffer, que es una mejor forma de procesar un archivo.

            tomado de: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
        */

        public Factura[] cargarFacturas()
        {
            Factura[] facturas = null;

            try
            {
                // Example #2
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lineas = File.ReadAllLines(@"../../archivo/facturas.csv");

                // Display the file contents by using a foreach loop.
                Debug.Log("Contenido del archivo facturas = ");
                facturas = ProcesarLineas(lineas);
                
            }
            catch(NullReferenceException e1)
            {
                Console.WriteLine("Error al procesar los items del archivo");
                Console.WriteLine(e1.ToString());
            }
            catch(Exception e2)
            {
                //Pendiente personalizar la excepcion
                Console.WriteLine("Error al leer el archivo, revise que el archivo este cerrado");
                Console.WriteLine(e2.ToString());
            }
            return facturas;
        }
        
        public Factura[] ProcesarLineas(string[] lineas) {

            string[] temp;
            string[] nombres, precios;

            Factura[] facturas = new Factura[lineas.Length];//Peniente hacer refactoring

            for (int i = 1; i < lineas.Length; i++)//Empezamos en 1 para saltarnos el encabezado de la tabla
            {
                temp = Utilitario.SepararCadena(lineas[i], SEPARADOR_REGISTROS);
                nombres = ProcesarRegistro(temp[1], SEPARADOR_NOMBRES);
                precios = ProcesarRegistro(temp[2], SEPARADOR_PRECIOS);
                facturas[i] = new Factura(nombres.Length);
                facturas[i].Fecha = temp[0];  
                facturas[i].AgregarProductos(nombres,precios);
                facturas[i].Medio_pago = temp[3];
                facturas[i].Estado_actual = Utilitario.ConvertirEntero(temp[4]);
                facturas[i].Numero_factura = Utilitario.ConvertirEntero(temp[5]);
            }
            return facturas;
        }
        
        public string FormatearLineasFacturas(Factura[] facturas)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder temp;
            
            sb.Append("FECHA" + SEPARADOR_REGISTROS);
            sb.Append("NOMBRE PRODUCTOS" + SEPARADOR_REGISTROS);
            sb.Append("PRECIO"+ SEPARADOR_REGISTROS);
            sb.Append("MEDIO DE PAGO" + SEPARADOR_REGISTROS);
            sb.Append("Estado Actual" + SEPARADOR_REGISTROS);
            sb.Append("Numero Factura");
            sb.AppendLine();
            
            foreach(Factura f in facturas)
            {
                if(f!=null)
                {
                    temp = new StringBuilder();

                    //Se contruye cada línea del archivo, que representa cada Factura
                    temp.Append(f.Fecha + SEPARADOR_REGISTROS);
                    temp.Append(f.formatearProductos() + SEPARADOR_REGISTROS);
                    temp.Append(f.formatearPrecios() + SEPARADOR_REGISTROS);
                    temp.Append(f.Medio_pago.Trim() + SEPARADOR_REGISTROS);
                    temp.Append(f.Estado_actual + SEPARADOR_REGISTROS);
                    temp.Append(f.Numero_factura);
                    sb.AppendLine(temp.ToString());
                }
            }
            
            return sb.ToString();
        }

        public bool GuardarFacturas(string datos)
        {

            string carpeta = @"../../archivo/";
            // Filename
            string archivo = "facturas2.csv";//Se guarda en un archivo nuevo, para probar la creacion del archivo
            // Fullpath. You can direct hardcode it if you like.
            string ruta = carpeta + archivo;
            bool exito = true;
            // Write array of strings to a file using WriteAllLines.
            // If the file does not exists, it will create a new file.
            // This method automatically opens the file, writes to it, and closes file
            try
            {

                File.WriteAllText(ruta,datos);
            }
            catch(Exception e) {
                Console.WriteLine("Error al guardar el archivo "+e.ToString());
                exito = false; 
            }
            

            return exito;
        }

        public string[] ProcesarRegistro(string registro,char separador) {
            
            string[] temp = Utilitario.SepararCadena(registro, separador);
            string[] salida = new string[temp.Length];

            for(int i=0;i<temp.Length;i++) {
                salida[i] = temp[i];
            }

            return salida;
        }

    }
}
