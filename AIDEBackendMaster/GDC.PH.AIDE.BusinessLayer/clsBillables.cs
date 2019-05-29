using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsBillables: BusinessObjectBase
	{

		#region InnerClass
		public enum clsAttendanceFields
		{
            EMPID,
            NICK_NAME,
            HOURS,
            MONTH,
            YEAR

		}
        public enum clsAttendanceSummaryFields
        {
            EMPID,
            NICK_NAME,
            SL,
            VL,
            HOLIDAY,
            //IBP,
            TOTAL,
            HALFDAY,
            HALFSL,
            HALFVL
        }
		#endregion

		#region Data Members

        int _eMPID;
		int _mONTH;
		int _yEAR;
        decimal _hOURS;
        string _nICK_NAME;
        decimal _hOLIDAY;
        decimal _sL;
        decimal _vL;
        //decimal _iBP;
        decimal _hALFDAY;
        decimal _hALFSL;
        decimal _hALFVL;
        decimal _tOTAL;

		#endregion

		#region Properties
            
            public string NICK_NAME
            {
                get { return _nICK_NAME; }
                set
                {
                    if (_nICK_NAME != value)
                    {
                        _nICK_NAME = value;
                        PropertyHasChanged("NICK_NAME");
                    }
                }
            }
            public int EMPID
            {
                get { return _eMPID; }
                set
                {
                    if (_eMPID != value)
                    {
                        _eMPID = value;
                        PropertyHasChanged("EMPID");
                    }
                }
            }

        public decimal HOURS
        {
            get { return _hOURS; }
            set
            {
                if (_hOURS != value)
                {
                    _hOURS = value;
                    PropertyHasChanged("HOURS");
                }
            }
        }

        public decimal SL
        {
            get { return _sL; }
            set
            {
                if (_sL != value)
                {
                    _sL = value;
                    PropertyHasChanged("SL");
                }
            }
        }
        public decimal VL
        {
            get { return _vL; }
            set
            {
                if (_vL != value)
                {
                    _vL = value;
                    PropertyHasChanged("VL");
                }
            }
        }

        //public decimal IBP
        //{
        //    get { return _iBP; }
        //    set
        //    {
        //        if (_iBP != value)
        //        {
        //            _iBP = value;
        //            PropertyHasChanged("IBP");
        //        }
        //    }
        //}
        public decimal HOLIDAY
        {
            get { return _hOLIDAY; }
            set
            {
                if (_hOLIDAY != value)
                {
                    _hOLIDAY = value;
                    PropertyHasChanged("HOLIDAY");
                }
            }
        }
        public decimal HALFDAY
        {
            get { return _hALFDAY; }
            set
            {
                if (_hALFDAY != value)
                {
                    _hALFDAY = value;
                    PropertyHasChanged("HALFDAY");
                }
            }
        }

        public decimal HALFVL
        {
            get { return _hALFVL; }
            set
            {
                if (_hALFVL != value)
                {
                    _hALFVL = value;
                    PropertyHasChanged("HALFVL");
                }
            }
        }
        public decimal HALFSL
        {
            get { return _hALFSL; }
            set
            {
                if (_hALFSL != value)
                {
                    _hALFSL = value;
                    PropertyHasChanged("HALFSL");
                }
            }
        }

        public decimal TOTAL
        {
            get { return _tOTAL; }
            set
            {
                if (_tOTAL != value)
                {
                    _tOTAL = value;
                    PropertyHasChanged("TOTAL");
                }
            }
        }

        public int MONTH
        {
            get { return _mONTH; }
            set
            {
                if (_mONTH != value)
                {
                    _mONTH = value;
                    PropertyHasChanged("MONTH");
                }
            }
        }

        public int YEAR
        {
            get { return _yEAR; }
            set
            {
                if (_yEAR != value)
                {
                    _yEAR = value;
                    PropertyHasChanged("YEAR");
                }
            }
        }
        

		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPID", "EMPID"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("YEAR", "YEAR"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
		}

		#endregion

	}
}
