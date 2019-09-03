using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProject : BusinessObjectBase
    {

        #region InnerClass
        public enum clsPROJECTFields
        {
            PROJ_ID,
            PROJ_CD,
            PROJ_NAME,
            CATEGORY,
            BILLABILITY,
            EMP_ID
        }
        public enum clsPROJECTFields2
        {
            STATUS,
            NAME,
            FIRSTMONTH,
            SECONDMONTH,
            THIRDMONTH
        }
        #endregion

        #region Data Members

        int _pROJ_ID;
        string _pROJ_CD;
        string _pROJ_NAME;
        byte _cATEGORY;
        byte _bILLABILITY;
        string _status;
        string _name;
        string _firstmonth;
        string _secondmonth;
        string _thirdmonth;
        int _empID;

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _empID; }
            set
            {
                if (_empID != value)
                {
                    _empID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public int PROJ_ID
        {
            get { return _pROJ_ID; }
            set
            {
                if (_pROJ_ID != value)
                {
                    _pROJ_ID = value;
                    PropertyHasChanged("PROJ_ID");
                }
            }
        }

        public string PROJ_CD
        {
            get { return _pROJ_CD; }
            set
            {
                if (_pROJ_CD != value)
                {
                    _pROJ_CD = value;
                    PropertyHasChanged("PROJ_CD");
                }
            }
        }

        public string PROJ_NAME
        {
            get { return _pROJ_NAME; }
            set
            {
                if (_pROJ_NAME != value)
                {
                    _pROJ_NAME = value;
                    PropertyHasChanged("PROJ_NAME");
                }
            }
        }

        public byte CATEGORY
        {
            get { return _cATEGORY; }
            set
            {
                if (_cATEGORY != value)
                {
                    _cATEGORY = value;
                    PropertyHasChanged("CATEGORY");
                }
            }
        }

        public byte BILLABILITY
        {
            get { return _bILLABILITY; }
            set
            {
                if (_bILLABILITY != value)
                {
                    _bILLABILITY = value;
                    PropertyHasChanged("BILLABILITY");
                }
            }
        }

        public string STATUS
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("STATUS");
                }
            }
        }

        public string NAME
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged("NAME");
                }
            }
        }
        public string FIRSTMONTH
        {
            get { return _firstmonth; }
            set
            {
                if (_firstmonth != value)
                {
                    _firstmonth = value;
                    PropertyHasChanged("FIRSTMONTH");
                }
            }
        }

        public string SECONDMONTH
        {
            get { return _secondmonth; }
            set
            {
                if (_secondmonth != value)
                {
                    _secondmonth = value;
                    PropertyHasChanged("SECONDMONTH");
                }
            }
        }
        public string THIRDMONTH
        {
            get { return _thirdmonth; }
            set
            {
                if (_thirdmonth != value)
                {
                    _thirdmonth = value;
                    PropertyHasChanged("THIRDMONTH");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJ_CD", "PROJ_CD"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PROJ_CD", "PROJ_CD", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJ_NAME", "PROJ_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PROJ_NAME", "PROJ_NAME", 20));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CATEGORY", "CATEGORY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("BILLABILITY", "BILLABILITY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
        }

        #endregion

    }
}
