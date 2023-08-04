using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ELEC.EntityLayer;
using ELEC.BusinessLayer;

namespace ELEC.WebForm
{
    public partial class _Default : Page
    {
        ProductoBL productoBL = new ProductoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            List<Producto> lista = productoBL.Lista();

            GVProductos.DataSource = lista;
            GVProductos.DataBind();
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?idProducto=0");
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idProducto = btn.CommandArgument;

            Response.Redirect("~/Contact.aspx?idProducto=" + idProducto);
        }

        protected void Eliminar_click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idProducto = btn.CommandArgument;

            bool res = productoBL.Eliminar(Convert.ToInt32(idProducto));

            if (res)
                MostrarProductos();
        }

    }
}











