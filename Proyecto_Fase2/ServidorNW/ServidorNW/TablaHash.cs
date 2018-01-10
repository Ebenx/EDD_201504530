using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class TablaHash
    {
        public NodoHash[] tabla;
        public int tamanoTabla;
        public int elementos;
        public bool vacio;
        public double porcentajeMax,porcentajeMin, factorCarga;

        public TablaHash()
        {

        }

        public TablaHash(int tam)
        {
            tamanoTabla = tam;
            tabla = new NodoHash[tam];
            for (int j =0; j<tam; j++)
            {
                tabla[j] = null;
            }
            elementos = 0;
            factorCarga = porcentajeMin= porcentajeMax= 0;
            vacio=true;
        }

        public int plegamiento(string clave)
        {
            int tam = clave.Length;
            int valor = 0;

            for(int i =0; i< tam; i++)
            {
                valor = valor * 27+ Convert.ToInt32(clave[i]);
            }
            return valor;
        }

        public int direccionModular(string clave) //funcion hash
        {
            int i = 0, modulo;
            modulo = plegamiento(clave) % tamanoTabla;

            while (tabla[i]!=null && String.Compare(tabla[i].nickname,clave)!=0)
            {
                i++;
                modulo = modulo + i ^ 2;
                modulo = modulo % tamanoTabla;
            }
            return modulo;
        }

        public void insertarABB(NodoABB raiz)
        {
            if (raiz != null)
            {
                vacio = false;
                recorrer(raiz);

                if (factorCarga < 0.3)
                {
                    int tam = elementos * 3;
                    //copiar
                    copiar(tam);
                    //
                }
            }
            //agregar vacio = false
            //verificar si es  null
            //verificar que no sea menor
        }

        public void recorrer(NodoABB raiz)
        {
            if (raiz != null)
            {
                recorrer(raiz.izq);
                insertar(raiz);
                recorrer(raiz.der);
            }
        }

        public void insertar(NodoABB nodoNuevo)
        {
            int posicion= direccionModular(nodoNuevo.nickname);
            tabla[posicion] = new NodoHash(nodoNuevo, posicion);
            elementos++;
            factorCarga = elementos / tamanoTabla;
            
            if (factorCarga > 0.5)
            {
                //copia
                int tam = elementos * 3;
                copiar(tam);
            }

        }

        public void copiar(int tam)
        {
            TablaHash nuevaHash = new TablaHash(tam);
            
            foreach(NodoHash nodo in tabla)
            {
                nuevaHash.trasladar(nodo);
                nuevaHash.vacio = false;
            }

            tabla = new NodoHash[tam];
            tabla = nuevaHash.tabla;

        }

        public void trasladar(NodoHash nodoNuevo)
        {
            int posicion = direccionModular(nodoNuevo.nickname);
            tabla[posicion] = new NodoHash(nodoNuevo, posicion);
            elementos++;
            factorCarga = elementos / tamanoTabla;
        }
    }
}