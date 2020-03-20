using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsReports : BusinessObjectBase
    {
        #region InnerClass
        public enum clsReportsFields
        {
            REPORT_ID,
            OPT_ID,
            MODULE_ID,
            DESCRIPTION,
            FILE_PATH
        }
        #endregion

        #region Data Members

        int _report_id;
        int _opt_id;
        int _module_id;
        string _description;
        string _file_path;

        #endregion

        #region Properties

        public int REPORT_ID
        {
            get { return _report_id; }
            set
            {
                if (_report_id != value)
                {
                    _report_id = value;
                    PropertyHasChanged("REPORT_ID");
                }
            }
        }

        public int MODULE_ID
        {
            get { return _module_id; }
            set
            {
                if (_module_id != value)
                {
                    _module_id = value;
                    PropertyHasChanged("MODULE_ID");
                }
            }
        }

        public int OPT_ID
        {
            get { return _opt_id; }
            set
            {
                if (_opt_id != value)
                {
                    _opt_id = value;
                    PropertyHasChanged("OPT_ID");
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

        public string FILE_PATH
        {
            get { return _file_path; }
            set
            {
                if (_file_path != value)
                {
                    _file_path = value;
                    PropertyHasChanged("FILE_PATH");
                }
            }
        }

        #endregion

        #region Validation

        //internal override void AddValidationRules()
        //{
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SABA_ID", "SABA_ID"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TITLE", "TITLE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("END_DATE", "END_DATE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_COMPLETED", "DATE_COMPLETED"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
        //}

        #endregion
    }
}
