using System;
using System.Collections.Generic;
using System.Text;
/* By Jester Sanchez / Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSendCode : BusinessObjectBase
    {
        #region InnerClass
        public enum clsSendCodeFields
        {
            WORK_EMAIL,
            FNAME,
            LNAME
        }
        #endregion

        #region Data Members

        string _sendcode_Work_Email;
        string _sendcode_Fname;
        string _sendcode_Lname;

        #endregion

        #region Properties

        public string WORK_EMAIL
        {
            get { return _sendcode_Work_Email; }
            set
            {
                if (_sendcode_Work_Email != value)
                {
                    _sendcode_Work_Email = value;
                    PropertyHasChanged("WORK_EMAIL");
                }
            }
        }

        public string FNAME
        {
            get { return _sendcode_Fname; }
            set
            {
                if (_sendcode_Fname != value)
                {
                    _sendcode_Fname = value;
                    PropertyHasChanged("FNAME");
                }
            }
        }


        public string LNAME
        {
            get { return _sendcode_Lname; }
            set
            {
                if (_sendcode_Lname != value)
                {
                    _sendcode_Lname = value;
                    PropertyHasChanged("LNAME");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WORK_EMAIL", "WORK_EMAIL"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FNAME", "FNAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LNAME", "LNAME"));
        }

        #endregion
    }
}
