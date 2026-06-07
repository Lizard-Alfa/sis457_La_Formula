using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public static class ClienteCln
    {
        public static List<Cliente> listar()
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Cliente
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombres)
                    .ToList();
            }
        }
    }
}