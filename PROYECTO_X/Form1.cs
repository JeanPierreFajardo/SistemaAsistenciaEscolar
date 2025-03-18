using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace PROYECTO_X
{
    public partial class Form1 : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CONTROL_ASISTENCIA;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_usuario.Text=="")
                {
                    txt_usuario.Text = "In gresar Usuario";
                    return;
                }
                txt_usuario.ForeColor = Color.SteelBlue;
                pn_1.Visible = false;                
            }
            catch
            {

            }
        }

        private void txt_usuario_Click(object sender, EventArgs e)
        {
            txt_usuario.SelectAll();
        }

        private void txt_contraseña_Click(object sender, EventArgs e)
        {
            txt_contraseña.SelectAll();
        }

        private void btn_sesion_MouseEnter(object sender, EventArgs e)
        {
            btn_sesion.ForeColor = Color.Red;
        }

        private void btn_sesion_MouseLeave(object sender, EventArgs e)
        {
            btn_sesion.ForeColor = Color.Blue;
        }

        private void btn_sesion_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "Ingresar Usuario")
            {
                MessageBox.Show("POR FAVOR INGRESE SU USUARIO", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pn_1.Visible = true;
                txt_usuario.Focus();
                return;
            }
            else if (txt_contraseña.Text == "Ingresar Contraseña")
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pn2.Visible = true;
                txt_contraseña.Focus();
                return;
            }
            else if (txt_contraseña.Text == "")
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pn2.Visible = true;
                txt_contraseña.Focus();
                return;
            }
            else
            {

            }

            string usuario = txt_usuario.Text;
            string contraseña = txt_contraseña.Text;
            string TipoUsuario = cb_usuario.SelectedItem.ToString();

            try
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña AND TipoUsuario = @TipoUsuario";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);
                command.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    if (cb_usuario.Text == "Administrador")
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                        this.Hide();
                        loading newform0 = new loading();
                        newform0.Show();

                    }
                    if (cb_usuario.Text == "Secretaria")
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                        this.Hide();
                        loading1 newform0 = new loading1();
                        newform0.Show();

                    }
                    if (cb_usuario.Text == "Docente")
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                        this.Hide();
                        loading2 newform0 = new loading2();
                        newform0.Show();

                    }

                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.");
                    pn_1.Visible = true;
                    txt_usuario.Focus();

                    pn2.Visible = true;
                    txt_contraseña.Focus();
                    
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            /*try
            {
                TextReader Inicio = new StreamReader(txt_usuario.Text + ".txt");
                if ((Inicio.ReadLine() == txt_contraseña.Text) && (cb_usuario.Text == "Administrador"))
                {
                    
                    this.Hide();
                    loading newform0 = new loading();
                    newform0.Show();
                    
                }                
                TextReader InicioS = new StreamReader(txt_usuario.Text + ".txt");
                if ((InicioS.ReadLine() == txt_contraseña.Text) && (cb_usuario.Text == "Secretaria"))
                {
                    
                    this.Hide();
                    loading1 newform0 = new loading1();
                    newform0.Show();
                    
                }                
                TextReader InicioSS = new StreamReader(txt_usuario.Text + ".txt");
                if ((InicioSS.ReadLine() == txt_contraseña.Text) && (cb_usuario.Text == "Docente"))
                {
                    
                    this.Hide();
                    loading2 newform0 = new loading2();
                    newform0.Show();
                    
                }                  
            }
            catch(Exception)
            {
                MessageBox.Show("Credenciales Incorrectas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pn_1.Visible = true;
                txt_usuario.Focus();
                
                pn2.Visible = true;
                txt_contraseña.Focus();                
                
                return;
            }    */


        }

        private void pn_usuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_iniciosesion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_2_Click(object sender, EventArgs e)
        {

        }

        private void pn_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_contraseña.ForeColor = Color.SteelBlue;

                txt_contraseña.PasswordChar = '*';

                pn2.Visible = false;
            }
            catch
            {

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pn2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_registrar_MouseDown(object sender, MouseEventArgs e)
        {
            btn_registrar.ForeColor = Color.Red;
        }

        private void btn_registrar_MouseLeave(object sender, EventArgs e)
        {
            btn_registrar.ForeColor = Color.Blue;
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {            

            if (txt_rusuario.Text == "Ingresar Usuario")
                {
                    MessageBox.Show("INGRESE UN VALOR", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn_usuario.Visible = true;
                    txt_rusuario.Focus();
                    return;
                }
                else if (txt_rcontraseña.Text == "Ingresar Contraseña")
                {
                    MessageBox.Show("INGRESE UNA CONTRASEÑA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn_contraseña.Visible = true;
                    txt_rcontraseña.Focus();
                    return;
                }
                else if (txt_rcontraseña.Text =="")
                {
                    MessageBox.Show("INGRESE UNA CONTRASEÑA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn_contraseña.Visible = true;
                    txt_rcontraseña.Focus();
                    return;
                }                
                else if (txt_vcontraseña.Text == "Vuelve a ingresar la contraseña")
                {
                    MessageBox.Show("LA CONTRASEÑA NO COINCIDE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn_vcontraseña.Visible = true;
                    txt_vcontraseña.Focus();
                    return;
                }
                else if (txt_vcontraseña.Text =="")
                {
                    MessageBox.Show("LA CONTRASEÑA NO COINCIDE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn_vcontraseña.Visible = true;
                    txt_vcontraseña.Focus();
                    return;
                }
                else if (txt_vcontraseña.Text != txt_rcontraseña.Text)
                {
                    MessageBox.Show("LA CONTRASEÑA NO COINCIDE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pn_vcontraseña.Visible = true;
                    txt_vcontraseña.Focus();
                    return;
                }

            string rusuario = txt_rusuario.Text;
            string rcontraseña = txt_rcontraseña.Text;
            string tipoUsuario = cb_1.SelectedItem.ToString();

            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO Usuarios (Usuario, Contraseña, TipoUsuario) VALUES (@Usuario, @Contraseña, @TipoUsuario)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Usuario", rusuario);
                command.Parameters.AddWithValue("@Contraseña", rcontraseña);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);
                command.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado con éxito.");
                pn_iniciosesion.Visible = true;
                pn_registro.Visible = false;
                pn_iniciosesion.Dock = DockStyle.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            /*if (txt_rcontraseña.Text==txt_vcontraseña.Text)
            {          
                TextWriter ResgistrarUsusario = new StreamWriter(@"D:\Descargas\FAJARDO_NANO_JEANPIERRE_T15\PROYECTO_X\PROYECTO_X\bin\Debug\" + txt_rusuario.Text + ".txt", true);
                ResgistrarUsusario.WriteLine(txt_rcontraseña.Text);
                ResgistrarUsusario.Close();
                MessageBox.Show("Se registro Correctamente","Felicitaciones",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    pn_iniciosesion.Visible = true;
                
                pn_registro.Visible = false;
                pn_iniciosesion.Dock = DockStyle.None;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden","Notificacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }*/
        }

        private void txt_rusuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_rusuario.Text == "")
                {
                    txt_rusuario.Text = "Ingresar Usuario";
                    return;
                }
                txt_rusuario.ForeColor = Color.SteelBlue;
                pn_usuario.Visible = false;
            }
            catch
            {

            }                        
        }
        private void txt_rcontraseña_TextChanged(object sender, EventArgs e)
        {
            try
            {                
                txt_rcontraseña.ForeColor = Color.SteelBlue;
                pn_contraseña.Visible = false;
                txt_rcontraseña.PasswordChar = '*';
            }
            catch
            {

            }            
        }
        private void txt_vcontraseña_TextChanged(object sender, EventArgs e)
        {
            try
            {                 
                txt_vcontraseña.ForeColor = Color.SteelBlue;
                txt_vcontraseña.PasswordChar = '*';
                pn_vcontraseña.Visible = false;
            }
            catch
            {

            }            
        }
        private void pn_usuario_Paint_1(object sender, PaintEventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pn_iniciosesion.Visible = true;
            
            pn_registro.Visible = false;
            pn_iniciosesion.Dock = DockStyle.None;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pn_iniciosesion.Visible = false;
            pn_registro.Visible = true;
            
            
            pn_iniciosesion.Dock = DockStyle.Fill;
        }       

        private void cb_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void pn_vcontraseña_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Chk_contraseña_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Chk_contraseña_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_contraseña.Checked == true)
            {
                if (txt_contraseña.PasswordChar == '*')
                {
                    txt_contraseña.PasswordChar = '\0';
                }

            }
            else
            {
                txt_contraseña.PasswordChar = '*';

            }
        }

        private void Pn_registro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }
    }
}
