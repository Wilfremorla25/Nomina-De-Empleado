using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina_De_Empleado
{
    public partial class Form1 : Form
    {
        //  clase GestionEmpleados
        private GestionEmpleados gestionEmpleados;

        public Form1()
        {
            InitializeComponent();
        }

        // Codigo para cargar el formulario y los datos desde el archivo
        private void Form1_Load(object sender, EventArgs e)
        {
            gestionEmpleados = new GestionEmpleados();
            gestionEmpleados.CargarDesdeArchivo();
            ActualizarDataGridView();
        }

        // Codigo para actualizar el DataGridView con la lista de empleados
        private void ActualizarDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestionEmpleados.ListarEmpleados();
        }

        // Codigo para agregar un nuevo empleado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                decimal salario = decimal.Parse(txtSalario.Text);

                gestionEmpleados.AgregarEmpleado(new Empleado(id, nombre, apellido, salario));
                ActualizarDataGridView();
                MessageBox.Show("Empleado agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ploblemas al agregar el empleado: {ex.Message}");
            }
        }

        // Codigo para editar un empleado existente
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string nuevoNombre = txtNombre.Text;
                string nuevoApellido = txtApellido.Text;
                decimal nuevoSalario = decimal.Parse(txtSalario.Text);

                gestionEmpleados.ModificarEmpleado(id, nuevoNombre, nuevoApellido, nuevoSalario);
                ActualizarDataGridView();
                MessageBox.Show("Empleado modificado con exito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas al modificar el empleado: {ex.Message}");
            }
        }

        // Codigo para buscar un empleado por ID
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                var empleado = gestionEmpleados.BuscarEmpleado(id);

                if (empleado != null)
                {
                    txtNombre.Text = empleado.Nombre;
                    txtApellido.Text = empleado.Apellido;
                    txtSalario.Text = empleado.Salario.ToString();
                    MessageBox.Show("Empleado encontrado.");
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas al buscar el empleado: {ex.Message}");
            }
        }

        // Codigo para eliminar un empleado por ID
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);

                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    gestionEmpleados.EliminarEmpleado(id);
                    ActualizarDataGridView();
                    MessageBox.Show("Empleado eliminado con exito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}");
            }
        }

        // Codigo para salir de la aplicacion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea salir de la aplicacion?", "Salir", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Control sobre el DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
