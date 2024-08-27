using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public void ModificarEmpleado(int id, string nuevoNombre, string nuevoApellido, decimal nuevoSalario, string nuevocargo)
        {
            var empleado = empleados.FirstOrDefault(e => e.ID == id);
            if (empleado != null)
            {
                empleado.Nombre = nuevoNombre;
                empleado.Apellido = nuevoApellido;
                empleado.Cargo = nuevocargo;
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
                try
                {
                    using (StreamReader sr = new StreamReader("empleados.txt"))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            var datos = linea.Split(',');

                            // Validación de la cantidad de datos
                            if (datos.Length < 5)
                            {
                                Console.WriteLine("Línea con formato incorrecto: " + linea);
                                continue; // Saltar esta línea y continuar con la siguiente
                            }

                            // Validación de los datos
                            if (int.TryParse(datos[0], out int id) &&
                                decimal.TryParse(datos[4], out decimal salario))
                            {
                                Empleado empleado = new Empleado(id, datos[1], datos[2], salario);
                                empleados.Add(empleado);
                            }
                            else
                            {
                                Console.WriteLine("Datos inválidos en la línea: " + linea);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al leer el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El archivo 'empleados.txt' no existe.");
            }
        }
    }

}
