#region Başvurular / using System; / gibi                                                                                                                                                                                                                                                                                                                                                                                                                          
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JungMT2.Properties;
using omertrans156;
using System.Linq.Expressions;



#endregion


namespace JungMT2CSharp
{

    public partial class AnaBina : Form
    {


        public AnaBina() { InitializeComponent(); }

        /* ==================================================================================================================================================================================== */
        /* ===========================================                                    Lazımlık Kod Alanı                                       ============================================ */
        /* ==================================================================================================================================================================================== */


        /* Ne bok varsa burda */       
        #region Server Kodları burda Knk

        private void AllInOne_Tick(object sender, EventArgs e)
        {

            if (Extra.Checked == true) { SaldırıHızıTrack.Maximum = SaldırıHızıTrack.Value + 10; }
            if (NinjaCheck.Checked == true) { SaldırıHızıTrack.Maximum = SaldırıHızıTrack.Value + 100; }
            if (SaldırıHızıTürü.Checked == true) { SaldırıHızıNum.Visible = true; } else { SaldırıHızıNum.Visible = false; }

            #region ElyM2 Hile Tarafı


            if (ServerID.Text == "1")
            {
                #region ElyM2 PID

                if (PIDCheck.Checked == true)
                {


                    #region Her Server İçin Lazım
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
                    #endregion

                    #region ElyM2 Saldırı Hızı
                    if (SaldırıHızıCheckbox.Checked == true)
                    {
                        if (SaldırıHızıTürü.Checked == true) /* Tür seçili değilse bunu yapıo işte */
                        {
                            Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, (int)SaldırıHızıNum.Value, 0xC, 0x1B48); /* Buraya dikkat et Float değil Int burası */
                        }
                        else
                        {
                            Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, SaldırıHızıTrack.Value, 0xC, 0x1B48); /* Buraya dikkat et Float */
                        }                                        
                    }
                    else
                    {
                        Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, 2, 0xC, 0x1B48);
                    }
                    #endregion

