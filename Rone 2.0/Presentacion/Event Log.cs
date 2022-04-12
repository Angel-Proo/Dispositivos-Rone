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

namespace Rone_2._0.Presentacion
{
    public partial class Event_Log : Form
    {
        int i = 1;
        IconButton[] meseros = new IconButton[16];
        public Event_Log()
        {
            InitializeComponent();
        }

        private void Event_Log_Load(object sender, EventArgs e)
        {
            meseros[0] = iconButton1;
            meseros[1] = iconButton2;
            meseros[2] = iconButton3;
            meseros[3] = iconButton4;
            meseros[4] = iconButton5;
            meseros[5] = iconButton6;
            meseros[6] = iconButton7;
            meseros[7] = iconButton8;
            meseros[8] = iconButton9;
            meseros[9] = iconButton10;
            meseros[10] = iconButton11;
            meseros[11] = iconButton12;
            meseros[12] = iconButton13;
            meseros[13] = iconButton14;
            meseros[14] = iconButton15;
            meseros[15] = iconButton16;
            
            for (int index = 0; index < 16; index++)
            {
                if (index == 0 || index == 2)
                {
                    meseros[index].Visible = false;
                }
                if (index == 3 || index == 5)
                {
                    meseros[index].BackColor = Color.IndianRed;
                }
            }
            //if (i == 1)
            //{
            //    iconButton4.BackColor = Color.IndianRed;
            //    iconButton1.Visible = true;
            //    iconButton2.Visible = false;
            //    iconButton3.Visible = false;
            //    iconButton5.BackColor = Color.LightGreen;
            //    iconButton6.BackColor = Color.Yellow;
            //}
        }
    }
}
