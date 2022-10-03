using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using omertrans156;
using static System.Windows.Forms.DataFormats;

namespace JungMT2CSharp
{

    public partial class AnaBina : Form
    {
        
        public AnaBina()
        {
            InitializeComponent();
          
        }

        int First = 0;
       


        #region ReadOnly Kısmı
        private void visceralButton1_Click(object sender, EventArgs e)
        {
            ExeName.ReadOnly = true;
        }

        private void visceralButton2_Click(object sender, EventArgs e)
        {
            ExeName.ReadOnly = false;

        }

        private void visceralButton4_Click(object sender, EventArgs e)
        {
            ServerID.ReadOnly = true;
        }

        private void visceralButton3_Click(object sender, EventArgs e)
        {
            ServerID.ReadOnly = false;
        }
        #endregion

        #region Timer
        private void visceralCheckBox1_CheckedChanged(object sender)
        {

            if (StartPage.Checked == true)

            {
                AllInInfo.Start();
                AllInOne.Start();
                Refresh.Start();
                /*  Selam.Char1.Text = Mem.ReadString(oyunuygulamasi.Id, Module, 55, System.Text.Encoding.ASCII, 0x10, 0x10); */
            }
            else
            {
                AllInInfo.Stop();
                AllInOne.Stop();

            }

        }
        #endregion

        private void AllInOne_Tick(object sender, EventArgs e) /* Server Kodları burda Knk */
        {


            #region Rohan2
            /* Rohan2 Baş */

            if (ServerID.Text == "1")
            {
                Process oyunuygulamasi = Process.GetProcessesByName("metin2client.bin")[0];
                // Module bilgi almak için
                int Module = 0;
                foreach (ProcessModule module in oyunuygulamasi.Modules)
                {
                    if (module.FileName.Contains("metin2"))
                    {
                        Module = module.BaseAddress.ToInt32();
                        break;
                    }
                }

                if (SaldırıHızıCheckbox.Checked == true)
                {
                    Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, (float)SaldırıNum.Value, 0x10, 0x7F4);
                    if (SaldırıHızıCheckbox.Checked == false)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, "2", 0x10, 0x7F4);
                    }
                }



                if (HareketHızıCheckbox.Checked == true)
                {
                    Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, (float)HızNum.Value, 0x10, 0x7F0);
                    if (HareketHızıCheckbox.Checked == false)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, "2", 0x10, 0x7F0);
                    }

                }

                if (WTypeCheckbox.Checked == true)
                {
                    Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, (float)WTypeNum.Value, 0x10, 0x7F0);
                    if (WTypeCheckbox.Checked == false)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, "2", 0x10, 0x7F0);

                    }
                }

                if (OneHitCheckbox.Checked == true)
                {
                    Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, (float)OneHitNum.Value, 0x10, 0x7F0);

                    if (OneHitCheckbox.Checked == false)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x42D2F0, (float)OneHitNum.Value, 0x10, 0x7F0);

                    }
                }

            }
        
    

            /* Rohan2 SON */
            #endregion

            #region Aeldra
            /* AELDRA BAŞ */
            {
               
                if (ServerID.Text == "2")
                {
                    Process oyunuygulamasi = Process.GetProcessesByName("bin_aeldra_367")[0];
                    // Module bilgi almak için
                    int Module = 0;
                    foreach (ProcessModule module in oyunuygulamasi.Modules)
                    {
                        if (module.FileName.Contains("bin_aeldra_367"))
                        {
                            Module = module.BaseAddress.ToInt32();
                            break;
                        }
                    }

                    if (SaldırıHızıCheckbox.Checked == true)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x02086C58, (float)SaldırıNum.Value, 0x3C, 0x514);
                        if (SaldırıHızıCheckbox.Checked == false)
                        {
                            Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x02086C58, "2", 0x3C, 0x514);
                        }
                    }



                    if (HareketHızıCheckbox.Checked == true)
                    {
                        Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x02086C58, (float)HızNum.Value, 0x3C, 0x504);
                        if (HareketHızıCheckbox.Checked == false)
                        {
                            Mem.WriteFloat(oyunuygulamasi.Id, Module + 0x02086C58, "2", 0x3C, 0x504);
                        }

                    }

                    if (WTypeCheckbox.Checked == true)
                    {
                        Mem.WriteInteger(oyunuygulamasi.Id, Module + 0x02086C58, (int)(float)WTypeNum.Value, 0x3C, 0x704);
                        if (WTypeCheckbox.Checked == false)
                        {
                            Mem.WriteInteger(oyunuygulamasi.Id, Module + 0x02086C58, "2", 0x3C, 0x704);

                        }
                    }

                    if (OneHitCheckbox.Checked == true)
                    {
                        Mem.WriteInteger(oyunuygulamasi.Id, Module + 0x02086C58, (int)(float)OneHitNum.Value, 0x3C, 0x5FC);

                        if (OneHitCheckbox.Checked == false)
                        {
                            Mem.WriteInteger(oyunuygulamasi.Id, Module + 0x02086C58, (int)(float)OneHitNum.Value, 0x3C, 0x5FC);

                        }
                    }

                }
                /* AELDRA SON */
                

            }
