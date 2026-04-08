using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace V_ATT
{
    public partial class Attendance : Form
    {
        BL.ATT aa = new BL.ATT();

        void ATT_F()
        {
            DataTable en = new DataTable();
            int eid = Convert.ToInt32(textEdit1.Text);
            en=aa.VATT(eid);
            Properties.Settings.Default.L_ID = textEdit1.Text;
            Properties.Settings.Default.Auto = checkBox1.CheckState.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("The attendance of the employee { " + en.Rows[0][0].ToString() + " } has been accepted. \n ", "Attendance");
            this.Close();
        }

        void ATT_F2()
        {
            DataTable en = new DataTable();
            int eid = Convert.ToInt32(textEdit1.Text);
            en = aa.VATT2(eid,ttt.Text);
            Properties.Settings.Default.L_ID = textEdit1.Text;
            Properties.Settings.Default.Auto = checkBox1.CheckState.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("The attendance of the employee { " + en.Rows[0][0].ToString() + " } has been accepted. \n ", "Attendance");
            this.Close();
        }

        void ATT_FF()
        {
             DataTable en = new DataTable();
            int eid = Convert.ToInt32(textEdit1.Text);
          
            if(MessageBox.Show("Do you want to record the employee's attendance with the number { " + textEdit1.Text + " }. ", "Attendance", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                en = aa.VATT(eid);
                Properties.Settings.Default.L_ID = textEdit1.Text;
                Properties.Settings.Default.Auto = checkBox1.CheckState.ToString();
                Properties.Settings.Default.Save();

            } else
            {
                return;
            }
        }
        public Attendance()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.Settings.Default.Auto;
            textEdit1.Text = Properties.Settings.Default.L_ID;
            if (Properties.Settings.Default.Auto == "Checked")
            { checkBox1.Checked=true; } else { checkBox1.Checked = false; }
            if (textEdit1.Text!="" && checkBox1.Checked==true)
            {
                ATT_FF();
            }
            else
            { return; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != "" & c2.Checked==false)
            {
                ATT_F();
            }
            else if (textEdit1.Text != "" & c2.Checked == true)
            {
                ATT_F2();
            }
            else
            { return; }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textEdit1.Text != string.Empty)
            {
                ATT_F();
            }

        }

        private void ttt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ATT_F();
            }
        }

        private void c2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ATT_F();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PL.RPT rr = new PL.RPT();
            rr.EID = Convert.ToInt32(textEdit1.Text);
            rr.ShowDialog();

        }

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if(c2.Checked==true)
            {
                ttt.Enabled = true;
            }
            else
            {
                ttt.Enabled = false;
            }
        }
    }
}
