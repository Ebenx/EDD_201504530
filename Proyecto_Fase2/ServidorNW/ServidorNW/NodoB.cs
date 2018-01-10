using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoB
    {
        public int numAtaque;
        public string clave;
        public string coordenadaX;
        public int valX;
        public int coordenadaY;
        public string unidadAtacante;
        public int dano;
        public string tipoUnidadDanada;
        public string emisor, receptor;
        public string fecha;
        public string tiempoRestante;
        public int ataque;


        public NodoB(int numAtaque,string clave, string coordenadaX, int valX, int coordenadaY, string unidadAtacante, int dano, string tipoUnidadDanada, string emisor,
            string receptor, string fecha, string tiempoRestante, int ataque)
        {
            this.clave = clave;
            this.numAtaque = numAtaque;
            this.coordenadaX = coordenadaX;
            this.valX = valX;
            this.coordenadaY = coordenadaY;
            this.unidadAtacante = unidadAtacante;
            this.dano = dano;
            this.tipoUnidadDanada = tipoUnidadDanada;
            this.emisor = emisor;
            this.receptor = receptor;
            this.fecha = fecha;
            this.tiempoRestante = tiempoRestante;
            this.ataque = ataque;
        }


    }
}