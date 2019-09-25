using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class ClsKPISummaryKeys
    {

        #region Data Members

        int _Id;
        int _EmpId;
        string _kpiRef;
		DateTime _fy_Start;
        DateTime _fy_End;
        short _Month;

        
		#endregion

        #region Constructor

        public ClsKPISummaryKeys(int empId, DateTime fy_start, DateTime fy_end)
        {
            _EmpId = empId;
            _fy_Start = fy_start;
            _fy_End = fy_end;
        }

        public ClsKPISummaryKeys(int empId, DateTime fy_start, DateTime fy_end, short month, string kpiREf)
        {
            _EmpId = empId;
            _fy_Start = fy_start;
            _fy_End = fy_end;
            _Month = month;
            _kpiRef = kpiREf;

        }

        #endregion

        #region Properties

        public int ID
        {
            get { return _Id; }
        }

        public int EMP_ID
        {
            get { return _EmpId; }
        }

        public short Month
        {
            get { return _Month; }
        }

        public DateTime FY_START
        {
            get { return _fy_Start; }
        }

        public DateTime FY_END
        {
            get { return _fy_End; }
        }

        public string KPI_REF
        {
            get { return _kpiRef; }
        }
        #endregion

    }
}
