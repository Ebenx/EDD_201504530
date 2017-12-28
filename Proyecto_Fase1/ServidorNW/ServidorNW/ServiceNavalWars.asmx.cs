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
        

        [WebMethod]
        public void iniciarEstructuras()
        {
            arbolBinario = new ABB();
            ortogonal = new Ortogonal();
            //matriz = new Matriz();
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
            arbolBinario.eliminarNodo(arbolBinario.raiz ,nickname);
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
