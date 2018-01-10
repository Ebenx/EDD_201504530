using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoLista
    {
        public NodoLista anterior;
        public NodoLista siguiente;
        public string oponente;
        public int desplegados;
        public int sobrevivientes;
        public int destruidas;
        public int gano;

        NodoLista()
        {

        }
        public NodoLista(string oponente,int desplegados, int sobrevivientes, int destruidas, int gano)
        {
            this.oponente = oponente;
            this.desplegados = desplegados;
            this.sobrevivientes = sobrevivientes;
            this.destruidas = destruidas;
            this.gano = gano;
            anterior = null;
            siguiente = null;
        }

    }
}