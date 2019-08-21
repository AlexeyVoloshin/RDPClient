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
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.IO;

namespace RDPClient
{
    public partial class Form2 : Form
    {
        int i;
        int j;
        Timer time;
        Timer tShutDown;
        MassageForUser message;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = DataBank.NameServer;
                rdp.UserName = DataBank.NameUser;
                IMsTscNonScriptable secure = (IMsTscNonScriptable)rdp.GetOcx();
                secure.ClearTextPassword = DataBank.Password;
                rdp.DesktopWidth = DataBank.Wform2;
                rdp.DesktopHeight = DataBank.Hform2;
                rdp.Width = DataBank.Wform2;
                rdp.Height = DataBank.Hform2;
                ((IMsRdpClientAdvancedSettings)rdp.AdvancedSettings).MinutesToIdleTimeout = 10;
                ((IMsRdpClientAdvancedSettings)rdp.AdvancedSettings).RDPPort = 3389;
                rdp.Connect();
                shutdownTimeout();
            }
            catch (Exception msg)
            {
                Logger.Write(msg);
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
        private void shutdownTimeout()
        {
            j = 60;//минуты
            tShutDown = new Timer();
            tShutDown.Interval = 60 * 1000;
            tShutDown.Tick += new EventHandler(timer2_Tick_1);
            tShutDown.Enabled = true;
            tShutDown.Start();
        }
        private void rdp_OnIdleTimeoutNotification(object sender, EventArgs e)
        {
            i = 60;//секунды
            time = new Timer();
            time.Interval = 1000; 
            time.Tick += new EventHandler(timer1_Tick);
            time.Enabled = true;
            time.Start();
            message = new MassageForUser();
            if (message.ShowDialog().Equals(DialogResult.OK))
            {
                time.Enabled = false;
                time.Stop();
                ((IMsRdpClientAdvancedSettings)rdp.AdvancedSettings).MinutesToIdleTimeout = 10;
            }
            else
            {
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Время до завершения сеанса: " + (--i).ToString() + " сек.";
                if (i < 0)
                {
                    message.DialogResult = DialogResult.Cancel;// .Close();
                    rdp.Disconnect();
                }
            }
            catch
            {
            }
        }
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Время до завершения сеанса: " + (--j).ToString() + " мин.";
                if (j < 0)
                {
                    rdp.Disconnect();
                }
            }
            catch
            {
            }
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                rdp_OnRequestGoFullScreen(sender, e);
            }
        }
        private void rdp_OnRequestGoFullScreen(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            rdp.FullScreenTitle = "Full Screen";
            rdp.SecuredSettings.FullScreen = 1;
        }
        private void rdp_OnRequestLeaveFullScreen(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            rdp.FullScreenTitle = "Full Screen";
            rdp.SecuredSettings.FullScreen = 0;
        }
        private void rdp_OnRequestContainerMinimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            this.Close();
        }
        private void rdp_OnFatalError(object sender, AxMSTSCLib.IMsTscAxEvents_OnFatalErrorEvent e)
        {
            try
            { 
            }
            catch (Exception msg)
            {
                Logger.Write(msg);
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            tShutDown.Enabled = false;
            tShutDown.Stop();
            if (time == null)
                return;
            time.Enabled = false;
            time.Stop();
        }
    }
}
