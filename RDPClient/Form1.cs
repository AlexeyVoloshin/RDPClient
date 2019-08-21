using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;


namespace RDPClient
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Props props;
        public Form1()
        {
            InitializeComponent();
            // установка обработчика события Scroll
            trackBar1.Scroll+=trackBar1_Scroll;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadSetting();
        }
        private void WriteSetting()
        {
                props = new Props();
                props.Fields.SizeScreen = DataBank.SizeScreen;
                props.Fields.NameServer = DataBank.NameServer;
                props.Fields.NameUser = DataBank.NameUser;
                props.Fields.Password = DataBank.Password;
                props.WriteXml();
        }
        private void ReadSetting()
        {
            props = new Props();
            props.ReadXML();
            
            trackBar1.Value = props.Fields.SizeScreen;
            sizeScreen(trackBar1.Value);
            txtServerName.Text = props.Fields.NameServer;
            txtUserName.Text = props.Fields.NameUser;
            txtPassword.Text = props.Fields.Password;
        }
        private void Connect_Click(object sender, EventArgs e)
        {
                
                DataBank.NameServer = txtServerName.Text;
                DataBank.Password = txtPassword.Text;
                DataBank.NameUser = txtUserName.Text;
                if(Validation.validationField(txtServerName.Text, txtPassword.Text, txtUserName.Text) == 1)
                    return;
                if (checkBox1.CheckState == CheckState.Checked)
                    WriteSetting();
                form2 = new Form2();
                this.Hide();
                form2.Width = DataBank.Wform2;
                form2.Height = DataBank.Hform2;
                form2.ShowDialog();
                this.Show();
            
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sizeScreen(trackBar1.Value);
        }
        private void sizeScreen(int val)
        {
            switch (val)
            {
                case 0:
                    label4.Text = "640 на 480 пикселей";
                    DataBank.Wform2 = 640;
                    DataBank.Hform2 = 480;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 1:
                    label4.Text = "800 на 600 пикселей";
                    DataBank.Wform2 = 800;
                    DataBank.Hform2 = 600;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 2:
                    label4.Text = "1024 на 768 пикселей";
                    DataBank.Wform2 = 1024;
                    DataBank.Hform2 = 768;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 3:
                    label4.Text = "1280 на 720 пикселей";
                    DataBank.Wform2 = 1280;
                    DataBank.Hform2 = 720;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 4:
                    label4.Text = "1280 на 768 пикселей";
                    DataBank.Wform2 = 1280;
                    DataBank.Hform2 = 768;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 5:
                    label4.Text = "1280 на 1024 пикселей";
                    DataBank.Wform2 = 1280;
                    DataBank.Hform2 = 1024;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 6:
                    label4.Text = "1440 на 900 пикселей";
                    DataBank.Wform2 = 1440;
                    DataBank.Hform2 = 900;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 7:
                    label4.Text = "1440 на 1050 пикселей";
                    DataBank.Wform2 = 1440;
                    DataBank.Hform2 = 1050;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 8:
                    label4.Text = "1680 на 1050 пикселей";
                    DataBank.Wform2 = 1680;
                    DataBank.Hform2 = 1050;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 9:
                    label4.Text = "1920 на 1080 пикселей";
                    DataBank.Wform2 = 1920;
                    DataBank.Hform2 = 1080;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
                case 10:
                    label4.Text = "Во весь экран";
                    Size resolution = Screen.PrimaryScreen.Bounds.Size;//использум стандартные размеры экрана
                    DataBank.Wform2 = resolution.Width;
                    DataBank.Hform2 = resolution.Height;
                    DataBank.SizeScreen = trackBar1.Value;
                    break;
            }
        }

        private void txtServerName_KeyPress(object sender, KeyPressEventArgs e)
        {
           TxtValidRD.Text = Validation.PressKeyRD(sender, e);
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtValidName.Text = Validation.PressKeyName(sender, e);
        }
    }
}
