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
            LAST_NAME,
            FIRST_NAME,
            MIDDLE_NAME,
            NICK_NAME,
            ACTIVE,
            BIRTHDATE,
            POSITION,
            DT_HIRED,
            MARITAL_STATUS,
            IMAGE_PATH,
            PERMISSION_GROUP,
            DEPARTMENT,
            DIVISION,
            SHIFT,
            EMAIL_ADDRESS,
            EMAIL_ADDRESS2,
            LOCATION,
            CEL_NO,
            LOCAL,
            HOMEPHONE,
            OTHER_PHONE,
            DT_REVIEWED,
            MARITAL_STATUS_ID,
            POSITION_ID,
            PERMISSION_GROUP_ID,
            DEPARTMENT_ID,
            DIVISION_ID,
            OLD_EMP_ID
            //STATUS
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        string _last_name;
        string _first_name;        
        string _middle_name;
        string _nick_name;
        int _active;
        DateTime _birthdate;
        string _POSITION;
        DateTime _dtHired;
        string _MARITAL_STATUS;
        object _image_path;
        string _permission_group;
        string _department;
        string _division;
        string _shift;
        string _eMAIL_ADDRESS;
        string _eMAIL_ADDRESS2;
        string _lOCATION;
        string _cEL_NO;
        int? _lOCAL;
        string _hOMEPHONE;
        string _oTHER_PHONE;
        DateTime _dT_REVIEWED;
        string _marital_status_id;
        int _position_id;
        int _permission_group_id;
        int _department_id;
        int _division_id;
        int _old_emp_id;
        //string _status;
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

        //public string STATUS
        //{
        //    get { return _status; }
        //    set
        //    {
        //        if (_status != value)
        //        {
        //            _status = value;
        //            PropertyHasChanged("STATUS");
        //        }
        //    }
        //}

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
            get { return _MARITAL_STATUS; }
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

        public int ACTIVE
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    PropertyHasChanged("ACTIVE");
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

        public string MARITAL_STATUS_ID
        {
            get { return _marital_status_id; }
            set
            {
                if (_marital_status_id != value)
                {
                    _marital_status_id = value;
                    PropertyHasChanged("MARITAL_STATUS_ID");
                }
            }
        }

        public int POSITION_ID
        {
            get { return _position_id; }
            set
            {
                if (_position_id != value)
                {
                    _position_id = value;
                    PropertyHasChanged("POSITION_ID");
                }
            }
        }

        public int PERMISSION_GROUP_ID
        {
            get { return _permission_group_id; }
            set
            {
                if (_permission_group_id != value)
                {
                    _permission_group_id = value;
                    PropertyHasChanged("PERMISSION_GROUP_ID");
                }
            }
        }

        public int DEPARTMENT_ID
        {
            get { return _department_id; }
            set
            {
                if (_department_id != value)
                {
                    _department_id = value;
                    PropertyHasChanged("DEPARTMENT_ID");
                }
            }
        }

        public int DIVISION_ID
        {
            get { return _division_id; }
            set
            {
                if (_division_id != value)
                {
                    _division_id = value;
                    PropertyHasChanged("DIVISION_ID");
                }
            }
        }
        public int OLD_EMP_ID
        {
            get { return _old_emp_id; }
            set
            {
                if (_old_emp_id != value)
                {
                    _old_emp_id = value;
                    PropertyHasChanged("OLD_EMP_ID");
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
            //ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DT_HIRED", "DT_HIRED", 15));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_HIRED", "DT_HIRED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERMISSION_GROUP", "PERMISSION_GROUP"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SHIFT", "SHIFT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ACTIVE", "ACTIVE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POSITION_ID", "POSITION_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERMISSION_GROUP_ID", "PERMISSION_GROUP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPARTMENT_ID", "DEPARTMENT_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DIVISION_ID", "DIVISION_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OLD_EMP_ID", "OLD_EMP_ID"));
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
