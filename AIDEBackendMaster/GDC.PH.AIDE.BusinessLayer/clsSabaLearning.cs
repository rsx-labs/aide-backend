using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSabaLearning : BusinessObjectBase
    {
        #region InnerClass
        public enum clsSabaLearningFields
        {
            SABA_ID,
            EMP_ID,
            TITLE,
            END_DATE,
            DATE_COMPLETED,
            IMAGE_PATH,
            TOTAL_ENROLL,
            TOTAL_COMPLETED
        }
        #endregion

        #region Data Members

        int _saba_id;
        int _saba_emp_id;
        string _saba_title;
        DateTime _saba_end_date;
        string _saba_date_completed;
        string _image_path;
        int _total_enroll;
        int _total_completed;

        #endregion

        #region Properties

        public int SABA_ID
        {
            get { return _saba_id; }
            set
            {
                if (_saba_id != value)
                {
                    _saba_id = value;
                    PropertyHasChanged("SABA_ID");
                }
            }
        }

        public int EMP_ID
        {
            get { return _saba_emp_id; }
            set
            {
                if (_saba_emp_id != value)
                {
                    _saba_emp_id = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string TITLE
        {
            get { return _saba_title; }
            set
            {
                if (_saba_title != value)
                {
                    _saba_title = value;
                    PropertyHasChanged("TITLE");
                }
            }
        }

        public DateTime END_DATE
        {
            get { return _saba_end_date; }
            set
            {
                if (_saba_end_date != value)
                {
                    _saba_end_date = value;
                    PropertyHasChanged("END_DATE");
                }
            }
        }

        public string DATE_COMPLETED
        {
            get { return _saba_date_completed; }
            set
            {
                if (_saba_date_completed != value)
                {
                    _saba_date_completed = value;
                    PropertyHasChanged("DATE_COMPLETED");
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

        public int TOTAL_ENROLL
        {
            get { return _total_enroll; }
            set
            {
                if (_total_enroll != value)
                {
                    _total_enroll = value;
                    PropertyHasChanged("TOTAL_ENROLL");
                }
            }
        }
        public int TOTAL_COMPLETED
        {
            get { return _total_completed; }
            set
            {
                if (_total_completed != value)
                {
                    _total_completed = value;
                    PropertyHasChanged("TOTAL_COMPLETED");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SABA_ID", "SABA_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TITLE", "TITLE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("END_DATE", "END_DATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_COMPLETED", "DATE_COMPLETED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
        }

        #endregion
    }
}
