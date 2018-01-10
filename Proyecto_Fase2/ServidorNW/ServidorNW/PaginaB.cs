using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class PaginaB
    {
        public int m ;
        public NodoB[] datos;
        public PaginaB[] ramas;
        int contar;

        public PaginaB()
        {

        }
        public PaginaB(int indice)
        {
            this.m = indice;
            datos = new NodoB[indice];
            ramas = new PaginaB[indice];
            for (int i = 0; i < indice; i++)
            {
                datos[i] = null;
                ramas[i] = null;
            }
        }

        public bool paginaLLena()
        {
            return (contar == m - 1);
        }

        public bool paginaSemiVacio()
        {
            return (contar < m / 2);
        }

        public string escribirNodo()
        {
            string contenido = "Nodo: ";
            for (int i = 0; i<= contar; i++)
            {
                contenido = contenido + datos[i].clave + " ";
            }
            return contenido;
        }

        public string getClave(int i)
        {
            return datos[i].clave;
        }

        public void setClave(int i, string clave)
        {
            datos[i].clave = clave;
        }

        public void setClave(int i, NodoB clave)
        {
            datos[i] = clave;
        }

        public void setNodoB(int i, int numAtaque, string clave, string coordenadaX, int valX, int coordenadaY, string unidadAtacante, int dano, string tipoUnidadDanada, string emisor,
            string receptor, string fecha, string tiempoRestante, int ataque)
        {
            datos[i] = new NodoB(numAtaque, clave, coordenadaX, valX, coordenadaY, unidadAtacante, dano, tipoUnidadDanada, emisor, receptor, fecha, tiempoRestante, ataque);
        }

        public NodoB getNodoB(int i)
        {
            return datos[i];
        }

        public PaginaB getRama(int i)
        {
            return ramas[i];
        }

        public PaginaB setRama(int i, PaginaB n)
        {
            return ramas[i]=n;
        }

        public int getContar()
        {
            return contar;
        }

        public void setContar(int i)
        {
            contar = i;
        }
    }
}