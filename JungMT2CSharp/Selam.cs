using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JungMT2CSharp;
using static System.Windows.Forms.DataFormats;

namespace JungMT2CSharp
{
 
    public partial class Selam : Form
    {


        public Selam()
        {
            InitializeComponent();
          
           
           
        }

        int First = 0;
        AnaBina form1 = new AnaBina();
     
        private void visceralButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
            ExeLoc.Text = OpenFileDialog1.FileName;
        }

        private void visceralButton1_Click(object sender, EventArgs e)
        {
            Process.Start(ExeLoc.Text);
        }
       
        private void visceralButton3_Click(object sender, EventArgs e)
        {
            if (First == 0)

            {
                visceralButton3.Text = "Hide";         
                form1.Show();
                First = 1;
            }


            else if (First == 1)

            {
                visceralButton3.Text = "Show";
                form1.Hide();          
                First = 0;

            }

        }

        private void visceralButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* tbx1.Text = XKordinatSelam.Text;
            tbx2.Text = YKordinatSelam.Text;  */
        }
    }
}
