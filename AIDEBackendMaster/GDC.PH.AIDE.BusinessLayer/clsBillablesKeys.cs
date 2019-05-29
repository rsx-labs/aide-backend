using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsBillablesKeys
	{

		#region Data Members

        int _empID;
        DateTime _dateStart;
        DateTime _dateFinish;
        String _userChoice = " ";
        int _month;
        int _year;
        int _status;
		#endregion

		#region Constructor

		public clsBillablesKeys(int _eMPID, DateTime _DateStart, DateTime _DateFinish, String _UserChoice, int _Month, int _Year)
		{
            _empID = _eMPID;
            _dateFinish = _DateFinish;
            _dateStart = _DateStart;
            _userChoice = _UserChoice;
            _month = _Month;
            _year = _Year;
		}

  		#endregion

		#region Properties
        
        public int EMPID
        {
            get { return _empID; }
        }

        public DateTime DATESTART
        {
            get { return _dateStart; }
        }

        public DateTime DATEFINISH
        {
            get { return _dateFinish; }
        }

        public String USERCHOICE
        {
            get { return _userChoice; }
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
