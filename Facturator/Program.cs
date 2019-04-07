using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturator {
    class Program {
        static void Main(string[] args) {

            LectorArchivo temp = new LectorArchivo();
            temp.LeerArchivoCompleto();
            Console.ReadKey();         
        }
    }
}
