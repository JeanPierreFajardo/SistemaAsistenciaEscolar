using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;

namespace PROYECTO_X
{
    public partial class Generar_Reportes : Form
    {
        private SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=CONTROL_ASISTENCIA;Integrated Security=True";
        string query = "SELECT * FROM ReportesEstudiantes";
        public Generar_Reportes()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Administrativo gaaa = new Menu_Administrativo();
            gaaa.Show();
        }

        private void Generar_Reportes_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Configurar el DataGridView para mostrar los datos
                dt_reportes.DataSource = table;
                // Oculta la columna de ID si no se necesita mostrarla.                
                dt_reportes.Columns["EstudianteID"].Visible = false;
                dt_reportes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                string pdfFilePath = "C:/Users/IESTPFFAA/Documents/1.pdf";

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                doc.Open();

                // Obtener los datos seleccionados del DataGridView dt_reportes
                foreach (DataGridViewRow row in dt_reportes.SelectedRows)
                {
                    string estudiante = row.Cells["Estudiante"].Value.ToString();
                    string fecha = row.Cells["Fecha"].Value.ToString();
                    string tipoReporte = row.Cells["TipoReporte"].Value.ToString();
                    string descripcion = row.Cells["Descripcion"].Value.ToString();

                    // Agregar la información al PDF
                    doc.Add(new Paragraph($"Estudiante: {estudiante}"));
                    doc.Add(new Paragraph($"Fecha: {fecha}"));
                    doc.Add(new Paragraph($"Tipo de Reporte: {tipoReporte}"));
                    doc.Add(new Paragraph($"Descripción: {descripcion}"));
                    doc.Add(new Paragraph("-------------------------------"));
                }

                // Cerrar el documento PDF
                doc.Close();

                Console.WriteLine("PDF generado exitosamente en: " + pdfFilePath);
            }
            catch
            {
                MessageBox.Show("POR FAVOR ELIGA UNA DE LAS OPCIONES ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dt_reportes.SelectedRows.Count > 0)
            {
                int selectedRow = dt_reportes.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dt_reportes["ID", selectedRow].Value);

                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Usuarios WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@ID", userId);
                    command.ExecuteNonQuery();

                    // Elimina la fila seleccionada del DataGridView.
                    dt_reportes.Rows.RemoveAt(selectedRow);
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor=Color.DarkRed;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Blue;
        }
    }
}
