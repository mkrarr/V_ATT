using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V_ATT.PL
{
    public partial class RPT : Form
    {
        public int EID = 0;
        BL.ATT at = new BL.ATT();
        public RPT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                dataGridView1.DataSource = at.ATT_RPT2(EID, dateTimePicker1.Value, dateTimePicker2.Value);
            }else
            {
                dataGridView1.DataSource = at.ATT_RPT(EID);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                dataGridView1.DataSource = at.ATT_RPT2(EID, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                dataGridView1.DataSource = at.ATT_RPT(EID);
            }
        }
    }
}
