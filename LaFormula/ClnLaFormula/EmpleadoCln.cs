using CadLaFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnLaFormula
{
    public class EmpleadoCln
    {
        public static int crear(Empleado empleado)
        {
            using (var context = new LabLaFormulaEntities())
            {
                context.Empleado.Add(empleado);
                context.SaveChanges();
                return empleado.id;
            }
        }
        public static int modificar(Empleado empleado)
        {
            using (var context = new LabLaFormulaEntities())
            {
                var existente = context.Empleado.Find(empleado.id);
                if (existente != null)
                {
                    existente.cedulaIdentidad = empleado.cedulaIdentidad;
                    existente.nombres = empleado.nombres;
                    existente.primerApellido = empleado.primerApellido;
                    existente.segundoApellido = empleado.segundoApellido;
                    existente.fechaNacimiento = empleado.fechaNacimiento;
                    existente.direccion = empleado.direccion;
                    existente.celular = empleado.celular;
                    existente.cargo = empleado.cargo;
                    existente.usuarioRegistro = empleado.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabLaFormulaEntities())
            {
                var existente = context.Empleado.Find(id);
                if (existente != null)
                {
                    existente.estado = -1;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static Empleado obtenerUno(int id)
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Empleado.Find(id);
            }
        }
        public static List<Empleado> listar()
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.Empleado
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombres)
                    .ToList();
            }
        }
        public static List<paEmpleadoListar_Result> listarEn(string parametro)
        {
            using (var context = new LabLaFormulaEntities())
            {
                return context.paEmpleadoListar (parametro.Trim()).ToList();
            }
        }
    }
}
