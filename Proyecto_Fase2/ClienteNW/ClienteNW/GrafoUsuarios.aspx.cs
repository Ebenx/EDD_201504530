using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class GrafoUsuarios : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            byte[] imagen = referencia.graficarABB();
            string base64 = Convert.ToBase64String(imagen, 0, imagen.Length);
            ImagenUsuario.Src = "data:Image/jpg;base64," + base64;

            byte[] imagen2 = referencia.graficarABBEspejo();
            string base642 = Convert.ToBase64String(imagen2, 0, imagen2.Length);
            ImagenEpejo.Src = "data:Image/jpg;base64," + base642;

        }
    }
}