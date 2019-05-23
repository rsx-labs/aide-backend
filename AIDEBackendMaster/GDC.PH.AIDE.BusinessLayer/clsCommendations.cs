using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsCommendations : BusinessObjectBase
    {

        #region InnerClass
        public enum clsCommendationsFields
        {
            COMMEND_ID,
            DEPT_ID,
            EMPLOYEE,
            PROJECT,
            DATE_SENT,
            SENT_BY,
            REASON
        }
        #endregion

        #region Data Members

        int _commendID;
        int _deptID;
        string _employee;
        string _project;
        DateTime _dateSent;
        string _sentBy;
        string _reason;

        #endregion

        #region Properties

        public int COMMEND_ID
        {
            get { return _commendID; }
            set
            {
                if (_commendID != value)
                {
                    _commendID = value;
                    PropertyHasChanged("COMMEND_ID");
                }
            }
        }

        public int DEPT_ID
        {
            get { return _deptID; }
            set
            {
                if (_deptID != value)
                {
                    _deptID = value;
                    PropertyHasChanged("DEPT_ID");
                }
            }
        }

        public string EMPLOYEE
        {
            get { return _employee; }
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    PropertyHasChanged("EMPLOYEE");
                }
            }
        }

        public string PROJECT
        {
            get { return _project; }
            set
            {
                if (_project != value)
                {
                    _project = value;
                    PropertyHasChanged("PROJECT");
                }
            }
        }

        public DateTime  DATE_SENT
        {
            get { return _dateSent; }
            set
            {
                if (_dateSent != value)
                {
                    _dateSent = value;
                    PropertyHasChanged("DATE_SENT");
                }
            }
        }

        public string SENT_BY
        {
            get { return _sentBy; }
            set
            {
                if (_sentBy != value)
                {
                    _sentBy = value;
                    PropertyHasChanged("SENT_BY");
                }
            }
        }

        public string REASON
        {
            get { return _reason; }
            set
            {
                if (_reason != value)
                {
                    _reason = value;
                    PropertyHasChanged("REASON");
                }
            }
        }
 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("COMMEND_ID", "COMMEND_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPT_ID", "DEPT_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPLOYEE", "EMPLOYEE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJECT", "PROJECT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_SENT", "DATE_SENT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SENT_BY", "SENT_BY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("REASON", "REASON"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////