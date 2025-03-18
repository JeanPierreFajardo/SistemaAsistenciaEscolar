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
using System.IO;

namespace PROYECTO_X
{

    public partial class RegisEstud_Administrativo : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adaptador;
        DataSet dataSet;
        private Image imagenOriginal;


        public RegisEstud_Administrativo()
        {

            InitializeComponent();            
            imagenOriginal = pictureBox1.Image;
            // Establecer la conexión a la base de datos
            string cadenaConexion = "Data Source =.; Initial Catalog = CONTROL_ASISTENCIA; Integrated Security = True";
            conexion = new SqlConnection(cadenaConexion);

            // Inicializar el adaptador y el DataSet
            adaptador = new SqlDataAdapter("SELECT ESTUDIANTE.*, PADRES.NombreCompletoPadre, PADRES.TelefonoPadre, PADRES.CorreoPadre, PADRES.NombreCompletoMadre, PADRES.TelefonoMadre, PADRES.CorreoMadre FROM ESTUDIANTE INNER JOIN PADRES ON ESTUDIANTE.ID = PADRES.ID", conexion);
            dataSet = new DataSet();

            // Llenar el DataSet con los datos de la vista o consulta combinada
            adaptador.Fill(dataSet, "VistaEstudiantesPadres");

            // Configurar el DataGridView
            dt_1.DataSource = dataSet.Tables["VistaEstudiantesPadres"];
            dt_1.Columns["ID"].Visible = false; // Ocultar la columna ID de la tabla PADRES       

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Administrativo gaaa = new Menu_Administrativo();
            gaaa.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Insertar datos en la tabla PADRES y obtener el ID generado
                SqlCommand comandoPadres = new SqlCommand("INSERT INTO PADRES (NombreCompletoPadre, TelefonoPadre, CorreoPadre, NombreCompletoMadre, TelefonoMadre, CorreoMadre) VALUES (@NombrePadre, @TelefonoPadre, @CorreoPadre, @NombreMadre, @TelefonoMadre, @CorreoMadre); SELECT SCOPE_IDENTITY();", conexion);
                comandoPadres.Parameters.AddWithValue("@NombrePadre", txt_REnombrePadreADMINISTRATIVO.Text);
                comandoPadres.Parameters.AddWithValue("@TelefonoPadre", txt_REtelefonoPadreADMINISTRATIVO.Text);
                comandoPadres.Parameters.AddWithValue("@CorreoPadre", txt_REcorreoPadreADMINISTRATIVO.Text);
                comandoPadres.Parameters.AddWithValue("@NombreMadre", txt_REnombreMadreADMINISTRATIVO.Text);
                comandoPadres.Parameters.AddWithValue("@TelefonoMadre", txt_REtelefonoMadreADMINISTRATIVO.Text);
                comandoPadres.Parameters.AddWithValue("@CorreoMadre", txt_REcorreoMadreADMINISTRATIVO.Text);

                conexion.Open();
                int idPadres = Convert.ToInt32(comandoPadres.ExecuteScalar());
                conexion.Close();

                // Insertar datos en la tabla ESTUDIANTE
                SqlCommand comandoEstudiante = new SqlCommand("INSERT INTO ESTUDIANTE (Nombre, Apellidos, Telefono, Grado, Turno, FechaNacimiento, Correo, Sexo, DNI, Direccion) VALUES (@NombreEstudiante, @ApellidosEstudiante, @TelefonoEstudiante, @GradoEstudiante, @TurnoEstudiante, @FechaNacimientoEstudiante, @CorreoEstudiante, @SexoEstudiante, @DniEstudiante, @DireccionEstudiante);", conexion);
                comandoEstudiante.Parameters.AddWithValue("@NombreEstudiante", txt_REnombreADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@ApellidosEstudiante", txt_REapellidoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@TelefonoEstudiante", txt_REtelefonoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@GradoEstudiante", cb_REgradoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@TurnoEstudiante", cb_REturnoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@FechaNacimientoEstudiante", dtp_fecha.Value);
                comandoEstudiante.Parameters.AddWithValue("@CorreoEstudiante", txt_REcorreoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@SexoEstudiante", cb_REsexoADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@DniEstudiante", txt_REdniADMINISTRATIVO.Text);
                comandoEstudiante.Parameters.AddWithValue("@DireccionEstudiante", txt_REdireccionADMINISTRATIVO.Text);
                //comandoEstudiante.Parameters.AddWithValue("@IDPadres", idPadres);

                conexion.Open();
                comandoEstudiante.ExecuteNonQuery();
                conexion.Close();


                // Actualizar el DataGridView
                dataSet.Tables["VistaEstudiantesPadres"].Clear();
                adaptador.Fill(dataSet, "VistaEstudiantesPadres");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (pictureBox1.Image != null)
            {
                // Convierte la imagen en un arreglo de bytes
                byte[] imagenBytes = ImageToByteArray(pictureBox1.Image);

                // Conexión a la base de datos (reemplaza la cadena de conexión)
                string cadenaConexion = "Data Source =.; Initial Catalog = CONTROL_ASISTENCIA; Integrated Security = True";
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                try
                {
                    conexion.Open();

                    // Query SQL para insertar la imagen en la base de datos
                    string query = "INSERT INTO Fotos (Imagen) VALUES (@Imagen)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.Add("@Imagen", SqlDbType.VarBinary, -1).Value = imagenBytes;

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Imagen subida con éxito.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al subir la imagen: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna imagen.");
            }

        }
        private byte[] ImageToByteArray(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, imagen.RawFormat);
                return ms.ToArray();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagenOriginal;            
            dtp_fecha.MinDate.Ticks.ToString();
            cb_REgradoADMINISTRATIVO.SelectedIndex = -1;
            cb_REsexoADMINISTRATIVO.SelectedIndex = -1;
            cb_REturnoADMINISTRATIVO.SelectedIndex = -1;
            txt_REapellidoADMINISTRATIVO.Clear();
            txt_REcorreoADMINISTRATIVO.Clear();
            txt_REcorreoMadreADMINISTRATIVO.Clear();
            txt_REcorreoPadreADMINISTRATIVO.Clear();
            txt_REdireccionADMINISTRATIVO.Clear();
            txt_REdniADMINISTRATIVO.Clear();
            txt_REedadADMINISTRATIVO.Clear();
            txt_REnombreADMINISTRATIVO.Clear();
            txt_REnombreMadreADMINISTRATIVO.Clear();
            txt_REnombrePadreADMINISTRATIVO.Clear();
            txt_REtelefonoADMINISTRATIVO.Clear();
            txt_REtelefonoMadreADMINISTRATIVO.Clear();
            txt_REtelefonoPadreADMINISTRATIVO.Clear();
            txt_REnombreADMINISTRATIVO.Focus();
        }

        private void btn_registrar_MouseEnter(object sender, EventArgs e)
        {
            btn_registrar.ForeColor = Color.DarkRed;
        }

        private void btn_registrar_MouseLeave(object sender, EventArgs e)
        {
            btn_registrar.ForeColor = Color.Blue;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.ForeColor = Color.DarkRed;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Blue;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.DarkRed;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Blue;
        }

        private void RegisEstud_Administrativo_Load(object sender, EventArgs e)
        {
            dt_1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (dt_1.SelectedRows.Count > 0)
            {
                // Obtener el ID del registro seleccionado
                int idEstudiante = Convert.ToInt32(dt_1.SelectedRows[0].Cells["ID"].Value);

                // Eliminar el registro de la tabla ESTUDIANTE
                SqlCommand comandoBorrar = new SqlCommand("DELETE FROM ESTUDIANTE WHERE ID = @ID", conexion);
                comandoBorrar.Parameters.AddWithValue("@ID", idEstudiante);

                try
                {
                    conexion.Open();
                    comandoBorrar.ExecuteNonQuery();
                    conexion.Close();

                    // Actualizar el DataGridView
                    dataSet.Tables["VistaEstudiantesPadres"].Clear();
                    adaptador.Fill(dataSet, "VistaEstudiantesPadres");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Filtros de archivos de imagen
            openFileDialog1.Title = "Seleccionar imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtén la ruta del archivo seleccionado y muestra la imagen en el PictureBox
                string rutaArchivo = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(rutaArchivo);
            }
        }
    }
}

