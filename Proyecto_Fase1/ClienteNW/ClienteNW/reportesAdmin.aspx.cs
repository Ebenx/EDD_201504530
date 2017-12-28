using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteNW
{
    public partial class reportesAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("GrafoUsuarios.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}