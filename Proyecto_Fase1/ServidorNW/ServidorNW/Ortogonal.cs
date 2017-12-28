using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class Ortogonal
    {
        Matriz cabeza;

        public Ortogonal()
        {
            cabeza = null;
            insertar(0);
            insertar(1);
            insertar(2);
            insertar(3);
        }

        public bool insertarEnMatriz(int nivel,string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        {
            Matriz aux = cabeza;
            while (aux!= null)
            {
                if (aux.nivel == nivel)
                {
                    break;
                }
                aux = aux.siguiente;
            }
           return aux.insertarEnMatriz(unidad, movimiento, alcance, dano, vida, columna, fila);
        }

        public void insertar(int nivel)
        {
            Matriz nuevo = new Matriz(nivel);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }else
            {
                Matriz aux = cabeza;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = nuevo;
                nuevo.anterior = aux;
            }

        }
    }
}