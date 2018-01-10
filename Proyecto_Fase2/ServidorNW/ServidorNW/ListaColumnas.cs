using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ListaColumnas
    {
        public Cabecera cabeza;
        public ListaColumnas()
        {
            cabeza = null;
        }

        public void insertar(string columna, int valColumna)
        {
            Cabecera nuevo = new Cabecera(columna,valColumna);
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
        public void insertarInicio(string columna, int intColumna)
        {
            Cabecera nuevo = new Cabecera(columna, intColumna);
            if (isEmpty())
            {
                cabeza = nuevo;
            }
            else
            {
                Cabecera aux = cabeza;
                cabeza = nuevo;
                cabeza.siguiente = aux;
            }
        }
        public void insertarEntre(Cabecera primero, Cabecera segundo, Cabecera nuevo)
        {
            if (segundo != null)
            {
                primero.siguiente = nuevo;
                nuevo.siguiente = segundo;
                nuevo.anterior = primero;
                segundo.anterior = nuevo;
            }
            else
            {
                primero.siguiente = nuevo;
                nuevo.siguiente = segundo;
                nuevo.anterior = primero;
            }
        }

        public void eliminarPrueba(string columna)
        {
            Cabecera aux = cabeza;
            if (aux.titulo == columna)
            {
                cabeza = aux.siguiente;
                aux = null;
            }else
            {
                while (aux.siguiente != null)
                {

                    aux = aux.siguiente;
                }
                aux = null;
            }
            
        }

        public void eliminar(string columna)
        {
            if (cabeza != null)
            {
                Cabecera ant = null;
                Cabecera aux = cabeza;
                while (aux != null)
                {
                    if (aux.titulo != columna)
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

        public Cabecera buscar(string columna)
        {
            if (cabeza != null)
            {
                Cabecera aux = cabeza;
                while (aux!= null)
                {
                    if (aux.titulo == columna)
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

        public bool Existe(string columna)
        { 
            if (buscar(columna) != null)
            {
                return true;
            }
            return false;
        }

    }
}