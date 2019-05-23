using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsAttendanceKeys
	{

		#region Data Members

		int _eMP_ID;
        int _Month;
        short _Year;

        #endregion

        #region Constructor

        public clsAttendanceKeys(int eMP_ID, int Month, short Year)
		{
			_eMP_ID = eMP_ID;
            _Month = Month;
            _Year = Year;

		}

		#endregion

		#region Properties

		public int  EMP_ID
		{
			 get { return _eMP_ID; }
		}

        public int MONTH
        {
            get { return _Month; }
        }

        public short YEAR
        {
            get { return _Year; }
        }

        #endregion

    }
}
