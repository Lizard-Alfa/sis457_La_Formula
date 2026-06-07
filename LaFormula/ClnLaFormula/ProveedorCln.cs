using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadLaFormula;
namespace ClnLaFormula
{
    public static class ProveedorCln
    {
        public static List<Proveedor> listar()
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Proveedor.Where(x => x.estado == 1).OrderBy(x => x.razonSocial).ToList();
            }
        }
    }
}
