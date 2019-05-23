using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsEmployeeAttendance :BusinessObjectBase
    {

        #region InnerClass
        public enum clsEmployeeAttendanceFields
        {
            EMP_ID,
            FIRST_NAME,
            LAST_NAME,
            POSITION,
            MONTH,
            YEAR,
            DateNow

        }
        #endregion

        #region Data Members
        int _eMP_ID;
        string _fIRSTNAME;
        string _lASTNAME;
        string _pOSITION;
        int _mONTH;
        short _yEAR;
        int _dATENOW;
        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
            set
            {
                if (_eMP_ID !=value)
                {
                    _eMP_ID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }
        public string FIRST_NAME
        {
            get { return _fIRSTNAME; }
            set
            {
                if (_fIRSTNAME != value)
                {
                    _fIRSTNAME = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }

        public string LAST_NAME
        {
            get { return _lASTNAME; }
            set
            {
                if (_lASTNAME != value)
                {
                    _lASTNAME = value;
                    PropertyHasChanged("LAST_NAME");
                }
            }
        }


        public string POSITION
        {
            get { return _pOSITION; }
            set
            {
                if (_pOSITION != value)
                {
                    _pOSITION = value;
                    PropertyHasChanged("POSITION");
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
        public short YEAR
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
        public int DateNow
        {
            get { return _dATENOW; }
            set
            {
                if (_dATENOW != value)
                {
                    _dATENOW = value;
                    PropertyHasChanged("DateNow");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("YEAR", "YEAR"));
        }

        #endregion
    }
    
}