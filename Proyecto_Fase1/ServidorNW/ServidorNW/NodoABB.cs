using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoABB
    {
        public string nickname;
        public string password;
        public string email;
        public int conectado;
        public NodoABB izq;
        public NodoABB der;
        public ListaJuegos juegos;

        NodoABB()
        {

        }
        public NodoABB(string nickname, string password, string email, int conectado)
        {
            this.nickname = nickname;
            this.password = password;
            this.email = email;
            this.conectado = conectado;
            this.izq = null;
            this.der = null;
            this.juegos = null;
        }

       
    }
}