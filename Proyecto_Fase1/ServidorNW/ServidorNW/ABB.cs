using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ABB
    {
        public NodoABB raiz;

        public bool estaVacio()
        {
            return raiz == null;
        }
        public void insertar(string nickname, string password, string email, int conectado)
        {
            NodoABB nuevo = new NodoABB( nickname,  password,  email,  conectado);

            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                inser(raiz, nuevo);
            }

        }
     

        public void inser(NodoABB raiz, NodoABB nuevo)
        {
            if (String.Compare(nuevo.nickname,raiz.nickname)==1 )//mayor
            {
                if (raiz.der == null)
                {
                    raiz.der = nuevo;
                }
                else
                {
                    inser(raiz.der, nuevo);
                }
            }
            else if (String.Compare(nuevo.nickname, raiz.nickname)==-1)//nuevo menor que raiz
            {
                if (raiz.izq == null)
                {
                    raiz.izq = nuevo;
                }
                else
                {
                    inser(raiz.izq, nuevo);
                }
            }
        }
                
        public bool eliminar(string nickname)
        {
            NodoABB elemento = buscar(nickname);
            if (elemento != null)                                   //verifica que no esta vacio el nodo
            {
                if (esHoja(elemento))                               //es el ultimo de la rama
                {
                    elemento = null;
                    return true;
                }else
                {                                                   //si no
                    if(elemento.der!=null && elemento.izq != null)
                    {
                        elemento = buscarMin(elemento.der);
                        return true;
                    }
                    else
                    {
                        if (elemento.izq == null)
                        {
                            elemento = elemento.der;
                            return true;
                        }
                        else
                        {
                            elemento = elemento.izq;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void eliminarNodo(NodoABB nodo, string nickname)
        {
           if (nodo != null)
            {

            }else if (String.Compare(nickname,nodo.nickname)==-1)//menor
            {
                eliminarNodo(nodo.izq, nickname);
            }else if (String.Compare(nickname, nodo.nickname) == 1)//mayor
            {
                eliminarNodo(nodo.der, nickname);
            }else
            {
                NodoABB aux;
                aux = nodo;
                if (aux.izq == null)
                {
                    nodo = aux.der;
                }else if (aux.der == null)
                {
                    nodo = aux.izq;
                }else
                {
                    reemplazar(aux);
                }
                aux = null;
            }
        }

        public void reemplazar(NodoABB actual)
        {
            NodoABB a, p;
            p = actual;
            a = actual.izq;
            while (a.der!=null)
            {
                p = a;
                a = a.der;
            }
            actual = a;
            if (p == actual)
            {
                p.izq = a.izq;
            }else
            {
                p.der = a.izq;
            }
            actual = a;

        }

        public NodoABB buscar(string nick)
        {
            if (raiz!=null)
            {
                if (String.Equals(nick, raiz.nickname))
                {
                    return raiz;
                }else
                {
                    buscarR(raiz, nick);
                }
            }
            return null;
        }

        public void modificar(string nicknameActual, string nicknameNuevo, string password, string email, int conectado)
        {
            //eliminar(nicknameActual);
            eliminarNodo(raiz, nicknameActual);
            insertar(nicknameNuevo, password,email,conectado);
        }

        public void insertarJuego(string nickname,string oponente, int desplegados, int sobrevivientes, int destruidas, int gano)
        {
            NodoABB persona = buscar(nickname);
            persona.juegos.insertar(oponente, desplegados, sobrevivientes, destruidas, gano);
        }

        public void elimarUltimoJuego(string nickname)
        {
            NodoABB persona = buscar(nickname);
            persona.juegos.eliminarUltimo();
        }

        public void elimarPrimerJuego(string nickname)
        {
            NodoABB persona = buscar(nickname);
            persona.juegos.eliminarPrimero();
        }
        public NodoABB buscarR(NodoABB raiz, string nick)
        {
            if (String.Compare(nick, raiz.nickname) == 1)//mayor
            {
                if (raiz.der == null)
                {
                    return null;
                }
                else
                {
                    buscarR(raiz.der, nick);
                }
            }
            else if (String.Compare(nick, raiz.nickname) == -1)//nuevo menor que raiz
            {
                if (raiz.izq == null)
                {
                    return null;
                }
                else
                {
                    buscarR(raiz.izq, nick);
                }
            }
            else if(String.Equals(nick, raiz.nickname))
            {
                return raiz;
            }

                return null;
        }

        public NodoABB buscarMin(NodoABB raiz)
        {
            while (raiz.izq!=null)
            {
                raiz = raiz.izq;
            }
            NodoABB aux = raiz;
            raiz = null;
            return aux; 
        }
        public bool esHoja(NodoABB nodo)
        {
            if (nodo.der == null & nodo.izq == null)
            {
                return true;
            }
            return false;
        }

        public string recorrer()
        {
            return inOrden(raiz);
        }
        public string inOrden(NodoABB nodo)
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

    }
}