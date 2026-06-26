using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public static class VentaCln
    {
        public static int registrar(int idCliente, int idUsuario, List<VentaDetalle> detalles, string metodoPago = "EFECTIVO", string pagosMixtos = "")
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                decimal total = detalles.Sum(d => d.subtotal);

                var venta = new Venta
                {
                    idCliente = idCliente,
                    idUsuario = idUsuario,
                    fecha = DateTime.Now,
                    total = total,
                    metodoPago = metodoPago,
                    pagos = pagosMixtos,
                    usuarioRegistro = Environment.UserName,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };

                ctx.Venta.Add(venta);
                ctx.SaveChanges();

                foreach (var detalle in detalles)
                {
                    var detalleVenta = new VentaDetalle
                    {
                        idVenta = venta.id,
                        idProducto = detalle.idProducto,
                        cantidad = detalle.cantidad,
                        precioUnitario = detalle.precioUnitario,
                        subtotal = detalle.subtotal,
                        usuarioRegistro = Environment.UserName,
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    };

                    ctx.VentaDetalle.Add(detalleVenta);

                    var producto = ctx.Producto.Find(detalle.idProducto);
                    if (producto != null)
                    {
                        producto.saldo -= detalle.cantidad;
                    }
                }

                ctx.SaveChanges();
                return (int)venta.id;
            }
        }

        // Listar todas las ventas activas
        public static List<Venta> listar()
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .Where(v => v.estado == 1)
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }

        // Listar TODAS las ventas (activas y anuladas)
        public static List<Venta> listarTodas()
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }

        // Obtener una venta por ID con todos sus detalles
        public static Venta obtenerPorId(int id)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .Include(v => v.VentaDetalle.Select(vd => vd.Producto))
                    .FirstOrDefault(v => v.id == id && v.estado == 1);
            }
        }

        // Obtener los detalles de una venta específica
        public static List<VentaDetalle> obtenerDetallesPorVenta(long idVenta)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.VentaDetalle
                    .Where(vd => vd.idVenta == idVenta && vd.estado == 1)
                    .Include(vd => vd.Producto)
                    .ToList();
            }
        }

        // Anular una venta (restaurar stock)
        public static bool anular(int id)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                var venta = ctx.Venta
                    .Include(v => v.VentaDetalle)
                    .FirstOrDefault(v => v.id == id && v.estado == 1);

                if (venta == null)
                    return false;

                venta.estado = 0;

                foreach (var detalle in venta.VentaDetalle)
                {
                    var producto = ctx.Producto.Find(detalle.idProducto);
                    if (producto != null)
                    {
                        producto.saldo += detalle.cantidad;
                    }
                }

                ctx.SaveChanges();
                return true;
            }
        }

        // Buscar ventas por fecha
        public static List<Venta> buscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .Where(v => v.estado == 1 && v.fecha >= fechaInicio && v.fecha <= fechaFin)
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }

        // Buscar ventas por cliente
        public static List<Venta> buscarPorCliente(int idCliente)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .Where(v => v.estado == 1 && v.idCliente == idCliente)
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }

        // Buscar ventas por usuario
        public static List<Venta> buscarPorUsuario(int idUsuario)
        {
            using (var ctx = new LabLaFormulaEntities())
            {
                return ctx.Venta
                    .Include(v => v.Cliente)
                    .Include(v => v.Usuario)
                    .Where(v => v.estado == 1 && v.idUsuario == idUsuario)
                    .OrderByDescending(v => v.fecha)
                    .ToList();
            }
        }
    }
}