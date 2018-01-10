using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ListaJuegos
    {
        public NodoLista cabeza;

        public ListaJuegos()
        {
            cabeza = null;
        }

        public void  insertar(string oponente,int desplegados, int sobrevivientes, int destruidas, int gano)
        {
            NodoLista nuevo = new NodoLista(oponente, desplegados, sobrevivientes, destruidas, gano);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }else
            {
                NodoLista aux = cabeza;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = nuevo;
                nuevo.anterior = aux;
            }
        }
        public void buscar(string oponente)
        {

        }
        public void eliminarPrimero()
        {
            if (cabeza != null)
            {
                cabeza = cabeza.siguiente;
                cabeza.anterior = null;
            }
        }
        public void eliminarUltimo()
        {
            NodoLista aux = cabeza;
            while (aux.siguiente != null)
            {
                aux = aux.siguiente;
            }
            aux = null;

        }
        public void eliminarLista()
        {
            cabeza = null;
        }
    }


}