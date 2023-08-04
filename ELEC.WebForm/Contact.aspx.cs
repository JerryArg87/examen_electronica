using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ELEC.EntityLayer;
using ELEC.BusinessLayer;
using System.Globalization;

namespace ELEC.WebForm
{
    public partial class Contact : Page
    {
        private static int idProducto = 0;
        CategoriaBL categoriaBL = new CategoriaBL();
        ProductoBL productoBL = new ProductoBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idProducto"] != null)
                {
                    idProducto = Convert.ToInt32(Request.QueryString["idProducto"].ToString());

                    if(idProducto != 0)
                    {
                        lblTitulo.Text = "Editar Producto";
                        btnSubmit.Text = "Editar";

                        Producto producto = productoBL.Obtener(idProducto);
                        txtNombreProducto.Text = producto.NombreProducto;
                        CargarCategorias(producto.IdProducto.ToString());
                        txt_fechaAlta.Text = Convert.ToDateTime(producto.FechaAlta, new CultureInfo("es-MX")).ToString("yyyy-MM-dd");
                        if(producto.FechaBaja == "")
                            txt_fechaBaja.Text = "";
                        else
                            txt_fechaBaja.Text = Convert.ToDateTime(producto.FechaBaja, new CultureInfo("es-MX")).ToString("yyyy-MM-dd");

                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Producto";
                        btnSubmit.Text = "Guardar";
                        CargarCategorias();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void CargarCategorias(string idCategoria = "")
        {
            List<Categoria> lista = categoriaBL.Lista();

            ddlCategorias.DataTextField = "NombreCategoria";
            ddlCategorias.DataValueField = "idCategoria";

            ddlCategorias.DataSource = lista;
            ddlCategorias.DataBind();

            if (idCategoria != "")
            {
                ddlCategorias.SelectedValue = idCategoria;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Producto entidad = new Producto()
            {
                IdProducto = idProducto,
                NombreProducto = txtNombreProducto.Text,
                IdCategoria = new Categoria() { IdCategoria = Convert.ToInt32(ddlCategorias.SelectedValue) },
                FechaAlta = txt_fechaAlta.Text,
                FechaBaja = txt_fechaBaja.Text
            };
            bool res;

            if (idProducto != 0)        
                res = productoBL.Editar(entidad);           
            else            
                res = productoBL.Crear(entidad);

            if (res)
                Response.Redirect("~/Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se realizo la operacion')", true);
        }
    }
}