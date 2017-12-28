using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ServidorNW
{
    public class Matriz
    {
        ListaColumnas columnas;
        ListaFilas filas;
        public int nivel;
        public Matriz siguiente;
        public Matriz anterior;


        //public Matriz primero = new Matriz();
        //public Matriz segundo = new Matriz();
        //public Matriz tercero = new Matriz();
        //public Matriz cuarto = new Matriz();

        public Matriz(int nivel)
        {
            this.nivel = nivel;
            columnas = new ListaColumnas();
            filas = new ListaFilas();
        }

        //Revisando si la las filas de los nodos estan vacias
        public bool isEmptyFilaNodoMatriz(Cabecera filaActual)
        {
            return (filaActual.apuntadorMatriz == null);
        }
        public bool isEmptyColNodoMatriz(Cabecera colActual)
        {
            return (colActual.apuntadorMatriz == null);
        }

        public bool insertarEnMatriz(string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        {
            
            //verificando que este vacia la matriz
            if (filas.isEmpty())
            {
                
                filas.insertar(fila.ToString(),fila);
                columnas.insertar(columna, getValorColumna(columna));

                //insertando directo a tu corazon xD
                NodoMatriz nuevo = new NodoMatriz(unidad, movimiento, alcance, dano, vida);
                filas.cabeza.apuntadorMatriz = nuevo;       //insertando en fila
                nuevo.cabeceraFila = filas.cabeza;
                columnas.cabeza.apuntadorMatriz = nuevo;    //insertando en columna
                nuevo.cabeceraCol = columnas.cabeza;


            }
            else
            {
                if (!existePosicion(fila.ToString(), columna))  //si no existe la posicion
                {
                    if (!filas.Existe(fila.ToString()))         //si no existe la fila
                    {
                        //insertar Filas
                        
                        Cabecera anterior = buscarPosicionFila(fila); //devueleve el anterior del futuro nuevo nodo
                        
                        if (anterior == null)                           //debe ir en cabeza
                        {
                            filas.insertarInicio(fila.ToString(), fila);
                        }else
                        {                                               //si no va entre nodos
                            filas.insertarEntre(anterior, anterior.siguiente, new Cabecera(fila.ToString(), fila));
                        }



                        // si no Existe la Columna
                        Cabecera anterior2 = buscarPosicionColumna(columna);
                        if (!columnas.Existe(columna))
                        {
                            if (anterior2== null)
                            {
                                columnas.insertarInicio(columna, getValorColumna(columna));
                            }else
                            {
                                columnas.insertarEntre(anterior2, anterior2.siguiente, new Cabecera(columna, getValorColumna(columna)));
                            }
                        }   
                    }
                    //si EXISTE INSERTANDO NODO!
                    NodoMatriz nuevo1 = new NodoMatriz(unidad, movimiento, alcance, dano, vida);
                    Cabecera filaActual = filas.buscar(fila.ToString());
                    Cabecera columnaActual = columnas.buscar(columna);

                    //LLAmar a mentodo entrefilasnodoMatriz    ESto si funciona
                    insertandoEntreNodosMatrizFila(filaActual, columnaActual, nuevo1, fila, columna);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void insertandoEntreNodosMatrizFila(Cabecera filaActual, Cabecera columnaActual, NodoMatriz nuevo1, int fila, string columna)
        {
            if (isEmptyFilaNodoMatriz(filaActual))     //1: SI esta vacia la filaActual
            {
                filaActual.apuntadorMatriz = nuevo1;
                nuevo1.cabeceraFila = filaActual;
                //unir a COLUMNA
                //1.1: SI esta vacia la  columna actual
                //1.2: NO esta vacia
                    //va en cabeza y la cabeza actual esta ocupada
                    //no va en Cabeza va entre nodos; ya sea un nodo y un null
                UnirAColumna(columnaActual, nuevo1, fila);
            }
            else
            {                                           //2: NO esta vacia la fila actual
                NodoMatriz nodoAnteriorFila = buscarPosicionNodo(filaActual.apuntadorMatriz, columna);
                //2.1: va en cabeza de la fila y la cabeza actual esta ocupada
                NodoMatriz auxFila;
                if (nodoAnteriorFila == null)
                {
                    auxFila = filaActual.apuntadorMatriz;
                    filaActual.apuntadorMatriz = nuevo1;
                    nuevo1.cabeceraFila = filaActual;
                    nuevo1.derecha = auxFila;
                    auxFila.izquierda = nuevo1;
                    UnirAColumna(columnaActual, nuevo1, fila);
                }else
                {//2.2: No va en cabeza, Va entre Nodos
                    auxFila = nodoAnteriorFila.derecha;
                    if (auxFila != null)
                    {
                        nodoAnteriorFila.derecha = nuevo1;
                        nuevo1.izquierda = nodoAnteriorFila;
                        nuevo1.derecha = auxFila;
                        auxFila.izquierda = nuevo1;
                    }else
                    {
                        nodoAnteriorFila.derecha = nuevo1;
                        nuevo1.izquierda = nodoAnteriorFila;
                        nuevo1.derecha = auxFila;
                    }
                    UnirAColumna(columnaActual, nuevo1, fila);
                }

                

            }
            
            
        }

        public void UnirAColumna(Cabecera columnaActual, NodoMatriz nuevo1, int fila)
        {
            if (isEmptyColNodoMatriz(columnaActual))            //1.1: SI esta vacia la  columna actual
            {
                columnaActual.apuntadorMatriz = nuevo1;
                nuevo1.cabeceraCol = columnaActual;
            }
            else
            {                                                   //1.2: NO esta vacia
                NodoMatriz nodoAnteriorColumna = buscarPosicionNodoColumna(columnaActual.apuntadorMatriz, fila);
                if (nodoAnteriorColumna == null)                        //va en cabeza y la cabeza actual esta ocupada
                {
                    insertarEntreNodosMatrizColumna(columnaActual.apuntadorMatriz, columnaActual.apuntadorMatriz, nuevo1);
                }
                else
                {                                                       //no va en Cabeza va entre nodos; ya sea un nodo y un null
                    insertarEntreNodosMatrizColumna(nodoAnteriorColumna, nodoAnteriorColumna.abajo, nuevo1);
                }
            }
        }

        public void insertarEntreNodosMatrizColumna(NodoMatriz primero, NodoMatriz segundo, NodoMatriz nuevo)
        {
            if (segundo != null)
            {
                primero.abajo = nuevo;
                nuevo.abajo = segundo;
                nuevo.arriba = primero;
                segundo.arriba = nuevo;
            }else
            {
                primero.abajo = nuevo;
                nuevo.abajo = segundo;
                nuevo.arriba = primero;
            }
        }

        public NodoMatriz buscarPosicionNodo( NodoMatriz cabeza, string columna)// cabeza es el apuntador de la fila a la matriz
        {
            int valColumna = getValorColumna(columna);
            if (cabeza != null)
            {
                NodoMatriz aux = cabeza;
                while (aux != null)
                {
                    if ((aux.cabeceraCol.filaCabecera<valColumna) && aux.derecha!=null && (aux.derecha.cabeceraCol.filaCabecera<valColumna ))
                    {
                        aux = aux.derecha;
                    }
                    else
                    {
                        return aux;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public NodoMatriz buscarPosicionNodoColumna(NodoMatriz cabeza, int fila)
        {
            if (cabeza!= null)
            {
                NodoMatriz aux = cabeza;
                while (aux != null)
                {
                    if ((aux.cabeceraFila.filaCabecera<fila) && aux.abajo!=null && (aux.abajo.cabeceraFila.filaCabecera<fila))
                    {
                        aux = aux.abajo;
                    }else
                    {
                        return aux;
                    }
                }
                return null;
            }else
            {
                return null;
            }
        }
        public Cabecera buscarPosicionFila(int fila)
        {
            Cabecera aux = filas.cabeza;
            if (aux.filaCabecera > fila)
            {
                return null;
            }
            else
            {
                while (aux != null)
                {
                    if ((aux.filaCabecera < fila) &&  aux.siguiente != null && (aux.siguiente.filaCabecera < fila))
                    {
                        aux = aux.siguiente;
                    }
                    else
                    {
                        return aux.anterior;
                    }
                }
            }
            return null;
        }

        public Cabecera buscarPosicionColumna(string columna)
        {
            int valColumna = getValorColumna(columna);
            Cabecera aux = columnas.cabeza;
            if (aux.filaCabecera> getValorColumna(columna))     //si la primera cabecera es mayor devuelve null
            {
                return null;
            }else
            {
                while (aux != null)                             //si no busca
                {
                    if ((aux.filaCabecera < valColumna) && aux.siguiente!=null && (aux.siguiente.filaCabecera<valColumna) )
                    {
                        aux = aux.siguiente;
                    }else
                    {
                        return aux.anterior;
                    }
                    
                }
            }
            return null;
        }

        public bool existePosicion(string fila, string columna)
        {
            if (!filas.isEmpty())
            {
                Cabecera aux = filas.cabeza;            //recorriendo cabeceras filas
                while (aux != null)
                {
                    if (aux.titulo == fila)
                    {
                        NodoMatriz auxNodo = aux.apuntadorMatriz;
                        while (auxNodo != null)
                        {
                            //buscar la columna
                            if (auxNodo.cabeceraCol.titulo == columna)
                            {
                                return true;
                            }
                            auxNodo = auxNodo.derecha;
                        }
                    }
                    aux = aux.siguiente;
                }
            }
            return false;
        }



        public void insertarNodoEnFila(NodoMatriz cabezafila, string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        {
            NodoMatriz nuevo = new NodoMatriz(unidad, movimiento, alcance, dano, vida);
            if (cabezafila == null)
            {
                cabezafila = nuevo;
            }else
            {
                NodoMatriz aux = cabezafila;
                if (!existeAlgo(columnas.buscar(columna).apuntadorMatriz, fila.ToString()))  //cabezaNodoMatriz columna, fila
                {
                    while (aux.derecha != null)
                    {
                        aux = aux.derecha;
                    }
                    aux.derecha = nuevo;
                    nuevo.izquierda = aux;

                }
            }
        }

        public void insertarNodo(NodoMatriz nuevo, Cabecera fila, Cabecera columna)
        {
        }

        
        public bool existeAlgo(NodoMatriz cabezaColumna, string fila)
        {
            if (cabezaColumna != null)
            {
                NodoMatriz aux = cabezaColumna;
                while (aux != null)
                {
                    if (aux.cabeceraFila.titulo == fila) //verificando que la posicion en fila y columna no haya nada
                    {
                        return true;
                    }
                    aux = aux.abajo;
                }
            }
            return false;
        }

        public void insertarNodoEnColumna()
        {

        }

        
        public void insertaFila()
        {

        }
        public void insertarColumna()
        {

        }

        public int asc(string s)
        {
            Console.WriteLine(Encoding.ASCII.GetBytes(s)[0]);
            return Encoding.ASCII.GetBytes(s)[0];
        }
        public int getValorColumna(string columna)
        {
            int tamano = columna.Length;
            int ultimo = tamano - 1;
            int contador = 0;
            if (tamano > 1)
            {
                
                contador = ultimo * 26 + (asc(columna[ultimo].ToString()) - 64);
            }
            else
            {
                contador = asc(columna[0].ToString()) - 64;
            }
            return contador;
        }

    }
}