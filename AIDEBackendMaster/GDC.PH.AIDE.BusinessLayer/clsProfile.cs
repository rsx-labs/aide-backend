using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProfile : BusinessObjectBase
    {
        #region Inner Class

        public enum clsProfileFields
        {
          EMP_ID,
          WS_EMP_ID,
          DEPT_ID,
          LAST_NAME,
          FIRST_NAME,
          MIDDLE_NAME,
          NICK_NAME,
          BIRTHDATE,
          DATE_HIRED,
          IMAGE_PATH,
          DEPARTMENT,
          DIVISION,
          POSITION,
          EMAIL_ADDRESS,
          EMAIL_ADDRESS2,
          LOCATION,
          CEL_NO,
          LOCAL,
          HOMEPHONE,
          OTHER_PHONE,
          DT_REVIEWED,
          Permission,
          PERMISSION_ID,
          CivilStatus,
          SHIFT_STATUS
        }

        #endregion
        
        #region Data Members
        int _eMP_ID;
        string wS_EMP_ID;
        int _dEPT_ID;
        string _lAST_NAME;
        string _fIRST_NAME;
        string _mIDDLE_NAME;
        string _nICK_NAME;
        DateTime _bIRTHDATE;
        DateTime _dATE_HIRED;
        string _iMAGE_PATH;
        string _dEPARTMENT;
        string _dIVISION;
        string _pOSITION;
        string _eMAIL_ADDRESS;
        string _eMAIL_ADDRESS2;
        string _lOCATION;
        string _cEL_NO;
        int _lOCAL;
        string _hOMEPHONE;
        string _oTHER_PHONE;
        DateTime _dT_REVIEWED;
        string _pERMISSION;
        int _pERMISSION_ID;
        string _cIVILSTATUS;
        string _SHIFT_STATUS;
     
        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
            set
            {
                if (_eMP_ID != value)
                {
                    _eMP_ID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string WS_EMP_ID
        {
            get { return wS_EMP_ID; }
            set
            {
                if (wS_EMP_ID != value)
                {
                    wS_EMP_ID = value;
                    PropertyHasChanged("WS_EMP_ID");
                }
            }
        }

        public int DEPT_ID
        {
            get { return _dEPT_ID; }
            set
            {
                if (_dEPT_ID != value)
                {
                    _dEPT_ID = value;
                    PropertyHasChanged("DEPT_ID,");
                }
            }
        }


        public string LAST_NAME
        {
            get { return _lAST_NAME; }
            set
            {
                if (_lAST_NAME != value)
                {
                    _lAST_NAME = value;
                    PropertyHasChanged("LAST_NAME");
                }
            }
        }

        public string FIRST_NAME
        {
            get { return _fIRST_NAME; }
            set
            {
                if (_fIRST_NAME != value)
                {
                    _fIRST_NAME = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }

        public string MIDDLE_NAME
        {
            get { return _mIDDLE_NAME; }
            set
            {
                if (_mIDDLE_NAME != value)
                {
                    _mIDDLE_NAME = value;
                    PropertyHasChanged("MIDDLE_NAME");
                }
            }
        }

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

        public DateTime BIRTHDATE
        {
            get { return _bIRTHDATE; }
            set
            {
                if (_bIRTHDATE != value)
                {
                    _bIRTHDATE = value;
                    PropertyHasChanged("BIRTHDATE");
                }
            }
        }


        public DateTime DATE_HIRED
        {
            get { return _dATE_HIRED; }
            set
            {
                if (_dATE_HIRED != value)
                {
                    _dATE_HIRED = value;
                    PropertyHasChanged("DATE_HIRED");
                }
            }
        }

        public string IMAGE_PATH
        {
            get { return _iMAGE_PATH; }
            set
            {
                if (_iMAGE_PATH != value)
                {
                    _iMAGE_PATH = value;
                    PropertyHasChanged("IMAGE_PATH");
                }
            }
        }

        public string DEPARTMENT
        {
            get { return _dEPARTMENT; }
            set
            {
                if (_dEPARTMENT != value)
                {
                    _dEPARTMENT = value;
                    PropertyHasChanged("DEPARTMENT");
                }
            }
        }

        public string DIVISION
        {
            get { return _dIVISION; }
            set
            {
                if (_dIVISION != value)
                {
                    _dIVISION = value;
                    PropertyHasChanged("DIVISION");
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


        public string EMAIL_ADDRESS
        {
            get { return _eMAIL_ADDRESS; }
            set
            {
                if (_eMAIL_ADDRESS != value)
                {
                    _eMAIL_ADDRESS = value;
                    PropertyHasChanged("EMAIL_ADDRESS");
                }
            }
        }


        public string EMAIL_ADDRESS2
        {
            get { return _eMAIL_ADDRESS2; }
            set
            {
                if (_eMAIL_ADDRESS2 != value)
                {
                    _eMAIL_ADDRESS2 = value;
                    PropertyHasChanged("EMAIL_ADDRESS2");
                }
            }
        }


        public string LOCATION
        {
            get { return _lOCATION; }
            set
            {
                if (_lOCATION != value)
                {
                    _lOCATION = value;
                    PropertyHasChanged("LOCATION");
                }
            }
        }


        public string CEL_NO
        {
            get { return _cEL_NO; }
            set
            {
                if (_cEL_NO != value)
                {
                    _cEL_NO = value;
                    PropertyHasChanged("CEL_NO");
                }
            }
        }

        public int LOCAL
        {
            get { return _lOCAL; }
            set
            {
                if (_lOCAL != value)
                {
                    _lOCAL = value;
                    PropertyHasChanged("LOCAL");
                }
            }
        }

        public string HOMEPHONE
        {
            get { return _hOMEPHONE; }
            set
            {
                if (_hOMEPHONE != value)
                {
                    _hOMEPHONE = value;
                    PropertyHasChanged("HOMEPHONE");
                }
            }
        }


        public string OTHER_PHONE
        {
            get { return _oTHER_PHONE; }
            set
            {
                if (_oTHER_PHONE != value)
                {
                    _oTHER_PHONE = value;
                    PropertyHasChanged("OTHER_PHONE");
                }
            }
        }

        public DateTime DT_REVIEWED
        {
            get { return _dT_REVIEWED; }
            set
            {
                if (_dT_REVIEWED != value)
                {
                    _dT_REVIEWED = value;
                    PropertyHasChanged("DT_REVIEWED");
                }
            }
        }

        public string PERMISSION
        {
            get { return _pERMISSION; }
            set
            {
                if (_pERMISSION != value)
                {
                    _pERMISSION = value;
                    PropertyHasChanged("PERMISSION");
                }
            }
        }

        public int PERMISSION_ID
        {
            get { return _pERMISSION_ID; }
            set
            {
                if (_pERMISSION_ID != value)
                {
                    _pERMISSION_ID = value;
                    PropertyHasChanged("PERMISSION_ID");
                }
            }
        }


        public String CIVILSTATUS
        {
            get { return _cIVILSTATUS; }
            set
            {
                if (_cIVILSTATUS != value)
                {
                    _cIVILSTATUS = value;
                    PropertyHasChanged("CIVILSTATUS");
                }
            }
        }

        public String SHIFT_STATUS
        {
            get { return _SHIFT_STATUS; }
            set
            {
                if (_SHIFT_STATUS != value)
                {
                    _SHIFT_STATUS = value;
                    PropertyHasChanged("SHIFT_STATUS");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WS_EMP_ID", "WS_EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPT_ID", "DEPT_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LAST_NAME", "LAST_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FIRST_NAME", "FIRST_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("BIRTHDATE", "BIRTHDATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_HIRED", "DATE_HIRED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPARTMENT", "DEPARTMENT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DIVISION", "DIVISION"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMAIL_ADDRESS", "EMAIL_ADDRESS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMAIL_ADDRESS2", "EMAIL_ADDRESS2"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCATION", "LOCATION"));           
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CEL_NO", "CEL_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCAL,", "LOCAL,"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("HOMEPHONE,", "HOMEPHONE,"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OTHER_PHONE", "OTHER_PHONE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_REVIEWED,", "DT_REVIEWED,"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERMISSION,", "PERMISSION,"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERMISSION_ID", "PERMISSION_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CIVILSTATUS,", "CIVILSTATUS,"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SHIFT_STATUS,", "SHIFT_STATUS,"));

            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Department", "Department", 20));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LAST_NAME", "LAST_NAME", 20));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FIRST_NAME", "FIRST_NAME", 20));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("MIDDLE_INITIAL", "MIDDLE_INITIAL", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NICK_NAME", "NICK_NAME", 10));          
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE_PATH", "IMAGE_PATH", 50));










        }

        #endregion
    }
}
