using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsContributors : BusinessObjectBase
    {
        #region InnerClass
        public enum clsContributorsFields
        {
            FULL_NAME,
            DEPARTMENT,
            DIVISION,
            POSITION,
            IMAGE_PATH
        }
        #endregion

        #region Data Members

        string _fullname;
        string _department;
        string _division;
        string _position;
        string _imagepath;

        #endregion

        #region Properties

        public string FULL_NAME
        {
            get { return _fullname; }
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    PropertyHasChanged("FULL_NAME");
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

        public string POSITION
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    PropertyHasChanged("POSITION");
                }
            }
        }

        public string IMAGE_PATH
        {
            get { return _imagepath; }
            set
            {
                if (_imagepath != value)
                {
                    _imagepath = value;
                    PropertyHasChanged("IMAGE_PATH");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FULL_NAME", "FULL_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPARTMENT", "DEPARTMENT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DIVISION", "DIVISION"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POSITION", "POSITION"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
        }
        #endregion
    }
}
