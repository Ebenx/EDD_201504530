using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServidorNW
{
    /// <summary>
    /// Summary description for ServiceNavalWars
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceNavalWars : System.Web.Services.WebService
    {
        static ABB arbolBinario = new ABB();
        static Ortogonal ortogonal = new Ortogonal();
        static Avl avl = new Avl();
        static TablaHash hash = new TablaHash();
        static hola hola = new hola();

        
        [WebMethod]
        public void holametodo()
        {

        }
        [WebMethod]
        public string rss()
        {
            return hola.ret();
        }

        [WebMethod]
        public void iniciarEstructuras()
        {
            arbolBinario = new ABB();
            ortogonal = new Ortogonal();
            hash = new TablaHash();
            //matriz = new Matriz();
        }

        [WebMethod]
        public Byte[] graficarABB()
        {
            return arbolBinario.graficarABB();
        }

        [WebMethod]
        public Byte[] graficarABBEspejo()
        {
            return arbolBinario.graficarABBEspejo();
        }

        [WebMethod]
        public string logearUsuario(string nickname)
        {
            if (nickname.Equals("@dm1n"))
            {
                return "admin";
            }
            else
            {
                if (!arbolBinario.estaVacio())
                {
                    return arbolBinario.buscar(nickname).password;
                }
                return null;
            }
        }

        [WebMethod]
        public void insertarUsuario(string nickname, string password, string email, int conectado)
        {
            arbolBinario.insertar(nickname, password, email, conectado);
        }

        [WebMethod]
        public bool eliminarUsuario(string nickname)
        {
            //arbolBinario.eliminar(nickname);
            arbolBinario.eliminarNodo(arbolBinario.buscar(nickname) ,nickname);
            return true;
        }

        [WebMethod]
        public NodoABB buscarUsuario(string nickname)
        {
            return arbolBinario.buscar(nickname);
        }

        [WebMethod]
        public void ModificarUsuario(string nicknameActual,string nicknameNuevo, string password, string email, int conectado)
        {
            arbolBinario.modificar(nicknameActual,nicknameNuevo, password, email, conectado);
        }

        [WebMethod]
        public string enOrden()
        {
            return arbolBinario.recorrer();
        }

        [WebMethod]
        public void insertarHistorialJuego(string nickname, string oponente, int desplegados, int sobrevivientes, int destruidas, int gano)
        {
            arbolBinario.insertarJuego(nickname, oponente, desplegados, sobrevivientes, destruidas, gano);
        }

        [WebMethod]
        public bool insertarEnOrtogonal(int nivel,string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        {
            return ortogonal.insertarEnMatriz(nivel,unidad, movimiento, alcance, dano, vida, columna, fila);
        }

        [WebMethod]
        public NodoHash devoverNodoHash()
        {
            return new NodoHash();
        }

        [WebMethod]
        public hola delverHola()
        {
            return new hola();
        }

        //[WebMethod]
        //public void insertar(string nickname, string pass, string email)
        //{
        //    avl.insertar(nickname, pass, email);
        //}

        //[WebMethod]
        //public string recorrerAvl()
        //{
        //    return avl.recorrer();
        //}

        [WebMethod]
        public void insertarContactoExistente(string usuario, string contacto)
        {

            arbolBinario.insertarContactoExistente(arbolBinario.buscar(usuario), arbolBinario.buscar(contacto));

        }

        [WebMethod]
        public void insertarContactoNuevo(string usuario, string contacto)
        {

            arbolBinario.insertarContactoExistente(arbolBinario.buscar(usuario), arbolBinario.buscar(contacto));

        }

        //[WebMethod]
        //public bool insertarSegundoNivel(string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        //{
        //    return matriz.segundo.insertarEnMatriz(unidad, movimiento, alcance, dano, vida, columna, fila);
        //}
        //[WebMethod]
        //public bool insertarTercerNivel(string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        //{
        //    return matriz.tercero.insertarEnMatriz(unidad, movimiento, alcance, dano, vida, columna, fila);
        //}
        //[WebMethod]
        //public bool insertarCuartoNivel(string unidad, int movimiento, int alcance, int dano, int vida, string columna, int fila)
        //{
        //    return matriz.cuarto.insertarEnMatriz(unidad, movimiento, alcance, dano, vida, columna, fila);
        //}

    }
}
