using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public class CategoriaCln
    {
        public static List<Categoria> listar()
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Categoria
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }
    }
}
