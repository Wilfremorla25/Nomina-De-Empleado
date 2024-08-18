using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina_De_Empleado
{
    public class GestionEmpleados
    {
        private List<Empleado> empleados;

        public GestionEmpleados()
        {
            empleados = new List<Empleado>();
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
            GuardarEnArchivo();
        }

        public void ModificarEmpleado(int id, string nuevoNombre, string nuevoApellido, decimal nuevoSalario)
        {
            var empleado = empleados.FirstOrDefault(e => e.ID == id);
            if (empleado != null)
            {
                empleado.Nombre = nuevoNombre;
                empleado.Apellido = nuevoApellido;
                empleado.Salario = nuevoSalario;
                GuardarEnArchivo();
            }
        }

        public Empleado BuscarEmpleado(int id)
        {
            return empleados.FirstOrDefault(e => e.ID == id);
        }

        public void EliminarEmpleado(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.ID == id);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                GuardarEnArchivo();
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            return empleados;
        }

        private void GuardarEnArchivo()
        {
            using (StreamWriter sw = new StreamWriter("empleados.txt"))
            {
                foreach (var empleado in empleados)
                {
                    sw.WriteLine(empleado.ToString());
                }
            }
        }

        public void CargarDesdeArchivo()
        {
            if (File.Exists("empleados.txt"))
            {
                using (StreamReader sr = new StreamReader("empleados.txt"))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        var datos = linea.Split(',');
                        var empleado = new Empleado(
                            int.Parse(datos[0]),
                            datos[1],
                            datos[2],
                            decimal.Parse(datos[3]));
                        empleados.Add(empleado);
                    }
                }
            }
        }
    }

}
