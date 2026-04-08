using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace V_ATT.BL
{
    class ATT
    {
        public DataTable VATT(int Eid)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Eid", SqlDbType.Int);
            parm[0].Value = Eid; 
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("VATT", parm);
            DAL.close();
            return dt;
        }

        public DataTable VATT2(int Eid,string TT)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@Eid", SqlDbType.Int);
            parm[0].Value = Eid;

            parm[1] = new SqlParameter("@TT", SqlDbType.VarChar,50);
            parm[1].Value = TT;
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("VATT2", parm);
            DAL.close();
            return dt;
        }

        public DataTable ATT_RPT2(int Eid, DateTime date1, DateTime date2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@Eid", SqlDbType.Int);
            parm[0].Value = Eid;

            parm[1] = new SqlParameter("@date1", SqlDbType.Date);
            parm[1].Value = date1;

            parm[2] = new SqlParameter("@date2", SqlDbType.Date);
            parm[2].Value = date2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ATT_RPT2", parm);
            DAL.close();
            return dt;
        }

        public DataTable ATT_RPT(int Eid)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Eid", SqlDbType.Int);
            parm[0].Value = Eid;

          
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ATT_RPT", parm);
            DAL.close();
            return dt;
        }
    }
}
