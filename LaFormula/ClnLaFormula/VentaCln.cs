using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public static class VentaCln
    {
        public static int registrar(int idCli, int idUsr, string json)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Database.SqlQuery<int>("EXEC paVentaRegistrar @idCliente, @idUsuario, @detalles",
                    new SqlParameter("@idCliente", idCli),
                    new SqlParameter("@idUsuario", idUsr),
                    new SqlParameter("@detalles", json)).FirstOrDefault();
            }
        }

        public static List<Venta> listar()
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include("Cliente")
                    .Include("Usuario")
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }
    }
}