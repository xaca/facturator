using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class UI {

        public static Program programa_principal;

        public static int BuscarFactura()
        {
            int id;
            do
            {
                Console.WriteLine("Ingrese el id de la factura solicitada");
            } while (int.TryParse(Console.ReadLine(), out id));

            return id;

        }

        public static int Menu(Program programa_principal)
        {
            int opc = 0;
            UI.programa_principal = programa_principal;
            //TODO: Personalizar el menu ascii
            Console.WriteLine("  __            _                   _             ");
            Console.WriteLine(" / _| __ _  ___| |_ _   _ _ __ __ _| |_ ___  _ __ ");
            Console.WriteLine("| |_ / _` |/ __| __| | | | '__/ _` | __/ _ \\| '__|");
            Console.WriteLine("|  _| (_| | (__| |_| |_| | | | (_| | || (_) | |   ");
            Console.WriteLine("|_|  \\__,_|\\___|\\__|\\__,_|_|  \\__,_|\\__\\___/|_| ");
            Console.WriteLine();
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
                        if(opc == 4)
                        {
                            BuscarFactura();
                            
                        }

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
