using CadLaFormula;
using System.Data.SqlClient;
using System.Linq;

namespace ClnLaFormula
{
    public static class CompraCln
    {
        public static int registrar(int idProv, int trans, string json)
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Database.SqlQuery<int>("EXEC paCompraRegistrar @idProveedor, @transaccion, @detalles",
                    new SqlParameter("@idProveedor", idProv),
                    new SqlParameter("@transaccion", trans),
                    new SqlParameter("@detalles", json)).FirstOrDefault();
            }
        }
    }
}