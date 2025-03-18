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
    public partial class Menu_Secretaria : Form
    {
        public Menu_Secretaria()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 gaaa = new Form1();
            gaaa.Show();
        }

        private void btn_Restudiante_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisEstud_Administrativo gaaa = new RegisEstud_Administrativo();
            gaaa.Show();
        }

        private void btn_Greporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generar_Reportes gaaa = new Generar_Reportes();
            gaaa.Show();
        }

        private void btn_Gusuario_Click(object sender, EventArgs e)
        {

        }

        private void btn_Restudiante_MouseEnter(object sender, EventArgs e)
        {
            btn_Restudiante.ForeColor = Color.DarkRed;
        }

        private void btn_Restudiante_MouseLeave(object sender, EventArgs e)
        {
            btn_Restudiante.ForeColor = Color.Blue;
        }
    }
}
