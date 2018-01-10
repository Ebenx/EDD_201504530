using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Enabled = false;
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
                    Button1.Enabled = true;
                }else
                {
                    Response.Write("<script>window.alert('No Existe');</script>");
                }

            }else
            {
                Response.Write("<script>window.alert('Vaya vaya hacen falta datos');</script>");
            }

            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string nickname= TextNickname2.Text, pass= TextPass.Text, email= TextEmail.Text;

            if (!string.IsNullOrEmpty(nickname) && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(email))
            {
                referencia.ModificarUsuario(TextNick.Text, nickname, pass, email, int.Parse( DropDownList1.SelectedValue.ToString()));
                Response.Write("<script>window.alert('Se modificaron los datos');</script>");
            }else
            {
                Response.Write("<script>window.alert('Vaya vaya! Existe un error');</script>");
            }
        }
    }
}