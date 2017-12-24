using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaAbolBB
{
    class NodoABB
    {
        public NodoABB izq;
        public NodoABB der;
        public int id;

       public NodoABB(int id)
        {
            this.id = id;
            izq = null;
            der = null;
        }
    }
}
