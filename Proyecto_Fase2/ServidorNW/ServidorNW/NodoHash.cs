using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoHash
    {
        public string nickname;
        public string password;
        public string email;
        public int conectado;
        public int clave;

        public NodoHash()
        {

        }
        public NodoHash(NodoABB nodo, int clave)
        {
            this.nickname = nodo.nickname;
            this.password = nodo.password;
            this.email = nodo.email;
            this.conectado = nodo.conectado;
            this.clave = clave;
        }

        public NodoHash(NodoHash nodo, int clave)
        {
            this.nickname = nodo.nickname;
            this.password = nodo.password;
            this.email = nodo.email;
            this.conectado = nodo.conectado;
            this.clave = clave;
        }

    }
}