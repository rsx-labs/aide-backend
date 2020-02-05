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
            DT_CHECK_FLG,
            AUDIT_QUESTIONS,
            OWNER,
            AUDIT_QUESTIONS_GROUP,
            AUDITSCHED_MONTH,
            WEEKDAYS,
            NICKNAME,
            WEEKDATE,
            WEEKDATESCHED,
            DATE_CHECKED,
            AUDIT_ID

        }
        #endregion

        #region Data Members

        int _auditDailyID;
        int _auditQuestionsID;
        int _empID;
        int _fyWeek;
        int _status;
        string _dtChecked;
        string _auditQuestions;
        string _owner;
        string _auditQuestionsGroup;
        string _auditschedmonth;
        string _weekDays;
        string _nickName;
        string _weekDate;
        int _dt_check_flg;
        string _week_Date_Sched;
        string _date_checked;
        int _auditid;
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
        public int AUDIT_ID
        {
            get { return _auditid; }
            set
            {
                if (_auditid != value)
                {
                    _auditid = value;
                    PropertyHasChanged("AUDIT_ID");
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

        public String DT_CHECKED
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
        public int DT_CHECK_FLG
        {
            get { return _dt_check_flg; }
            set
            {
                if (_dt_check_flg != value)
                {
                    _dt_check_flg = value;
                    PropertyHasChanged("DT_CHECK_FLG");
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
        public string OWNER
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

        public string AUDITSCHED_MONTH
        {
            get { return _auditschedmonth; }
            set
            {
                if (_auditschedmonth != value)
                {
                    _auditschedmonth = value;
                    PropertyHasChanged("AUDITSCHED_MONTH");
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
        public string WEEKDAYS
        {
            get { return _weekDays; }
            set
            {
                if (_weekDays != value)
                {
                    _weekDays = value;
                    PropertyHasChanged("WEEKDAYS");
                }
            }
        }
        public string NICKNAME
        {
            get { return _nickName; }
            set
            {
                if (_nickName != value)
                {
                    _nickName = value;
                    PropertyHasChanged("NICKNAME");
                }
            }
        }
        public string WEEKDATE
        {
            get { return _weekDate; }
            set
            {
                if (_weekDate != value)
                {
                    _weekDate = value;
                    PropertyHasChanged("WEEKDATE");
                }
            }
        }
        public string WEEKDATESCHED
        {
            get { return _week_Date_Sched; }
            set
            {
                if (_week_Date_Sched != value)
                {
                    _week_Date_Sched = value;
                    PropertyHasChanged("WEEKDATESCHED");
                }
            }
        }
        public string DATE_CHECKED
        {
            get { return _date_checked; }
            set
            {
                if (_date_checked != value)
                {
                    _date_checked = value;
                    PropertyHasChanged("DATE_CHECKED");
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
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_CHECK_FLG", "DT_CHECK_FLG"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_QUESTIONS", "AUDIT_QUESTIONS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OWNER", "OWNER"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_QUESTIONS_GROUP", "AUDIT_QUESTIONS_GROUP"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDITSCHED_MONTH", "AUDITSCHED_MONTH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NICKNAME", "NICKNAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEKDAYS", "WEEKDAYS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEKDATE", "WEEKDATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEKDATESCHED", "WEEKDATESCHED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_CHECKED", "DATE_CHECKED"));
        }
        #endregion

    }
  
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////