using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class login : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();
        //ServiceReference1.WebService1SoapClient prueba = new ServiceReference1.WebService1SoapClient();
        //Response.Write("<script>window.alert('" + prueba.servidorP() + "prueba ');</script>");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string consulta = TextUser.Text;
            string pass = TextPass.Text;

            if (!string.IsNullOrEmpty(consulta))
            {

                //string retorno = referencia.logearUsuario(consulta);
                if (referencia.logearUsuario(consulta).Equals(pass))
                {
                    Response.Redirect("InicioAdmin.aspx");
                }
                else
                {
                    TextPass.Text = "usuario y contraseña erronea";
                }
                TextUser.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}