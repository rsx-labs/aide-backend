using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsBirthday : BusinessObjectBase
    {

        #region InnerClass
        public enum clsBirthdayFields
        {
            EMP_ID,
            FIRST_NAME,
            LAST_NAME,
            BIRTHDATE,
            IMAGE_PATH
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        DateTime _birthday;
        string _first_name;
        string _last_name;
        string _image_path;

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

        public DateTime BIRTHDAY
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    PropertyHasChanged("BIRTHDAY");
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

        public string IMAGE_PATH
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
