using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNW
{
    public class NodoAvl
    {
        public NodoABB usuario;
        public NodoAvl izq, der;
        public int fe;
        public string nickname;
        public string pass;
        public string email;

        public NodoAvl()
        {

        }
        public NodoAvl(NodoABB usuario)
        {
            this.usuario = usuario;
            this.nickname = null;
            izq = der = null;
            fe = 0;
        }
        
        public NodoAvl(string nickname, string pass, string email)
        {
            this.nickname = nickname;
            this.pass = pass;
            this.email = email;
            usuario = null;
            izq = der = null;
            fe = 0;

        }

        public string getNickname()
        {
            if (string.IsNullOrEmpty(nickname) )
                return usuario.nickname;
            else
                return nickname;
        }

        public NodoAvl(string nickname, string pass, string email, int fe)
        {
            this.nickname = nickname;
            this.pass = pass;
            this.email = email;
            izq = der = null;
            this.fe = fe;
        }

        public NodoAvl(NodoAvl izq, string nickname, string pass, string email,NodoAvl der)
        {
            this.nickname = nickname;
            this.pass = pass;
            this.email = email;
            this.izq = izq;
            this.der = der;
            fe = 0;
        }

        public NodoAvl(NodoAvl izq, string nickname, string pass, string email, int fe,NodoAvl der)
        {
            this.nickname = nickname;
            this.pass = pass;
            this.email = email;
            this.izq = izq;
            this.der = der;
            this.fe = fe;
        }

        public void setFe(int fe)
        {
            this.fe = fe;
        }

        public int getFe()
        {
            return fe;
        }
    }
}