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
            POS_ID,
            DESCR,
            FIRST_NAME,
            LAST_NAME,
            IMAGE_PATH
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
        int _pos_ID;
        string _descr;
        string _first_name;
        string _last_name;
        object _image_path;

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

        public int POS_ID
        {
            get { return _pos_ID; }
            set
            {
                if (_pos_ID != value)
                {
                    _pos_ID = value;
                    PropertyHasChanged("POS_ID");
                }
            }
        }

        public string DESCR
        {
            get { return _descr; }
            set
            {
                if (_descr != value)
                {
                    _descr = value;
                    PropertyHasChanged("DESCR");
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
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POS_ID", "POS_ID"));
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
