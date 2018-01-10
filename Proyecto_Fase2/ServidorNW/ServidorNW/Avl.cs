using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class Avl
    {
        public NodoAvl raiz;
        public Avl()
        {
            raiz = null;
        }

        public NodoAvl rotacionSimpleIzq(NodoAvl n, NodoAvl n1)        //simple izquierdo II
        {
            n.izq = n1.der;
            n1.der = n;
            if (n1.getFe() == -1)
            {
                n.setFe(0);
                n1.setFe(0);
            }
            else
            {
                n.setFe(-1);
                n1.setFe(1);
            }
            return n1;
        }

        public NodoAvl rotacionSimpleDer(NodoAvl n, NodoAvl n1)                              //simple Derecho DD
        {
            n.der = n1.izq;
            n1.izq = n;
            //refresh factor de equilibrio
            if (n1.getFe() == 1)
            {
                n.setFe(0);
                n1.setFe(0);
            }
            else
            {
                n.setFe(1);
                n1.setFe(-1);
            }
            return n1;
        }

        public NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = n1.izq;
            n.der = n2.izq;
            n2.izq = n;
            n1.izq = n2.der;
            n2.der = n1;
            //refresh factores de equilibrio
            if (n2.getFe() == 1)
            {
                n.setFe(-1);
            }
            else
            {
                n.setFe(0);
            }

            if (n2.getFe() == -1)
            {
                n1.setFe(1);
            }
            else
            {
                n1.setFe(0);
            }
            n2.setFe(0);
            return n2;
        }

        public NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = n1.der;
            n.izq = n2.der;
            n2.der = n;
            n1.der = n2.izq;
            n2.izq = n1;

            //refresh factores de equilibrio
            if (n2.getFe() == 1)
            {
                n1.setFe(-1);
            }
            else
            {
                n1.setFe(0);
            }
            if (n2.getFe() == -1)
            {
                n.setFe(1);
            }
            else
            {
                n.setFe(0);
            }
            n2.setFe(0);
            return n2;
        }
        public int h=0;
        public void insertar(NodoABB usuarioExistente)
        {

            NodoAvl nuevo = new NodoAvl(usuarioExistente);
            if (raiz == null)
            {
                raiz = new NodoAvl(usuarioExistente);
                h = 1;
            }
            else
            {
                raiz = insertarAvl(raiz, nuevo, ref h);
            }
        }
        public void insertar(string nickname, string pass, string email)
        {

            NodoAvl nuevo = new NodoAvl(nickname, pass, email);
            if (raiz == null)
            {
                raiz = new NodoAvl(nickname, pass, email);
                h = 1;
            }
            else
            {
                raiz = insertarAvl(raiz, nuevo, ref h);
            }
        }
        public NodoAvl insertarAvl(NodoAvl raiz, NodoAvl nuevo,ref int h)
        {
            NodoAvl n1;
            if (raiz == null)
            {
                raiz = nuevo;
                h = 1;
            }
            else if (string.Compare(nuevo.getNickname(), raiz.getNickname()) == -1)
            {
                raiz.izq = insertarAvl(raiz.izq, nuevo, ref h);
                //reduce 1 al fe porque crecio en la rama izquierda
                if (h != 0)
                {
                    switch (raiz.getFe())
                    {
                        case 1:
                            raiz.setFe(0);
                            h = 0;
                            break;

                        case 0:
                            raiz.setFe(-1);
                            break;

                        case -1:
                            n1 = raiz.izq;
                            if (n1.getFe() == -1)
                            {
                                raiz = rotacionSimpleIzq(raiz, n1);
                            }
                            else
                            {
                                raiz = rotacionID(raiz, n1);
                            }
                            h = 0;
                            break;

                    }
                }
                
            }
            else if (string.Compare(nuevo.getNickname(), raiz.getNickname()) == 1)
            {
                raiz.der =insertarAvl(raiz.der,nuevo,ref h);
                if (h != 0)
                {
                    switch (raiz.getFe())
                    {
                        case 1:
                            n1 = raiz.der;
                            if (n1.getFe() == 1)
                            {
                                raiz = rotacionSimpleDer(raiz, n1);
                            }
                            else
                            {
                                raiz = rotacionDI(raiz, n1);
                            }
                            h = 0;
                            break;

                        case 0:
                            raiz.setFe(1);
                            break;

                        case -1:
                            raiz.setFe(0);
                            h = 0;
                            break;
                    }
                }
            }
            else
            {
                h = 0;
            }
            return raiz;
        }


        public string recorrer()
        {
            return inOrden(raiz);
        }
        public string inOrden(NodoAvl nodo)
        {
            if (nodo != null)
            {
                return inOrden(nodo.izq) + "," + nodo.nickname.ToString() + inOrden(nodo.der);
            }
            else
            {
                return "";
            }
        }

        public NodoAvl borrarEnAvl(NodoAvl raiz, string nickname,ref int altura)
        {
            if (raiz == null)
            {
                altura = 0;
            }else if(string.Compare(nickname,raiz.getNickname()) ==-1)
            {
                raiz.izq = borrarEnAvl(raiz.izq, nickname, ref altura);
                if (altura != 0)
                {
                    raiz = equilibrar1(raiz, ref altura);
                }
            }else if (string.Compare(nickname, raiz.getNickname()) == 1)
            {
                raiz.der = borrarEnAvl(raiz.der, nickname, ref altura);
                if (altura != 0)
                {
                    raiz = equilibrar2(raiz, ref altura);
                }
            }else
            {   //Nodo Encontrado
                NodoAvl aux;
                aux = raiz;
                if (aux.izq == null)
                {
                    raiz = aux.der;
                    altura = 1;
                }else if(aux.der == null)
                {
                    raiz = aux.izq;
                    altura = 1;
                }else
                {
                    reemplazar(ref aux, ref aux.izq,ref altura);
                    if (altura != 0)
                    {
                        raiz = equilibrar1(raiz, ref altura);
                    }
                }
            }
            return raiz;
        }

        public NodoAvl equilibrar1(NodoAvl n, ref int altura)
        {
            NodoAvl n1;

            switch (n.getFe())
            {
                case -1:
                    n.setFe(0);
                    break;

                case 0:
                    n.setFe(1);
                    altura = 0;
                    break;

                case 1:
                    n1 = n.der;
                    if (n1.getFe() >= 0)
                    {
                        if (n1.getFe() == 0)
                        {
                            altura = 0;
                        }
                        n =rotacionSimpleDer(n, n1);
                    }else
                    {
                        n = rotacionDI(n, n1);
                    }
                    break;
            }
            return n;
        }
        public NodoAvl equilibrar2(NodoAvl n, ref int altura)
        {
            NodoAvl n1;
            switch (n.getFe())
            {
                case -1:
                    n1 = n.izq;
                    if (n1.getFe() <= 0)
                    {
                        if (n1.getFe() == 0)
                        {
                            altura = 0;
                        }
                        n =rotacionSimpleIzq(n, n1);
                    }else
                    {
                        n = rotacionID(n, n1);
                    }
                    break;

                case 0:
                    n.setFe(-1);
                    altura = 0;
                    break;

                case 1:
                    n.setFe(0);
                    break;
            }
            return n;
        }

        public void reemplazar(ref NodoAvl n,ref NodoAvl actual, ref int altura)
        {
            if (actual.der != null)
            {
                reemplazar(ref n,ref actual.der,ref altura);
                if (altura != 0)
                {
                    actual = equilibrar2(actual,ref altura);
                }else
                {
                    n = actual;
                    actual = actual.izq;
                    altura = 1;
                }
            }
        }

    }
}