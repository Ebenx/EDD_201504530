using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class Cabecera
    {
        public string titulo;
        public int filaCabecera;            //contara el ascii de la letra en columna, y en fila contara el nivel
        public NodoMatriz apuntadorMatriz;
        public Cabecera siguiente;
        public Cabecera anterior;
        public int nivel;

        public Cabecera(string titulo)
        {
            this.titulo = titulo;
            apuntadorMatriz = null;
            siguiente = null;
            anterior = null;
        }
        public Cabecera(string titulo, int intFila)
        {
            this.titulo = titulo;
            this.filaCabecera = intFila;
            apuntadorMatriz = null;
            siguiente = null;
            anterior = null;
        }



    }
}