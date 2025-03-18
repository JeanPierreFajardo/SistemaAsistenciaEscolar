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
    public partial class Crear_Usuario : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CONTROL_ASISTENCIA;Integrated Security=True");
        private Gestionar_Usuario_Administrativo gestionarUsuarios;
        //Gestionar_Usuario_Administrativo enviar = new Gestionar_Usuario_Administrativo();
        public Crear_Usuario(Gestionar_Usuario_Administrativo form)
        {
            
            gestionarUsuarios = form;
        }

        public Crear_Usuario()
        {
            InitializeComponent();
        }

        private void Btn_agregar1_Click(object sender, EventArgs e)
        {
            string usuario = txt_crearusuario.Text;
            string contraseña = txt_contraseña_usuario.Text;
            string tipoUsuario = cb_crearusuario.SelectedItem.ToString();
            

            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO Usuarios (Usuario, Contraseña, TipoUsuario) VALUES (@Usuario, @Contraseña, @TipoUsuario)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);                
                command.ExecuteNonQuery();

                
                

                MessageBox.Show("Usuario agregado con éxito.");
                this.Close();
                Gestionar_Usuario_Administrativo GAA = new Gestionar_Usuario_Administrativo();
                GAA.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            /*enviar.pnombre = txt_nombre1.Text;
            enviar.pnacmiento = txt_naci.Text;
            enviar.pcontraseña = txt_contraseña_usuario.Text;
            enviar.pusuario = txt_crearusuario.Text;
            enviar.pcreacion = txt_fecha.Text;
            enviar.pdni = txt_dni.Text;           
            enviar.Show();     */
        }               

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void Crear_Usuario_Load(object sender, EventArgs e)
        {
            /*DateTime fecha = DateTime.Now;
            txt_fecha.Text = fecha.ToString();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*txt_nombre1.Clear();
            txt_naci.Clear();
            txt_fecha.Clear();
            DateTime fecha = DateTime.Now;
            txt_fecha.Text = fecha.ToString();
            txt_dni.Clear();*/
            txt_crearusuario.Clear();
            txt_contraseña_usuario.Clear();
            cb_crearusuario.SelectedIndex=-1;
            txt_crearusuario.Focus();
        }

        private void btn_agregar1_MouseEnter(object sender, EventArgs e)
        {
            btn_agregar1.ForeColor = Color.DarkRed;
        }

        private void btn_agregar1_MouseLeave(object sender, EventArgs e)
        {
            btn_agregar1.ForeColor = Color.Blue;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.DarkRed;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Blue;
        }
    }
}
