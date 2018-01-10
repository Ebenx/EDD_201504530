using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class IngresarUsuario : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nickname = TextNick.Text , pass= TextPass.Text, email= TextEmail.Text;
            int conectado = int.Parse( DropDownList1.SelectedValue.ToString());
            
            if (!string.IsNullOrEmpty( nickname) && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(email))
            {
                referencia.insertarUsuario(nickname,pass,email, conectado);
                Response.Write("<script>window.alert('Usuario Ingresado');</script>");
                TextNick.Text = "";
                TextPass.Text = "";
                TextEmail.Text = "";
            }
            else
            {
                Response.Write("<script>window.alert('Vaya vaya hacen falta datos');</script>");
            }
            
        }
    }
}