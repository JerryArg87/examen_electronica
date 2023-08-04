using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ELEC.DataLayer;
using ELEC.EntityLayer;

namespace ELEC.BusinessLayer
{
    public class ProductoBL
    {
        ProductoDL productoDL = new ProductoDL();
        public List<Producto> Lista()
        {
            try
            {
                return productoDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto Obtener( int idProducto)
        {
            try
            {
                return productoDL.Obtener( idProducto );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Crear(Producto entidad)
        {
            try
            {
                if (entidad.NombreProducto == "")
                    throw new OperationCanceledException("El campo producto no debe de ir vacio");

                return productoDL.Crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Editar(Producto entidad)
        {
            try
            {
                var productoEncontrar = productoDL.Obtener(entidad.IdProducto);

                if (productoEncontrar.IdProducto == 0)
                    throw new OperationCanceledException("El producto no existe");

                if (productoEncontrar.NombreProducto == "")
                    throw new OperationCanceledException("El Campos producto no puede ir vacio");

                return productoDL.Editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(int idProducto)
        {
            try
            {
                var productoEncontrar = productoDL.Obtener(idProducto);

                if (productoEncontrar.IdProducto == 0)
                    throw new OperationCanceledException("El producto no existe");

                return productoDL.Eliminar(idProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
