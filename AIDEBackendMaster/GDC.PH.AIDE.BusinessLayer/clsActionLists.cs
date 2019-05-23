using System;
using System.Collections.Generic;
using System.Text;
/* By Jester Sanchez / Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsActionLists : BusinessObjectBase
    {
        #region InnerClass
        public enum clsActionListsFields
        {
            ACTREF,
            ACT_MESSAGE,
            EMP_ID,
            NICK_NAME,
            DUE_DATE,
            DATE_CLOSED

        }
        #endregion

        #region Data Members

        string _action_ID;
        string _action_Message;
        int _action_Assignee;
        string _nick_Name;
        DateTime _action_DueDate;
        string _action_DateClosed;

        #endregion

        #region Properties

        public string ACTREF
        {
            get { return _action_ID; }
            set
            {
                if (_action_ID != value)
                {
                    _action_ID = value;
                    PropertyHasChanged("ACTREF");
                }
            }
        }

        public string ACT_MESSAGE
        {
            get { return _action_Message; }
            set
            {
                if (_action_Message != value)
                {
                    _action_Message = value;
                    PropertyHasChanged("ACT_MESSAGE");
                }
            }
        }

        public int EMP_ID
        {
            get { return _action_Assignee; }
            set
            {
                if (_action_Assignee != value)
                {
                    _action_Assignee = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string NICK_NAME
        {
            get { return _nick_Name; }
            set
            {
                if (_nick_Name != value)
                {
                    _nick_Name = value;
                    PropertyHasChanged("NICK_NAME");
                }
            }
        }

        public DateTime DUE_DATE
        {
            get { return _action_DueDate; }
            set
            {
                if (_action_DueDate != value)
                {
                    _action_DueDate = value;
                    PropertyHasChanged("DUE_DATE");
                }
            }
        }

        public string DATE_CLOSED
        {
            get { return _action_DateClosed; }
            set
            {
                if (_action_DateClosed != value)
                {
                    _action_DateClosed = value;
                    PropertyHasChanged("DATE_CLOSED");
                }
            }
        }


        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ACTREF", "ACTREF"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ACT_MESSAGE", "ACT_MESSAGE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DUE_DATE", "DUE_DATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_CLOSED", "DATE_CLOSED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NICK_NAME", "NICK_NAME"));
        }

        #endregion
    }
}
