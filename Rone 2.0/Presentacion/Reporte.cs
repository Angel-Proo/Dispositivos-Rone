using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rone_2._0.Presentacion
{
    public partial class Reporte : Form
    {
        int i = 1;
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            if (i == 1)
            {
                iconButton4.BackColor = Color.IndianRed;
                iconButton1.Visible = true;
                iconButton2.Visible = false;
                iconButton3.Visible = false;
                iconButton5.BackColor = Color.LightGreen;
                iconButton6.BackColor = Color.Yellow;
            }
        }
    }
}
