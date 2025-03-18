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
    public partial class Crear_Reportes : Form
    {
        public Crear_Reportes()
        {
            InitializeComponent();
        }

        private void Crear_Reportes_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Generar_Reportes gaa = new Generar_Reportes();
            gaa.Show();
        }

        private void btn_registrar_MouseEnter(object sender, EventArgs e)
        {
            btn_registrar.ForeColor = Color.DarkRed;
        }

        private void btn_registrar_MouseLeave(object sender, EventArgs e)
        {
            btn_registrar.ForeColor = Color.Blue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btn_enviar.ForeColor = Color.DarkRed;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btn_enviar.ForeColor = Color.Blue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            txtIgrado.Clear();
            txt_Inombres.Clear();
            txt_Inovedades.Clear();
            txt_Ipadrefamilia.Clear();
            txt_correo.Clear();
            txt_Iturno.Clear();
            txt_nombrepadres.Clear();
            txt_Ipadrefamilia.Clear();
            txt_Inombres.Focus();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void txt_Ipadrefamilia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_nombrepadres_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_correo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIgrado.Text=="")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_correo.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_Inombres.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_Inovedades.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_Ipadrefamilia.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_Iturno.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_nombrepadres.Text == "")
            {
                MessageBox.Show("Por favor ingrese los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Su reporte se envio con exito", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void txt_Ipadrefamilia_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Imprimir_reporte_Enter(object sender, EventArgs e)
        {

        }
    }
}
