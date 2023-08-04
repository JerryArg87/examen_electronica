using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ELEC.DataLayer;
using ELEC.EntityLayer;

namespace ELEC.BusinessLayer
{
    public class CategoriaBL
    {
        CategoriaDL categoriaDL = new CategoriaDL();

        public List<Categoria> Lista()
        {
            try
            {
                return categoriaDL.Lista();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
