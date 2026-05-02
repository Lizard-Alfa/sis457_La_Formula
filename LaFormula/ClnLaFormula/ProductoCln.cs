using System;
using CadLaFormula;
using System.Collections.Generic;
using System.Linq;

namespace ClnLaFormula
{
    public class ProductoCln  // ← FALTABA: 'public' 
    {
        public static int crear(Producto producto)
        {
            using (var context = new LabLaFormulaEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.id;
            }
        }

        public static int modificar(Producto producto)
        {
            using (var context = new LabLaFormulaEntities())
            {
                var existente = context.Producto.Find(producto.id);
                if (existente != null)
                {
                    existente.idUnidadMedida = producto.idUnidadMedida;
                    existente.idCategoria = producto.idCategoria; // ← Faltaba Agregar
                    existente.codigo = producto.codigo;
                    existente.descripcion = producto.descripcion;
                    existente.marca = producto.marca;             // ← Faltaba Agregar
                    existente.ubicacionBodega = producto.ubicacionBodega; // ← Faltaba Agregar
                    existente.saldo = producto.saldo;
                    existente.precioVenta = producto.precioVenta;
                    existente.factor = producto.factor;           // ← Faltaba Agregar
                    existente.usuarioRegistro = producto.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabLaFormulaEntities())
            {
                var existente = context.Producto.Find(id);
                if (existente != null)
                {
                    existente.estado = -1;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Producto obtenerUno(int id)
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Producto.Find(id);
            }
        }

        public static List<Producto> listar()
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Producto
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.descripcion)
                    .ToList();
            }
        }
        public static List<CadLaFormula.paProductoListar_Result> listarPorParametro(string parametro)
{
    using (var context = new CadLaFormula.LabLaFormulaEntities())
    {
                return context.paProductoListar(parametro.Trim()).ToList(); // ← Este era el error que no tenia referencia
            }
        }
    }
}
