namespace Nomina_De_Empleado
{
    public class Empleado
    {
        private string v1;
        private string v2;

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Salario { get; set; }

        public string Cargo { get; set; }

        public Empleado(int id, string nombre, string apellido, decimal salario, string cargo)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Salario = salario;
            Cargo = cargo;
        }

        public Empleado(int id, string v1, string v2, decimal salario)
        {
            ID = id;
            this.v1 = v1;
            this.v2 = v2;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{ID},{Nombre},{Apellido},{Salario},{Cargo}";
        }
    }

}

