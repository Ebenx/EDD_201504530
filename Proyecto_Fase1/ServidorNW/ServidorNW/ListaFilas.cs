using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ListaFilas
    {
        public Cabecera cabeza;

        public ListaFilas()
        {
            cabeza = null;
        }

        public void insertar(string fila, int intFila)
        {
            Cabecera nuevo = new Cabecera(fila, intFila);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Cabecera aux = cabeza;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = nuevo;
                nuevo.anterior = aux;
            }
        }

        public void insertarInicio(string fila, int intFila)
        {
            Cabecera nuevo = new Cabecera(fila, intFila);
            if (isEmpty())
            {
                cabeza = nuevo;
            }else
            {
                Cabecera aux = cabeza;
                cabeza = nuevo;
                cabeza.siguiente = aux;
            }
        }

        public void insertarEntre(Cabecera primero, Cabecera segundo,Cabecera nuevo)
        {
            if (segundo != null)
            {
                primero.siguiente = nuevo;
                nuevo.siguiente = segundo;
                nuevo.anterior = primero;
                segundo.anterior = nuevo;
            }else
            {
                primero.siguiente = nuevo;
                nuevo.siguiente = segundo;
                nuevo.anterior = primero;
            }
        }

        public void eliminar(string fila)
        {
            if (cabeza != null)
            {
                Cabecera ant = null;
                Cabecera aux = cabeza;
                while (aux != null)
                {
                    if (aux.titulo != fila)
                    {
                        ant = aux;
                        aux = aux.siguiente;
                    }
                    else
                    {
                        if (ant == null)
                        {
                            cabeza = cabeza.siguiente;
                            aux.siguiente = null;
                            aux = cabeza;
                        }
                        else
                        {
                            ant.siguiente = aux.siguiente;
                            aux.siguiente = null;
                            aux = ant.siguiente;
                            break;
                        }
                    }
                }
            }
        }

        public Cabecera buscar(string fila)
        {
            if (cabeza != null)
            {
                Cabecera aux = cabeza;
                while (aux != null)
                {
                    if (aux.titulo == fila)
                    {
                        return aux;
                    }
                    aux = aux.siguiente;
                }

            }
            return null;
        }

        public bool isEmpty()
        {
            return (cabeza == null);
        }

        public bool Existe(string fila)
        {
            if (buscar(fila) != null)
            {
                return true;
            }
            return false;
        }
    }
}