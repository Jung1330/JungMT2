#region Başvurular / using System; / gibi
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
using Microsoft.VisualBasic;
using static System.Windows.Forms.DataFormats;


#endregion

namespace JungMT2CSharp
{
                                                          
    /* Bu Source Göktuğ Oğuzaslan tarafından yapılmıştır,
    Eğer haberi olmadan biryerde paylaştıysanız lütfen bildirin

    Read/Write Memory LibraryV2 by Omertrans156 (Memoryhackers'ın websitesinde bulabilirsiniz)

    Github.com/Jung1330
    Jung1330.github.io
    Discord:Göktuğ Oğuzaslan#6609
    Cheatglobal:Jung1330
    MemoryHackers:LavBali

    Source Github için paylaşılmıştır.

     */

    public partial class Selam : Form
    {
        public Selam(){InitializeComponent();}

        #region Çağırma yardımcıları
        int First = 0;
        int First1 = 0;
        int First2 = 0;

        int Butonem = 0;
        int PageRefresh = 0;

        AnaBina C1 = new AnaBina();
        AnaBina C2 = new AnaBina();
        AnaBina C3 = new AnaBina();

        #endregion

        #region OpenMetin2
        private void visceralButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
            ExeLoc.Text = OpenFileDialog1.FileName;
        }

        private void visceralButton1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = (ExeLoc.Text);
            p.StartInfo.UseShellExecute = false;
            p.Start();
            //Process.Start(ExeLoc.Text); 
        }
        #endregion

        #region 1.Client  
        private void visceralButton3_Click(object sender, EventArgs e)
        {
            if (First == 0)
            {
                Client1ShowHide.Text = "Hide";         
                C1.Show();
                First = 1;
            }


            else if (First == 1)
            {
                Client1ShowHide.Text = "Show";
                C1.Hide();          
                First = 0;
            }
        }
        #endregion
        #region 2.Client
        private void visceralButton5_Click(object sender, EventArgs e)
        {
            if (First1 == 0)
            {
                Client2ShowHide.Text = "Hide";
                C2.Show();
                First1 = 1;
            }


            else if (First1 == 1)
            {
                Client2ShowHide.Text = "Show";
                C2.Hide();
                First1 = 0;
            }
        }
        #endregion
        #region 3.Client
        private void visceralButton6_Click(object sender, EventArgs e)
        {

            if (First2 == 0)
            {
                Client3ShowHide.Text = "Hide";
                C3.Show();
                First2 = 1;
            }


            else if (First2 == 1)
            {
                Client3ShowHide.Text = "Show";
                C3.Hide();
                First2 = 0;
            }
        }
        #endregion

        #region SystemTray
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            Tray.Visible = false;
        }

        private void Selam_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                Tray.Visible = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(3);
         
        }
        private void client1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            if (First == 0)
            {
                FirstClient.Image = JungMT2.Properties.Resources.Sign__2_;
                Client1ShowHide.Text = "Hide";
                C1.Show();
                First = 1;
             
            }

            else if (First == 1)
            {
                FirstClient.Image = JungMT2.Properties.Resources.Sign__1_;
                Client1ShowHide.Text = "Show";
                C1.Hide();
                First = 0;
            }


        }
        private void client2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (First1 == 0)
            {
                SecondClient.Image = JungMT2.Properties.Resources.Sign__2_;
                Client2ShowHide.Text = "Hide";
                C2.Show();
                First1 = 1;
            }


            else if (First1 == 1)
            {
                SecondClient.Image = JungMT2.Properties.Resources.Sign__1_;
                Client2ShowHide.Text = "Show";
                C2.Hide();
                First1 = 0;
            }
        }
        private void client3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (First2 == 0)
            {
                ThirdClient.Image = JungMT2.Properties.Resources.Sign__2_;
                Client3ShowHide.Text = "Hide";
                C3.Show();
                First2 = 1;
            }


            else if (First2 == 1)
            {
                ThirdClient.Image = JungMT2.Properties.Resources.Sign__1_;
                Client3ShowHide.Text = "Show";
                C3.Hide();
                First2 = 0;
            }
        }
        #endregion

        #region Boş Kodlar Organizasyonu
        public void Selam_Load(object sender, EventArgs e)
        {
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
        #endregion

        private void Topmost_CheckedChanged(object sender, EventArgs e)
        {
            if (Topmost.Checked == true)
            {
                this.TopMost = true;
            }
            else if (Topmost.Checked == false)
            {
                this.TopMost = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Butonem = 1;
            if (Butonem == 1)
            {
                ClientCurrentNumber.Text = "7";
                this.Size = new Size(432,485);
                Topmost.Location = new Point(364, 467);
                Butonem = 0;

            }
           


        }

        private void button1_Click(object sender, EventArgs e)
        {     
            Butonem = 0;
            if (Butonem == 0)
            {
                ClientCurrentNumber.Text = "3";
                this.Size = new Size(210, 485);
                Topmost.Location = new Point(150, 467);
                Butonem = 1;
                this.Hide();
                Refresh.Start();
            }
            
        
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {          
            this.Show();
            Refresh.Stop();
        }
    }
}
