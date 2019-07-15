using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsBillables: BusinessObjectBase
	{

		#region InnerClass
		public enum clsBillabilityFields
		{
            EMPID,
            NAME,
            TOTAL_HOURS,
            BILL_STATUS,
            MONTH,
            YEAR
		}
		#endregion

		#region Data Members
        int _eMPID;
		int _mONTH;
		int _yEAR;
        short _sTATUS;
        double _hOURS;
        string _nAME;
		#endregion

		#region Properties
        
        public string NAME
        {
            get { return _nAME; }
            set
            {
                if (_nAME != value)
                {
                    _nAME = value;
                    PropertyHasChanged("NAME");
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

        public double TOTAL_HOURS
        {
            get { return _hOURS; }
            set
            {
                if (_hOURS != value)
                {
                    _hOURS = value;
                    PropertyHasChanged("TOTAL_HOURS");
                }
            }
        }

        public short BILL_STATUS
        {
            get { return _sTATUS; }
            set
            {
                if (_sTATUS != value)
                {
                    _sTATUS = value;
                    PropertyHasChanged("BILL_STATUS");
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
            //ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPID", "EMPID"));
            //ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
            //ValidationRules.AddRules(new Validation.ValidateRuleNotNull("YEAR", "YEAR"));
            //ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
		}

		#endregion

	}
}
