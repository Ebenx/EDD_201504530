using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class cargaMasiva : System.Web.UI.Page
    {
        ServiceReference1.ServiceNavalWarsSoapClient referencia = new ServiceReference1.ServiceNavalWarsSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string contenido = "";
            if (FileUpload1.HasFile)
            {
                contenido = System.Text.Encoding.UTF8.GetString(FileUpload1.FileBytes);
                char delimitadorLinea = Convert.ToChar(10);
                string[] lineas = contenido.Split(delimitadorLinea);
                string[] datos;
                int tamano = lineas.Length;
                for (int i=1; i<tamano;i++)
                {

                    if (!String.IsNullOrEmpty(lineas[i]))
                    {
                        datos = lineas[i].Split(',');
                        referencia.insertarUsuario(datos[0], datos[1], datos[2], Convert.ToInt32(datos[3]));
                    }
                }
            }else
            {
                Response.Write("<script>window.alert('Escoja un archivo');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string contenido = "";
            if (FileUpload1.HasFile)
            {
                contenido = System.Text.Encoding.UTF8.GetString(FileUpload1.FileBytes);
                char delimitadorLinea = Convert.ToChar(10);
                string[] lineas = contenido.Split(delimitadorLinea);
                string[] datos;
                int tamano = lineas.Length;
                for (int i = 1; i < tamano; i++)
                {

                    if (!String.IsNullOrEmpty(lineas[i]))
                    {
                        datos = lineas[i].Split(',');
                        referencia.insertarHistorialJuego(datos[0], datos[1], Convert.ToInt32(datos[2]), Convert.ToInt32(datos[3]), Convert.ToInt32(datos[4]), Convert.ToInt32(datos[5].Trim()));
                    }
                }
            }
            else
            {
                Response.Write("<script>window.alert('Escoja un archivo');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}