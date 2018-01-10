using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class ABB
    {
        public NodoABB raiz;

        public void insertarContactoExistente(NodoABB usuario, NodoABB contactoExistenete)
        {
            usuario.avl.insertar(contactoExistenete);
        }

        public void insertarContactoNuevo(NodoABB usuario, string nickname, string pass, string email)
        {
            usuario.avl.insertar(nickname, pass, email);
        }

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
                    return buscarR(raiz, nick);
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
            if (persona == null)
            {

            }
            else
            {
                persona.juegos.insertar(oponente, desplegados, sobrevivientes, destruidas, gano);
            }
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
                    return buscarR(raiz.der, nick);
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
                    return buscarR(raiz.izq, nick);
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

        string contenido = "";
        public Byte[] graficarABB()
        {
            contenido = "";
            if (raiz != null)
            {
                contenido = "digraph ArbolBinario{\n node [ fontname = \"Verdana\" shape = record ];\n";
                escribirNodo(raiz);
                graficarRamas(raiz);
                contenido = contenido + "}";
                imprimir(contenido);
                generarImagen();

                Byte[] bImage = new Byte[0];
                FileStream imagen = new FileStream(" C:\\Grafos\\abb.png",FileMode.OpenOrCreate,FileAccess.ReadWrite);
                bImage = new Byte[imagen.Length];
                BinaryReader reader = new BinaryReader(imagen);
                bImage = reader.ReadBytes(Convert.ToInt32(imagen.Length));
                imagen.Close();
                contenido = "";
                return bImage;
                


            }
            return null;
        }

        public void generarImagen()
        {
            String comand = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\Grafos\\grafoABB.dot -o C:\\Grafos\\abb.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comand);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();
        }

        public void imprimir(string contenido)
        {
            TextWriter t = new StreamWriter(@"C:\Grafos\grafoABB.dot");

            t.WriteLine(contenido);
            t.Close();
        }
        public void escribirNodo(NodoABB actual)
        {
            contenido = contenido + actual.nickname + "[label=\"<f0>|<f1>Nickname: " + actual.nickname + " \nPassword: " +actual.password +
                " \nEmail: " + actual.email + " \nConectado: " + actual.conectado.ToString() +"|<f2>\"];\n";


            //GRAFICANDO LISTA
            if (actual.juegos!=null && actual.juegos.cabeza!= null)
            {
                NodoLista aux = actual.juegos.cabeza;
                int i = 0;
                escribirNodoJuego(aux, actual, i);
                do
                {
                    escribirNodoJuego(aux.siguiente, actual, i);
                    contenido = contenido + "J" + actual.nickname +i.ToString() +" -> " + "J" + actual.nickname + (i+1).ToString() + ";\n";
                    aux = aux.siguiente;
                    i++;
                } while (aux.siguiente != null);
                graficarListaAlrevez(aux,actual, i);
                contenido = contenido + actual.nickname + ":f1 -> " + "J" + actual.nickname + "0;\n";
                
            }
        }
        public void graficarListaAlrevez(NodoLista ultimoJuego,NodoABB actual,int fin)
        {
            do
            {
                contenido = contenido + "J" + actual.nickname + fin.ToString() + " -> " + "J" + actual.nickname + (fin - 1).ToString() + ";\n";
                ultimoJuego = ultimoJuego.anterior;
                fin--;
            } while (ultimoJuego.anterior != null);
        }



        public void escribirNodoJuego(NodoLista actual, NodoABB actualABB, int numero)
        {
            
            contenido = contenido + "J" +actualABB.nickname+numero.ToString() + "[label=\"oponente: "+ actual.oponente+  
                " \nDesplegados: " + actual.desplegados.ToString() + " \nSobrevivientes: " +
                actual.sobrevivientes.ToString() + "\nDestruidas: " + actual.destruidas.ToString() + 
                " \nGano: " + actual.gano.ToString() + "\"];\n";
        }

        public void graficarRamas(NodoABB actual)
        {
            if (actual!=null){
                if (actual.izq != null)
                {
                    escribirNodo(actual.izq);
                    contenido = contenido + actual.nickname + ":f0 -> " + actual.izq.nickname + ":f1;\n";
                    graficarRamas(actual.izq);
                }
                if (actual.der != null)
                {
                    escribirNodo(actual.der);
                    contenido = contenido + actual.nickname + ":f2 -> " + actual.der.nickname + ":f1;\n";
                    graficarRamas(actual.der);
                }

            }
        }
        public void imprimir2(string contenido)
        {
            TextWriter t = new StreamWriter(@"C:\Grafos\grafoABB2.dot");

            t.WriteLine(contenido);
            t.Close();
        }

        public void generarImagen2()
        {
            String comand = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\Grafos\\grafoABB2.dot -o C:\\Grafos\\abb2.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comand);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();
        }

        public Byte[] graficarABBEspejo()
        {
            contenido = "";
            if (raiz != null)
            {
                ABB arbolEspejo = new ABB();
                arbolEspejo.raiz =  crearArbbEspejo(raiz);

                contenido = "digraph ArbolBinario{\n node [ fontname = \"Verdana\" shape = record ];\n";
                escribirNodo(arbolEspejo.raiz);
                graficarRamas(arbolEspejo.raiz);
                contenido = contenido + "}";
                imprimir2(contenido);
                generarImagen2();

                Byte[] bImage = new Byte[0];
                FileStream imagen = new FileStream(" C:\\Grafos\\abb2.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bImage = new Byte[imagen.Length];
                BinaryReader reader = new BinaryReader(imagen);
                bImage = reader.ReadBytes(Convert.ToInt32(imagen.Length));
                imagen.Close();
                contenido = "";
                return bImage;



            }
            return null;
        }

        public NodoABB crearArbbEspejo(NodoABB actual)
        {
            if (actual != null)
            {
                NodoABB nuevo = new NodoABB(actual.nickname, actual.password, actual.email, actual.conectado);
                nuevo.juegos = actual.juegos;
                nuevo.izq= crearArbbEspejo(actual.der);
                nuevo.der = crearArbbEspejo(actual.izq);
                return nuevo;
            }
            return null;
        }
    }
}