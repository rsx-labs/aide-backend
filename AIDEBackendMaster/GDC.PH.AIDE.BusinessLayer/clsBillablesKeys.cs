using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsBillablesKeys
	{

		#region Data Members

        int _empID;
        int _month;
        int _year;
		#endregion

		#region Constructor

		public clsBillablesKeys(int _eMPID, int _Month, int _Year)
		{
            _empID = _eMPID;
            _month = _Month;
            _year = _Year;
		}

  		#endregion

		#region Properties
        
        public int EMPID
        {
            get { return _empID; }
        }

        public int MONTH
        {
            get { return _month; }
        }

        public int YEAR
        {
            get { return _year; }
        }
		#endregion

	}
}
