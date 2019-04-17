using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Utilitario {
       
        public static float ConvertirFlotante(string temp)
        {
            float salida = -1f;//Un valor negativo no es posible para un precio, por tanto sirve para validar
            if(!float.TryParse(temp,out salida))
            {
                Console.WriteLine("ConvertirFlotante, Error al intentar convertir el dato: " + temp);
            }
            return salida;
        }

        public static int ConvertirEntero(string temp)
        {
            int salida = -1;//Un valor negativo no es posible para un precio, por tanto sirve para validar
            if (!int.TryParse(temp, out salida))
            {
                Console.WriteLine("ConvertirFlotante, Error al intentar convertir el dato: " + temp);
            }
            return salida;
        }

        public static string[] SepararCadena(string cadena,char separador)
        {
            char[] separador_linea = new char[] { separador };
            string[] temp = cadena.Split(separador_linea);

            return temp;
        }

        public static string ImprimirEspacios()
        {
            return " ";
        }

        public static void ImprimirSeparador(char caracter,int total)
        {
            string separador = "" + caracter;
            string ans = "";
            for (int i = 0; i < total; i++)
            {
                ans += separador;
            }
            Console.WriteLine(ans);
        }
    }
}
