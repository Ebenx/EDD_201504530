using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class BuscarUsuario : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nick = TextNick.Text;
            ServiceReference1.NodoABB nodo;

            if (!string.IsNullOrEmpty(nick))
            {
                nodo = referencia.buscarUsuario(nick);
                if (nodo != null)
                {
                    TextNickname2.Text = nodo.nickname;
                    TextPass.Text = nodo.password;
                    TextEmail.Text = nodo.email;
                    if (nodo.conectado == 1)
                    {
                        DropDownList1.SelectedIndex = 0;
                    }
                    else
                    {
                        DropDownList1.SelectedIndex = 1;
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('No Existe');</script>");
                }

            }
            else
            {
                Response.Write("<script>window.alert('Vaya vaya hacen falta datos');</script>");
            }

        }
    }
}