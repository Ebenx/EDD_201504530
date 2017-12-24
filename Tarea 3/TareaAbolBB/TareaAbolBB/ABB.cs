using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaAbolBB
{
    class ABB
    {
        public NodoABB raiz;
        public ABB()
        {
            raiz = null;
        }

        public void insertar(int id)
        {
            NodoABB nuevo = new NodoABB(id);

            if (raiz==null)
            {
                raiz = nuevo;
            }else
            {
                inser(raiz, nuevo);
            }
        }

        public void inser(NodoABB raiz, NodoABB nuevo)
        {
            if (nuevo.id > raiz.id)
            {
                if (raiz.der == null)
                {
                    raiz.der = nuevo;
                }else
                {
                    inser(raiz.der,nuevo);
                }
            }else if (nuevo.id<raiz.id)
            {
                if (raiz.izq == null)
                {
                    raiz.izq = nuevo;
                }
                else
                {
                    inser(raiz.izq, nuevo);
                }
            }
        }

        public string preOrden(NodoABB nodo)
        {
            if (nodo != null)
            {
                return ","+nodo.id.ToString() + "" + preOrden(nodo.izq) +""+ preOrden(nodo.der);
            }else
            {
                return "";
            }      
        }

        public string inOrden(NodoABB nodo)
        {
            if (nodo != null)
            {
                return inOrden(nodo.izq) + ","+ nodo.id.ToString() + inOrden(nodo.der);
            }
            else
            {
                return "";
            }
        }

        public string postOrden(NodoABB nodo)
        {
            if (nodo != null)
            {
                return  postOrden(nodo.izq) + "" + postOrden(nodo.der)+ ","+nodo.id.ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
