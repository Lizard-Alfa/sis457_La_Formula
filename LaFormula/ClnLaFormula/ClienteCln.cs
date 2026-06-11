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

        public static int registrar(Cliente cliente)
        {
            using (var context = new LabLaFormulaEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static List<Cliente> buscarPorParametro(string parametro)
        {
            using (var context = new LabLaFormulaEntities())
            {
                if (string.IsNullOrWhiteSpace(parametro))
                {
                    return listar();
                }

                parametro = parametro.ToLower();
                return context.Cliente
                    .Where(x => x.estado == 1 &&
                               (x.nombres.ToLower().Contains(parametro) ||
                                x.primerApellido.ToLower().Contains(parametro) ||
                                x.cedulaIdentidad.ToLower().Contains(parametro) ||
                                x.celular.ToLower().Contains(parametro)))
                    .OrderBy(x => x.nombres)
                    .ToList();
            }
        }
    }
}