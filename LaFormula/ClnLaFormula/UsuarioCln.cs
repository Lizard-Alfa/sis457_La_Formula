using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public  class UsuarioCln
    {
        public static Usuario validar(string usuario, string clave)
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Usuario
                    .Where(x => x.usuario1 == usuario && x.clave == clave)
                    .FirstOrDefault();
            }
                    
        }
    }
}
