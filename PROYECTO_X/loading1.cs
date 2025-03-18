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
    public partial class loading1 : Form
    {
        int N = 0;
        public loading1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            N++;
            label1.Text = "Cargando...   " + N.ToString() + "%";
            progressBar1.Value = N;
            if (N == 100)
            {
                timer1.Stop();
                this.Hide();
                Menu_Secretaria newform = new Menu_Secretaria();
                newform.Show();
            }
        }

        private void loading1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