                    #region ElyM2 Hareket Hızı
                    if (HareketHızıCheckbox.Checked == true)
                    {
                        Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, (float)HareketHızıTrack.Value, 0xC, 0x1B44);                      
                    }
                    else
                    {
                        Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, 2, 0xC, 0x1B44);
                    }
                    #endregion

                    #region ElyM2 Silah Türü
                    if (WTypeCheckbox.Checked == true)
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, (int)WTypeNum.Value, 0xC, 0x19DC);                       
                    }
                    else
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, "2", 0xC, 0x19DC);
                    }
                    #endregion

                    #region ElyM2 OneHit
                    if (OneHitCheckbox.Checked == true)
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, (int)OneHitNum.Value, 0xC, 0x1AA0);                       
                    }
                    else
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, (int)OneHitNum.Value, 0xC, 0x1AA0);
                    }
                    #endregion

                    #region ElyM2 Zoom

                    if (SaldırıHızıCheckbox.Checked == false)
                    {
                        Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, 105289754222, 0xC, -0xF3E1D20);
                    }

                    #endregion

                    #region ElyM2 NoFog

                    if (SaldırıHızıCheckbox.Checked == false)
                    {
                        Mem.WriteFloat((int)PIDM.Value, Module + 0x11D3404, 105289754222, 0xC, -0xF1E1B08);
                    }
                    #endregion

                    #region ElyM2 Wallhack

                    if (SaldırıHızıCheckbox.Checked == true)
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, 1, 0xC, 0x1C0C);
                    }
                    else
                    {
                        Mem.WriteInteger((int)PIDM.Value, Module + 0x11D3404, 0, 0xC, 0x1C0C);
                    }
                    #endregion


                }



                #endregion
            }

            #endregion

        }


        public void AllInInfo_Tick(object sender, EventArgs e)
        {

            #region ElyM2 Name/X/Y Kısmı

            if (ServerID.Text == "1")
            {
                try
                {
                    #region ElyM2 Name PID
                    if (PIDCheck.Checked == true)
                    {
                        Process oyunuygulamasi = Process.GetProcessesByName("metin2client.bin")[0];
                        // Module bilgi almak için
                        int Module = 0;
                        foreach (ProcessModule module in oyunuygulamasi.Modules)
                        {
                            if (module.FileName.Contains("metin2client"))
                            {
                                Module = module.BaseAddress.ToInt32();
                                break;
                            }
                        }
                        XKordinat.Text = Mem.ReadFloat((int)PIDM.Value, Module + 0x11D3404, 0xC, 0x1B14); /* son pointer 0x5FC de olabilir */
                        YKordinat.Text = Mem.ReadFloat((int)PIDM.Value, Module + 0x11D3404, 0xC, 0x1B18); /* son pointer 0x55C de olabilir */
                        CharLvLabel.Text = "[" + Mem.ReadInteger((int)PIDM.Value, Module + 0x11D3404, 0xC, 0x40) + "]";
                        CharnameLabel.Text = Mem.ReadString((int)PIDM.Value, Module + 0x11D3404, 55, System.Text.Encoding.ASCII, 0xC, 0x10);


                    }
                    else
                    {
                        XKordinat.Text = "null";
                        YKordinat.Text = "null";
                        CharLvLabel.Text = "[" + "???" + "]";
                        CharnameLabel.Text = "null";
                    }
                    #endregion



                }
                catch (Exception ex)
                {
                    /*   StartPage.Checked = false; */
                }
            }
            #endregion       

        }


        #endregion

        /* Farmbot işte */
        #region Farmbot
        private void FarmbotTimer_Tick(object sender, EventArgs e)
        {
            if (ServerID.Text == "1")
            {
                /* Yapcaz halletcez ya */
            }
        }

        #region Farmbot Zamanlama Timer
        private void FarmbotSaatTimer_Tick(object sender, EventArgs e)
        {
            FarmbotSaatTimerHelper.Start();

            if (int.Parse(SaniyeFarmbot.Text) < 9)
            {
                SaniyeFarmbot.Text = "0" + (int.Parse(SaniyeFarmbot.Text) + 1).ToString();
            }
            else
            {
                SaniyeFarmbot.Text = (int.Parse(SaniyeFarmbot.Text) + 1).ToString();
            }
            if (int.Parse(SaniyeFarmbot.Text) == 60)
            {
                SaniyeFarmbot.Text = "00";
                if (int.Parse(DakikaFarmbot.Text) < 9)
                {
                    DakikaFarmbot.Text = "0" + (int.Parse(DakikaFarmbot.Text) + 1).ToString();
                }
                else
                {
                    DakikaFarmbot.Text = (int.Parse(DakikaFarmbot.Text) + 1).ToString();
                }
            }
            if (int.Parse(DakikaFarmbot.Text) == 60)
            {
                DakikaFarmbot.Text = "00";
                if (int.Parse(SaatFarmbot.Text) < 9)
                {
                    SaatFarmbot.Text = "0" + (int.Parse(SaatFarmbot.Text) + 1).ToString();
                }
                else
                {
                    SaatFarmbot.Text = (int.Parse(SaatFarmbot.Text) + 1).ToString();
                }
            }
        }

        private void FarmbotSaatTimerHelper_Tick(object sender, EventArgs e)
        {
            SaatFarmbotAll.Text = SaatFarmbot.Text + ":" + DakikaFarmbot.Text + ":" + SaniyeFarmbot.Text;
        }
        #endregion

        #region Farmbot Checkbox

        private void Farmbot_CheckedChanged(object sender)
        {
            if (Farmbot.Checked == true)
            {
                FarmbotSaatTimer.Start();
            }
            else
            {
                FarmbotSaatTimer.Stop();
                SaniyeFarmbot.Text = "00";
                DakikaFarmbot.Text = "00";
                SaatFarmbot.Text = "00";
            }
        }

        #endregion

        #endregion

        /* Burası olmazsa nah değişir değerler */       /* Server Kodunu ve ismini burdan eklion bide ama ilk Combobox'a ekle öyle gel*/
        #region ServerName/PID-TabPagedeki

        private void ServerMainNameTimer_Tick(object sender, EventArgs e)
        {
            if (ServerComboBox.Text == "ElyM2")
            {
                ServerID.Text = "1";
            }
          
        }

        private void ServerComboBox_Click(object sender, EventArgs e) /* Burası bugda kalmasın diye aptallar için yapıldı */
        {
            ServerManeTimerHelp.Start();
            ServerMainNameTimer.Start();
            Bilgilendirme.Visible = true;
        }


        private void ServerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManeTimerHelp.Stop();
            ServerMainNameTimer.Stop();
            Bilgilendirme.Visible = false;
        }

        #endregion

        /* Her hilenin olmazsa olmazlarından birisi */
        #region Saat Time

        private void SaatTimer_Tick(object sender, EventArgs e)
        {
            if (StartPage.Checked == false) { SaatTimer.Stop(); }
            SaatTimerHelper.Start();

            if (int.Parse(Saniye.Text) < 9)
            {
                Saniye.Text = "0" + (int.Parse(Saniye.Text) + 1).ToString();
            }
            else
            {
                Saniye.Text = (int.Parse(Saniye.Text) + 1).ToString();
            }
            if (int.Parse(Saniye.Text) == 60)
            {
                Saniye.Text = "00";
                if (int.Parse(Dakika.Text) < 9)
                {
                    Dakika.Text = "0" + (int.Parse(Dakika.Text) + 1).ToString();
                }
                else
                {
                    Dakika.Text = (int.Parse(Dakika.Text) + 1).ToString();
                }
            }
            if (int.Parse(Dakika.Text) == 60)
            {
                Dakika.Text = "00";
                if (int.Parse(SaatStartPage.Text) < 9)
                {
                    SaatStartPage.Text = "0" + (int.Parse(SaatStartPage.Text) + 1).ToString();
                }
                else
                {
                    SaatStartPage.Text = (int.Parse(SaatStartPage.Text) + 1).ToString();
                }
            }
        }

        private void SaatTimerHelper_Tick(object sender, EventArgs e)
        {
            SaatStartPage.Text = Saat.Text + ":" + Dakika.Text + ":" + Saniye.Text;
        }
        #endregion

        /* Refresh Kodu İçin Lazım + Hepsini refreshliyo yani yapınca :D */
        int First = 0;

        /* Çöp Kutusu */
        #region Boş Kodlar Kısmı
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void ExeName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void TarganNum_TextChanged(object sender, EventArgs e)
        {
        }
        public void AnaBina_Load(object sender, EventArgs e)
        {
            HPBar.ForeColor = Color.Red;
            SPBar.ForeColor = Color.Blue;

          
          
           
        }
        private void SaldırıHızıCheckbox_CheckedChanged(object sender)
        {
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }



        #endregion

        /* O kadar bişi değil burası */
        #region ServerPID
        private void visceralCheckBox2_CheckedChanged(object sender)
        {
            if (PIDCheck.Checked == true)
            {
                HPBar.ForeColor = Color.Red;
                SPBar.ForeColor = Color.Blue;
                PIDM.Enabled = true;
                StartPage.Enabled = true;
            }
            else
            {
                HPBar.ForeColor = Color.Red;
                SPBar.ForeColor = Color.Blue;
                PIDM.Enabled = false;
                StartPage.Enabled = false;
            }
        }
        #endregion

        /* Olmazsa olmaz */
        #region Refresh Start Page
        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (First == 0) /* 3-2-1.Client */
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
        #endregion

        /* Buna elleme */
        #region ReadOnly Kısmı 
        private void visceralButton1_Click(object sender, EventArgs e)
        {
            PIDM.ReadOnly = true;
        }

        private void visceralButton2_Click(object sender, EventArgs e)
        {
            PIDM.ReadOnly = false;
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

        /* Bunu bilmiosan sg yazılım öğrenmeye başla */
        #region TopMost
        private void visceralCheckBox1_CheckedChanged_1(object sender) /* TopMost */
        {
            if (TopMostCheckbox.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        #endregion

        /* Eh işte */
        #region Timer + HataKutusu XD
        private void visceralCheckBox1_CheckedChanged(object sender)
        {


            if (StartPage.Checked == true)
            {
                HPBar.ForeColor = Color.Red;
                SPBar.ForeColor = Color.Blue;
                HPBar.Value = 100;
                SPBar.Value = 100;

                SaatTimer.Start();
                AllInInfo.Start();
                AllInOne.Start();
                Refresh.Start();

                ServerManeTimerHelp.Stop();
                ServerMainNameTimer.Stop();

                if (KarakterName.Text == "DasAuto") /*Hata alıosan burayı sil JungMT2 yi Jung yap yani*/
                {
                    HataKutusu.Show();
                    StartPage.Checked = false;
                    HPBar.Value = 1;
                    SPBar.Value = 1;
                }
                else
                {
                    HataKutusu.kind = Zeroit.Framework.UIThemes.DarkFlat.DarkFlatAlertBox._Kind.Success;
                    HataKutusu.Text = "Sunucu Bulundu!";
                    HataKutusu.Show();
                    HataKutusuTimer.Start();
                }
            }
            else
            {
                HPBar.Value = 1;
                SPBar.Value = 1;
                HPBar.ForeColor = Color.Red;
                SPBar.ForeColor = Color.Blue;

                ServerID.Enabled = true;
                AllInInfo.Stop();

                SaatTimer.Stop();

                Saniye.Text = "00";
                Dakika.Text = "00";
                Saat.Text = "00";
                SaatStartPage.Text = "00" + ":" + "00" + ":" + "00";

                AllInOne.Stop();
                SaatTimerHelper.Stop();

                ServerManeTimerHelp.Start();
                ServerMainNameTimer.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            HataKutusu.Hide();
            HataKutusuTimer.Stop();
        }



        private void ServerManeTimer_Tick(object sender, EventArgs e)
        {
            if (ServerManeTimerHelp.Enabled == true)
            {
                GizliBölgeTestLabel.Text = "Çalışıyo";

            }
           
            else if (ServerManeTimerHelp.Enabled == false)
            {

                GizliBölgeTestLabel.Text = "Durdula";
            }


         

        }

        private void darkFlatButton1_Click(object sender, EventArgs e)
        {

            HPBar.ForeColor = Color.Red;
            HPBar.Style = ProgressBarStyle.Continuous;
            HPBar.Value = 15;
            SPBar.ForeColor = Color.Blue;
            SPBar.Style = ProgressBarStyle.Continuous;
            SPBar.Value = 15;
        }

        #endregion

        /* İlerde daha iyisini yapcm söz */
        #region Saveimsi bişiler
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string All
                         = "========|" + " " + ServerNameSave.Text + " " + "|=========" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "ServerModuleExe :" + "\n"
                         + ManuelModuleExe.Text + "\n"
                         + "================================" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "AddressModule :" + "\n"
                         + AdressModule.Text + "\n"
                         + "================================" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "Saldırı Hızı :" + "\n"
                         + "Offset1:" + " " + SaldırıHızıOffsetText.Text + "\n"
                         + "Offset2:" + " " + SaldırıHızıOffsetText2.Text + "\n"
                         + "================================" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "Hareket Hızı :" + "\n"
                         + "Offset1:" + " " + HareketHızıOffsetText.Text + "\n"
                         + "Offset2:" + " " + HareketHızıOffsetText2.Text + "\n"
                         + "================================" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "Silah Türü :" + "\n"
                         + "Offset1:" + " " + SilahTürüOffsetText.Text + "\n"
                         + "Offset2:" + " " + SilahTürüOffsetText2.Text + "\n"
                         + "================================" + "\n"

                         + "\n"

                         + "================================" + "\n"
                         + "OneHit :" + "\n"
                         + "Offset1:" + " " + OneHitOffsetText.Text + "\n"
                         + "Offset2:" + " " + OneHitOffsetText2.Text + "\n"
                         + "================================" + "\n"

                         + "\n";

            File.WriteAllText("Config/" + ServerNameSave.Text + ".cfg", All);

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            TestoTimer.Start();
            if (ServerNameSave.Text == "") { MessageBox.Show("Lütfen Config Dosyasının Ismini Gir.", "Helper"); }          
            else
            {
                ServerNames.Items.Clear();
             
                try
                {
                    System.Diagnostics.Process.Start("notepad.exe", "Config/" + ServerNameSave.Text + ".cfg");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lütfen Config Dosyasının Ismini Gir.", "Helper");
                }
            }
        }

        private void TestoTimer_Tick(object sender, EventArgs e)
        {
            var folder = @"Config/";
            var txtFiles = Directory.GetFiles(folder, "*.cfg");
            ServerNames.Items.AddRange(txtFiles);
            TestoTimer.Stop();
        }

        #endregion

        /* Bu Anabina yüklendiğinde PID direk gelsin diye var */
        #region PID Direct
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TabPage t = TabControlMain.TabPages[3];
            TabControlMain.SelectTab(t); 
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
        #endregion

        /* ==================================================================================================================================================================================== */
        /* ===================================================================================================================================================================================  */
        /* ==================================================================================================================================================================================== */

    }
}



    

