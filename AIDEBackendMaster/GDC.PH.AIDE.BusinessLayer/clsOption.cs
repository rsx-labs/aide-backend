using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsOption : BusinessObjectBase
    {
        #region InnerClass
        public enum clsOptionFields
        {
            OPTION_ID,
            MODULE_ID,
            FUNCTION_ID,
            DESCRIPTION,
            VALUE,
            MODULE_DESCR,
            FUNCTION_DESCR
        }
        #endregion

        #region Data Members

        int _optionID;
        int _moduleID;
        int _functionID;
        string _description;
        string _value;
        string _moduleDescr;
        string _functionDescr;

        #endregion

        #region Properties

        public int OPTION_ID
        {
            get { return _optionID; }
            set
            {
                if (_optionID != value)
                {
                    _optionID = value;
                    PropertyHasChanged("OPTION_ID");
                }
            }
        }

        public int MODULE_ID
        {
            get { return _moduleID; }
            set
            {
                if (_moduleID != value)
                {
                    _moduleID = value;
                    PropertyHasChanged("MODULE_ID");
                }
            }
        }

        public int FUNCTION_ID
        {
            get { return _functionID; }
            set
            {
                if (_functionID != value)
                {
                    _functionID = value;
                    PropertyHasChanged("FUNCTION_ID");
                }
            }
        }

        public string DESCRIPTION
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged("DESCRIPTION");
                }
            }
        }

        public string VALUE
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    PropertyHasChanged("VALUE");
                }
            }
        }

        public string MODULE_DESCR
        {
            get { return _moduleDescr; }
            set
            {
                if (_moduleDescr != value)
                {
                    _moduleDescr = value;
                    PropertyHasChanged("MODULE_DESCR");
                }
            }
        }

        public string FUNCTION_DESCR
        {
            get { return _functionDescr; }
            set
            {
                if (_functionDescr != value)
                {
                    _functionDescr = value;
                    PropertyHasChanged("FUNCTION_DESCR");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("VALUE", "VALUE"));
        }

        #endregion

    }
}
