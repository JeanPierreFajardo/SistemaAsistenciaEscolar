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
    public partial class Menu_Docente : Form
    {
        public Menu_Docente()
        {
            InitializeComponent();
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
            Visualizar_Asistencia gaaa = new Visualizar_Asistencia();
            gaaa.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }

        private void btn_Gusuario_MouseEnter(object sender, EventArgs e)
        {
            btn_Gusuario.ForeColor = Color.DarkRed;
        }

        private void btn_Gusuario_MouseLeave(object sender, EventArgs e)
        {
            btn_Gusuario.ForeColor = Color.Blue;
        }
    }
}
