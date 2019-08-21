using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPClient
{
    public static class Validation
    {
        public static int validationField(string ServerName, string Passwordt, string UserName)
        {
            int i = 0;
            if (ServerName == "" || Passwordt == "" || UserName == "")
            {
                MessageBox.Show("Не все поля заполнены", caption: "Внимание!", icon: MessageBoxIcon.Exclamation, buttons: MessageBoxButtons.OK);
                i = 1;
            }
            return i;
        }
        public static string PressKeyRD(object sender, KeyPressEventArgs e)
        {
            var key = (TextBox)sender;
            if (e.KeyChar.Equals('\b'))
                return "";
            if (e.KeyChar.Equals('.'))
            {

                e.Handled = key.SelectionStart == 0 || key.Text[key.SelectionStart - 1].Equals('.');
                    if(!e.Handled)
                    return "";
                
            }
            if (e.Handled = !char.IsNumber(e.KeyChar))
            {
                return "только цифры и точки"; 
            }
            return "";
        }
        public static string PressKeyName(object sender, KeyPressEventArgs e)
        {
            bool rez = false;

            foreach (int ch in e.KeyChar.ToString())
            {
                if ((int)ch >= 97 && (int)ch <= 122)
                {
                    e.Handled = e.Handled;
                    rez = true;
                        return "";
                }
            }
            if (rez == false)
            {
                e.Handled = false;
                return "только латиница";
            }
            return "";
        }
    }
}
