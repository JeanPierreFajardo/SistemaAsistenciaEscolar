using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PROYECTO_X
{
    public partial class Gestionar_Usuario_Administrativo : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CONTROL_ASISTENCIA;Integrated Security=True");
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        

        public Gestionar_Usuario_Administrativo()
        {
            InitializeComponent();
            dataTable = new DataTable();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Usuarios";
                dataAdapter = new SqlDataAdapter(selectQuery, connection);
                dataAdapter.Fill(dataTable);

                dtgv_usuarios.DataSource = dataTable;

                // Oculta la columna de ID si no se necesita mostrarla.
                dtgv_usuarios.Columns["ID"].Visible = false;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btn_sesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu_Administrativo raa = new Menu_Administrativo();
            raa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Crear_Usuario gaa = new Crear_Usuario();
            gaa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            LoadData();            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btn_VisualizarUsuarios.ForeColor = Color.DarkRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_VisualizarUsuarios.ForeColor = Color.Blue;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            btn_CrearUsuario.ForeColor = Color.DarkRed;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            btn_CrearUsuario.ForeColor = Color.Blue;
        }
        private void Gestionar_Usuario_Administrativo_Load(object sender, EventArgs e)
        {

        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btn_BorrarUsuario.ForeColor = Color.DarkRed;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btn_BorrarUsuario.ForeColor = Color.Blue;
        }
        private void btn_sesion_MouseEnter(object sender, EventArgs e)
        {
            btn_regresar.ForeColor = Color.DarkRed;
        }
        private void btn_sesion_MouseLeave(object sender, EventArgs e)
        {
            btn_regresar.ForeColor = Color.Blue;
        }
        private void Btn_BorrarUsuario_Click(object sender, EventArgs e)
        {
            if (dtgv_usuarios.SelectedRows.Count > 0)
            {
                int selectedRow = dtgv_usuarios.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dtgv_usuarios["ID", selectedRow].Value);

                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Usuarios WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@ID", userId);
                    command.ExecuteNonQuery();

                    // Elimina la fila seleccionada del DataGridView.
                    dtgv_usuarios.Rows.RemoveAt(selectedRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al borrar usuario: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para borrar.");
            }
        }
    }
}
