using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class UI {

        public static int Menu()
        {
            int opc = 0;
            Console.WriteLine("Facturator v1.0"); //TODO: Personalizar el menu ascii
            do
            {
                Console.WriteLine("Ingrese una opción así");
                Console.WriteLine(" 1. Realizar venta");//Se debe incluir guardar
                Console.WriteLine(" 2. Operaciones con productos");//TODO:crud busqueda
                Console.WriteLine(" 3. Imprimir inventario");
                Console.WriteLine(" 4. Buscar Factura");
                Console.WriteLine(" 5. Exportar factura");//Imprimir en PDF, csv, html
                Console.WriteLine("-1. Salir");
                Console.WriteLine("Ingrese una opción así");

                if (int.TryParse(Console.ReadLine(), out opc))
                {
                    if(opc ==1 || opc==2 || opc==3 || opc==4 || opc==5)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error al ingresar la opción");
                }
            } while (opc != -1);

            return opc;
        }

    }
}
