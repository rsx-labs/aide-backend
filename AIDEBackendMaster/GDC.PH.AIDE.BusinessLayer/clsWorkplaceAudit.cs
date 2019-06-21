using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsWorkplaceAudit : BusinessObjectBase
    {

        #region InnerClass
        public enum clsWorkplaceAuditFields
        {
            AUDIT_DAILY_ID,
            AUDIT_QUESTIONS_ID,
            EMP_ID,
            FY_WEEK,
            STATUS,
            DT_CHECKED,
            AUDIT_QUESTIONS,
            OWNER,
            AUDIT_QUESTIONS_GROUP
        }
        #endregion

        #region Data Members

        int _auditDailyID;
        int _auditQuestionsID;
        int _empID;
        int _fyWeek;
        int _status;
        DateTime _dtChecked;
        string _auditQuestions;
        string _owner;
        string _auditQuestionsGroup;

        #endregion

        #region Properties

        public int AUDIT_DAILY_ID
        {
            get { return _auditDailyID; }
            set
            {
                if (_auditDailyID != value)
                {
                    _auditDailyID = value;
                    PropertyHasChanged("AUDIT_DAILY_ID");
                }
            }
        }
        
        public int AUDIT_QUESTIONS_ID
        {
            get { return _auditQuestionsID; }
            set
            {
                if (_auditQuestionsID != value)
                {
                    _auditQuestionsID = value;
                    PropertyHasChanged("AUDIT_QUESTIONS_ID");
                }
            }
        }

        public int EMP_ID
        {
            get { return _empID; }
            set
            {
                if (_empID != value)
                {
                    _empID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public int FY_WEEK
        {
            get { return _fyWeek; }
            set
            {
                if (_fyWeek != value)
                {
                    _fyWeek = value;
                    PropertyHasChanged("FY_WEEK");
                }
            }
        }

        public int STATUS
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("STATUS");
                }
            }
        }

        public DateTime DT_CHECKED
        {
            get { return _dtChecked; }
            set
            {
                if (_dtChecked != value)
                {
                    _dtChecked = value;
                    PropertyHasChanged("DT_CHECKED");
                }
            }
        }

        public String AUDIT_QUESTIONS
        {
            get { return _auditQuestions; }
            set
            {
                if (_auditQuestions != value)
                {
                    _auditQuestions = value;
                    PropertyHasChanged("AUDIT_QUESTIONS");
                }
            }
        }

        public String OWNER
        {
            get { return _owner; }
            set
            {
                if (_owner != value)
                {
                    _owner = value;
                    PropertyHasChanged("OWNER");
                }
            }
        }

        public String AUDIT_QUESTIONS_GROUP
        {
            get { return _auditQuestionsGroup; }
            set
            {
                if (_auditQuestionsGroup != value)
                {
                    _auditQuestionsGroup = value;
                    PropertyHasChanged("AUDIT_QUESTIONS_GROUP");
                }
            }
        }

 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {

            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_DAILY_ID", "AUDIT_DAILY_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_QUESTIONS_ID", "AUDIT_QUESTIONS_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_WEEK", "FY_WEEK"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_CHECKED", "DT_CHECKED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_QUESTIONS", "AUDIT_QUESTIONS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OWNER", "OWNER"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_QUESTIONS_GROUP", "AUDIT_QUESTIONS_GROUP"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////