#endregion


        }



        #region TopMost
        private void visceralCheckBox1_CheckedChanged_1(object sender) /* TopMost */ 
        {
            if (visceralCheckBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        #endregion

        private void AllInInfo_Tick(object sender, EventArgs e)
        {
           
            #region Rohan Name Kısmı
            if (ServerID.Text == "1")
            {
                Process oyunuygulamasi = Process.GetProcessesByName("metin2client.bin")[0];
                // Module bilgi almak için
                int Module = 0;
                foreach (ProcessModule module in oyunuygulamasi.Modules)
                {
                    if (module.FileName.Contains("metin2"))
                    {
                        Module = module.BaseAddress.ToInt32();
                        break;
                    }
                }
                XKordinat.Text = Mem.ReadFloat(oyunuygulamasi.Id, Module + 0x42D2F0, 0x10, 0x7C0);
                YKordinat.Text = Mem.ReadFloat(oyunuygulamasi.Id, Module + 0x42D2F0, 0x10, 0x7C4);
                Charname.Text = Mem.ReadString(oyunuygulamasi.Id, Module + 0x42D2F0, 55, System.Text.Encoding.ASCII, 0x10, 0x10);
            }
            #endregion

            #region Aeldra Name Kısmı
            if (ServerID.Text == "2")
            {
                Process oyunuygulamasi = Process.GetProcessesByName("bin_aeldra_367")[0];
                // Module bilgi almak için
                int Module = 0;
                foreach (ProcessModule module in oyunuygulamasi.Modules)
                {
                    if (module.FileName.Contains("bin_aeldra_367"))
                    {
                        Module = module.BaseAddress.ToInt32();
                        break;
                    }
                }
                XKordinat.Text = Mem.ReadFloat(oyunuygulamasi.Id, Module + 0x02086C58, 0x3C, 0x2c4);
                YKordinat.Text = Mem.ReadFloat(oyunuygulamasi.Id, Module + 0x02086C58, 0x3C, 0x2c8);
                Charname.Text = "[" + Mem.ReadInteger(oyunuygulamasi.Id, Module + 0x02086C58, 0x3C, 0x6C) + "]"+ " . " + Mem.ReadString(oyunuygulamasi.Id, Module + 0x02086C58, 55, System.Text.Encoding.ASCII, 0x3C, 0x28);

         
            }
            #endregion

          
        }

        private void visceralButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RohanID = 1" + "\n" + "AeldraID = 2", "Jung1330TR");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (First == 0)

            {

                this.Hide();
                First = 1;
            }
            else if (First == 1)

            {

                this.Show();
                First = 0;
                Refresh.Stop();

            }
        }
    }
}
