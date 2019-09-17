using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class ClsKPISummaryKeys
    {

		#region Data Members

		DateTime _fy_Start;
        DateTime _fy_End;
        short _Month;

        
		#endregion

        #region Constructor

        public ClsKPISummaryKeys(DateTime fy_start, DateTime fy_end, short month)
        {
            _fy_Start = fy_start;
            _fy_End = fy_end;
            _Month = month;
        }



		#endregion

        #region Properties

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
        #endregion

    }
}
