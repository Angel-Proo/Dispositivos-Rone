using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Rone_2._0.Datos;

namespace Rone_2._0.Presentacion
{
    public partial class Reporte : Form
    {
        
        PictureBox[] dispositivos = new PictureBox[28];
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            dispositivos[0] = pictureBox1;
            dispositivos[1] = pictureBox2;
            dispositivos[2] = pictureBox3;
            dispositivos[3] = pictureBox4;
            dispositivos[4] = pictureBox5;
            dispositivos[5] = pictureBox6;
            dispositivos[6] = pictureBox7;
            dispositivos[7] = pictureBox8;
            dispositivos[8] = pictureBox9;
            dispositivos[9] = pictureBox10;
            dispositivos[10] = pictureBox11;
            dispositivos[11] = pictureBox12;
            dispositivos[12] = pictureBox13;
            dispositivos[13] = pictureBox14;
            dispositivos[14] = pictureBox15;
            dispositivos[15] = pictureBox16;
            dispositivos[16] = pictureBox17;
            dispositivos[17] = pictureBox18;
            dispositivos[18] = pictureBox19;
            dispositivos[19] = pictureBox20;
            dispositivos[20] = pictureBox21;
            dispositivos[21] = pictureBox22;
            dispositivos[22] = pictureBox23;
            dispositivos[23] = pictureBox24;
            dispositivos[24] = pictureBox25;
            dispositivos[25] = pictureBox26;
            dispositivos[26] = pictureBox27;
            dispositivos[27] = pictureBox28;
            //dispositivos[28] = pictureBox29;
            //dispositivos[29] = pictureBox30;
            //dispositivos[30] = pictureBox31;
            //dispositivos[31] = pictureBox32;
            //dispositivos[32] = pictureBox33;
            //dispositivos[33] = pictureBox34;
            //dispositivos[34] = pictureBox35;
            //dispositivos[35] = pictureBox36;
            //dispositivos[36] = pictureBox37;
            //dispositivos[37] = pictureBox38;
            //dispositivos[38] = pictureBox39;
            //dispositivos[39] = pictureBox40;
            //dispositivos[40] = pictureBox41;
            //dispositivos[41] = pictureBox42;
            Alertas.Start();
            Pagina2.Start();  
        }

        private void Alertas_Tick(object sender, EventArgs e)
        {
            

            for (int index = 0; index < dispositivos.Count(); index++)
            {
                if (index.Equals(2) || index.Equals(3))
                {
                    dispositivos[index].Image = null;
                }
                if (index == 6 || index == 5 || index == 27)
                {
                    dispositivos[index].BackColor = Color.IndianRed;
                    dispositivos[index].Text = "Advertencia";
                    //dispositivos[index].Size = new Size(152, 152);
                }
            }
            Alertas.Stop();
            Retorno.Start();
        }

        private void Retorno_Tick(object sender, EventArgs e)
        {
            for (int index = 0; index < dispositivos.Count(); index++)
            {
                if (dispositivos[index].BackColor == Color.IndianRed)
                {
                    dispositivos[index].BackColor = Color.White;
                    //dispositivos[index].Text = "disp " + (index + 1);
                    //dispositivos[index].Size = new Size(150, 150);
                }
            }
            Retorno.Stop();
            Alertas.Start();
        }

        private void Pagina1_Tick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            Pagina1.Stop();
            Alertas.Start();
            Pagina2.Start();
        }

        private void Pagina2_Tick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            Pagina2.Stop();
            Alertas.Start();
            Pagina1.Start();
        }


        private void Reporte_SizeChanged(object sender, EventArgs e)
        {
            if (Tamaño.sizes == "Normal")
            {   
                if(dispositivos[0].Size.Width != 150 || dispositivos[0].Size.Height != 150)
                {
                    for (int index = 0; index < dispositivos.Count(); index++)
                    {
                        dispositivos[index].Size = new Size(150, 150);
                        dispositivos[index].Margin = new Padding(20, 3, 20, 3);
                    }
                }
                MessageBox.Show("Normal");
            }
            else
            {
                for (int index = 0; index < dispositivos.Count(); index++)
                {
                    dispositivos[index].Size = new Size(185, 185);
                    dispositivos[index].Margin = new Padding(25, 3, 25, 3);
                }
                MessageBox.Show("Maximo");
            }

            //switch (Tamaño.sizes)
            //{
            //    case "Normal":
            //        MessageBox.Show("normal");
            //        break;
            //    case "Maximized":
            //        MessageBox.Show("maximo");

            //        break;
            //    default:

            //        break;
            //}

        }
    }
}
