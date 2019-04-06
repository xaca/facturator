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

    }
}
