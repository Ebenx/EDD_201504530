using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoMatriz
    {
        public string unidad;
        public int movimiento;
        public int alcance;
        public int dano;
        public int vida;
        public NodoMatriz arriba, abajo, derecha, izquierda, top, bot;
        public Cabecera cabeceraFila, cabeceraCol;

        public NodoMatriz(string unidad, int movimiento, int alcance, int dano, int vida)
        {
            this.unidad = unidad;
            this.movimiento = movimiento;
            this.alcance = alcance;
            this.dano = dano;
            this.vida = vida;
            arriba = null;
            abajo = null;
            derecha = null;
            izquierda = null;
            top = null;
            bot = null;
            cabeceraFila= cabeceraCol = null;
        }

        
        
    }
}