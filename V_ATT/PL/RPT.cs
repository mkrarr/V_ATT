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

        private void button2_Click(object sender, EventArgs e)
        {
            RPTF.ATT rpt = new RPTF.ATT();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPTF.RPT_FRM frm = new RPTF.RPT_FRM();
            // rpt.SetDataSource(ORD.get_order_details(order_id));
            //            rpt.SetParameterValue(order_id);
            if (checkBox1.Checked == false)
            {
                rpt.SetParameterValue("@Eid", EID);
                rpt.SetParameterValue("@date1", dateTimePicker1.Value);
                rpt.SetParameterValue("@date2", dateTimePicker2.Value);
            }
            else
            {
                rpt.SetParameterValue("@Eid", EID);
                rpt.SetParameterValue("@date1", Convert.ToDateTime("1-1-2000"));
                rpt.SetParameterValue("@date2", Convert.ToDateTime("1-1-2099"));
            }

            frm.crystalReportViewer2.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
