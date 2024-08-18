using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina_De_Empleado
{
     public class Empleado
    {
       

    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public decimal Salario { get; set; }

    public Empleado(int id, string nombre, string apellido, decimal salario)
    {
        ID = id;
        Nombre = nombre;
        Apellido = apellido;
        Salario = salario;
    }

    public override string ToString()
    {
        return $"{ID},{Nombre},{Apellido},{Salario}";
    }
}

    }

