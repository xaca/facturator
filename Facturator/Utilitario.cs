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

        public static void ImprimirEspacios(int total)
        {
            string ans = "";
            for (int i = 0; i < total; i++)
            {
                ans += " ";
            }
            Console.Write(ans);
        }

        public static string ImprimirEspacios(string cadena,int total,bool posicion)
        {
            int cantidad = total - cadena.Length;
            string ans = "";

            if (cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    ans += " ";
                }
                ans = (posicion)?cadena + ans: ans + cadena;
            }
            else if (cantidad == 0)
            {
                ans = cadena;
            }
            else
            {
                ans = TruncarTexto(cadena, total);
            }

            return ans;
        }

        public static string ImprimirEspaciosInicio(string cadena,int total)
        {
            return ImprimirEspacios(cadena, total, false);
        }

        public static string ImprimirEspaciosFin(string cadena,int total)
        {                        
            return ImprimirEspacios(cadena,total,true);
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

        public static string FomatearDigito(string digitos)
        {
            return (ConvertirEntero(digitos)<10)?"0"+digitos:digitos;
        }

        public static string TruncarTexto(string cadena,int total_caracteres)
        {
            return cadena.Length > total_caracteres ? cadena.Substring(0,total_caracteres-1):cadena;
        }
    }
}
