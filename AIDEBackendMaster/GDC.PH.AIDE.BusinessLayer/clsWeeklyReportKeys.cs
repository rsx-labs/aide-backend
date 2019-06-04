using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsWeeklyReportKeys
	{

		#region Data Members

		int _wk_ID;

		#endregion

		#region Constructor

        public clsWeeklyReportKeys(int wk_ID)
		{
            _wk_ID = wk_ID; 
		}

		#endregion

		#region Properties

		public int WK_RANGE_ID
		{
            get { return _wk_ID; }
		}

		#endregion

	}
}
