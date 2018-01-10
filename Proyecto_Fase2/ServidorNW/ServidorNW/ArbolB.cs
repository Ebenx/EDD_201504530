using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ArbolB
    {
        int orden;
        PaginaB raiz;

       

        public  ArbolB()
        {
            orden = 0;
            raiz = null;
        }

        public ArbolB(int m)
        {
            orden = m;
            raiz = null;
        }

        public bool ArbolIsEmpty()
        {
            return raiz == null;
        }

        public PaginaB getRaiz()
        {
            return raiz;
        }

        public void setRaiz(PaginaB nuevo)
        {
            raiz = nuevo;
        }

        public int getOrden()
        {
            return orden;
        }
       
        public void setOrden(int i)
        {
            orden = i;
        }

        

        public PaginaB buscar(PaginaB actual, string clave, int i)
        {
            return new PaginaB();//falta
        }

        public bool buscarNodo(PaginaB actual, string clave, ref int i)
        {
            bool respuesta;
            if (String.Compare(clave, actual.getClave(1)) == -1)
            {
                respuesta = false;
                i = 0;
            }else
            {
                i = actual.getContar();
                while (String.Compare(clave,actual.getClave(i))==-1  &&  i>1)
                {
                    i--;                    
                }
                respuesta = (clave == actual.getClave(i));
            }

            return respuesta;
        }

        public PaginaB buscar(string clave, ref int i)
        {
            return buscar(raiz, clave, i);
        }

        public PaginaB buscar(PaginaB actual, string clave, ref int i)
        {
            if (actual == null)
            {
                return null;
            }else
            {
                bool existe = buscarNodo(actual, clave, ref i);
                if (existe)
                {
                    return actual;
                }else
                {
                    return buscar(actual.getRama(i), clave, i);
                }
            }
        }

        public void insertar(int parametro,int numAtaque, string coordenadaX, int valX, int coordenadaY, string unidadAtacante, int dano, string tipoUnidadDanada, string emisor,
            string receptor, string fecha, string tiempoRestante, int ataque)
        {
            string clave="";
            switch (parametro)
            {
                case 1://coordenadaX
                    clave = coordenadaX + numAtaque.ToString();
                    break;
                case 2://coordenaday
                    clave = coordenadaY + numAtaque.ToString();
                    break;
                case 3://unidad atacante
                    clave = unidadAtacante + numAtaque.ToString();
                    break;
                case 4://resultado
                    clave = dano + numAtaque.ToString();
                    break;
                case 5://tipo unidad dañada
                    clave = tipoUnidadDanada + numAtaque.ToString();
                    break;
                case 6://emisor
                    clave = emisor + numAtaque.ToString();
                    break;
                case 7://receptor
                    clave = receptor + numAtaque.ToString();
                    break;
                case 8://fecha
                    clave = fecha + numAtaque.ToString();
                    break;
                case 9://tiempo restante
                    clave = tiempoRestante + numAtaque.ToString();
                    break;
                case 10://numero de ataque
                    clave = numAtaque.ToString();
                    break;
            }

            NodoB nuevo = new NodoB(numAtaque, clave, coordenadaX, valX, coordenadaY, unidadAtacante, dano, tipoUnidadDanada, emisor, receptor, fecha, tiempoRestante, ataque);
            raiz = insertar(ref raiz, nuevo);
        }

        private PaginaB insertar(ref PaginaB raiz , NodoB clave)
        {//paginaB raiz 
            bool subir;
            NodoB media=null;
            PaginaB aux, auxN= null;

            subir = empujar( ref raiz ,clave, ref media, ref  auxN );
            
            if (subir)
            {
                aux = new PaginaB(orden);
                aux.setContar(1);
                aux.setClave(1,media);
                aux.setRama(0, raiz);
                aux.setRama(1, auxN);
                raiz = aux;
            }

            return raiz;
        }

        public bool empujar(ref PaginaB actual, NodoB clave, ref NodoB mediana, ref PaginaB nuevo)
        {
            int val=0;
            bool subir = false;
            if (actual ==null)
            {
                subir = true;
                mediana = clave;
                nuevo = null;
            }else
            {
                bool existe = buscarNodo(actual, clave.clave, ref val);
                //if existe no se hace nada
                //subir = empujar(ref actual.getRama(val) , clave, ref mediana, ref nuevo);
            }

            return subir;
        }

    }
}