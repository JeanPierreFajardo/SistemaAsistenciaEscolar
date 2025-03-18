using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_X
{
    public partial class Visualizar_Asistencia : Form
    {
        public Visualizar_Asistencia()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Obtener el grado y turno seleccionados en los ComboBox
            string gradoSeleccionado = cb_grado.SelectedItem.ToString();
            string turnoSeleccionado = cb_turno.SelectedItem.ToString();

            // Construir la consulta SQL para seleccionar estudiantes por grado y turno
            string consultaSql = "SELECT Nombre, Apellidos, Grado, Turno FROM ESTUDIANTE WHERE Grado = @Grado AND Turno = @Turno";

            // Configurar la conexión y el comando SQL
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(consultaSql, connection))
            {
                // Establecer los parámetros de la consulta SQL
                command.Parameters.AddWithValue("@Grado", gradoSeleccionado);
                command.Parameters.AddWithValue("@Turno", turnoSeleccionado);

                // Crear un adaptador de datos para llenar un DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    // Abrir la conexión y llenar el DataTable con los resultados de la consulta
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión
                    connection.Close();
                }

                // Asignar el DataTable como origen de datos del DataGridView
                dt_asistencia.DataSource = dataTable;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu_Docente gaa = new Menu_Docente();
            gaa.Show();
        }
    }
}
