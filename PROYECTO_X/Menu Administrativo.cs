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
    public partial class Menu_Administrativo : Form
    {
        public Menu_Administrativo()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Btn_regresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisEstud_Administrativo gaaa = new RegisEstud_Administrativo();
            gaaa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gaaa = new Form1();
            gaaa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generar_Reportes gaaa = new Generar_Reportes();
            gaaa.Show();
        }

        private void btn_Gusuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestionar_Usuario_Administrativo gaa = new Gestionar_Usuario_Administrativo();
            gaa.Show();
        }

        private void btn_Gusuario_MouseEnter(object sender, EventArgs e)
        {
            btn_Gusuario.ForeColor = Color.DarkRed;
        }

        private void btn_Gusuario_MouseLeave(object sender, EventArgs e)
        {
            btn_Gusuario.ForeColor = Color.Blue;
        }

        private void btn_Restudiante_MouseEnter(object sender, EventArgs e)
        {
            btn_Restudiante.ForeColor = Color.DarkRed;
        }

        private void btn_Restudiante_MouseLeave(object sender, EventArgs e)
        {
            btn_Restudiante.ForeColor = Color.Blue;
        }

        private void btn_Greporte_MouseEnter(object sender, EventArgs e)
        {
            btn_Greporte.ForeColor = Color.DarkRed;
        }

        private void btn_Greporte_MouseLeave(object sender, EventArgs e)
        {
            btn_Greporte.ForeColor = Color.Blue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }
    }
}
