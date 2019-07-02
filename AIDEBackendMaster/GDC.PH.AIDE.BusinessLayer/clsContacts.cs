using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsContacts : BusinessObjectBase
    {

        #region InnerClass
        public enum clsContactsFields
        {
            EMP_ID,
            EMAIL_ADDRESS,
            EMAIL_ADDRESS2,
            LOCATION,
            CEL_NO,
            LOCAL,
            HOMEPHONE,
            OTHER_PHONE,
            DT_REVIEWED,
            POSITION,
            MARITAL_STATUS,
            FIRST_NAME,
            LAST_NAME,
            MIDDLE_NAME,
            IMAGE_PATH,
            NICK_NAME,
            BIRTHDATE,
            DT_HIRED,
            STATUS,
            PERMISSION_GROUP,
            DEPARTMENT,
            DIVISION,
            SHIFT

        }
        #endregion

        #region Data Members

        int _eMP_ID;
        string _eMAIL_ADDRESS;
        string _eMAIL_ADDRESS2;
        string _lOCATION;
        string _cEL_NO;
        int? _lOCAL;
        string _hOMEPHONE;
        string _oTHER_PHONE;
        DateTime _dT_REVIEWED;
        string _POSITION;
        string _MARITAL_STATUS;
        string _first_name;
        string _last_name;
        string _middle_name;
        object _image_path;
        string _nick_name;
        DateTime _birthdate;
        DateTime _dtHired;
        string _status;
        string _permission_group;
        string _department;
        string _division;
        string _shift;
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

        public int? LOCAL
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

        public string POSITION
        {
            get { return _POSITION; }
            set
            {
                if (_POSITION != value)
                {
                    _POSITION = value;
                    PropertyHasChanged("POSITION");
                }
            }
        }

        public string MARITAL_STATUS
        {
            get { return MARITAL_STATUS; }
            set
            {
                if (_MARITAL_STATUS != value)
                {
                    _MARITAL_STATUS = value;
                    PropertyHasChanged("MARITAL_STATUS");
                }
            }
        }

        public string FIRST_NAME
        {
            get { return _first_name; }
            set
            {
                if (_first_name != value)
                {
                    _first_name = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }

        public string LAST_NAME
        {
            get { return _last_name; }
            set
            {
                if (_last_name != value)
                {
                    _last_name = value;
                    PropertyHasChanged("LAST_NAME");
                }
            }
        }

        public object IMAGE_PATH
        {
            get { return _image_path; }
            set
            {
                if (_image_path != value)
                {
                    _image_path = value;
                    PropertyHasChanged("IMAGE_PATH");
                }
            }
        }

        public string NICK_NAME
        {
            get { return _nick_name; }
            set
            {
                if (_nick_name != value)
                {
                    _nick_name = value;
                    PropertyHasChanged("NICK_NAME");
                }
            }
        }

        public string MIDDLE_NAME
        {
            get { return _middle_name; }
            set
            {
                if (_middle_name != value)
                {
                    _middle_name = value;
                    PropertyHasChanged("MIDDLE_NAME");
                }
            }
        }

        public DateTime BIRTHDATE
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    PropertyHasChanged("BIRTHDATE");
                }
            }
        }

        public DateTime DT_HIRED
        {
            get { return _dtHired; }
            set
            {
                if (_dtHired != value)
                {
                    _dtHired = value;
                    PropertyHasChanged("DT_HIRED");
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

        public string PERMISSION_GROUP
        {
            get { return _permission_group; }
            set
            {
                if (_permission_group != value)
                {
                    _permission_group = value;
                    PropertyHasChanged("PERMISSION_GROUP");
                }
            }
        }

        public string DEPARTMENT
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    PropertyHasChanged("DEPARTMENT");
                }
            }
        }

        public string DIVISION
        {
            get { return _division; }
            set
            {
                if (_division != value)
                {
                    _division = value;
                    PropertyHasChanged("DIVISION");
                }
            }
        }

        public string SHIFT
        {
            get { return _shift; }
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    PropertyHasChanged("SHIFT");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMAIL_ADDRESS", "EMAIL_ADDRESS"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EMAIL_ADDRESS", "EMAIL_ADDRESS", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EMAIL_ADDRESS2", "EMAIL_ADDRESS2", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCATION", "LOCATION"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LOCATION", "LOCATION", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CEL_NO", "CEL_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CEL_NO", "CEL_NO", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("HOMEPHONE", "HOMEPHONE", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHER_PHONE", "OTHER_PHONE", 15));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_REVIEWED", "DT_REVIEWED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POSITION", "POSITION"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NICK_NAME", "NICK_NAME", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DT_HIRED", "DT_HIRED", 15));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_HIRED", "DT_HIRED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERMISSION_GROUP", "PERMISSION_GROUP"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPARTMENT", "DEPARTMENT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DIVISION", "DIVISION"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SHIFT", "SHIFT"));
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
