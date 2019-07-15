using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsWeeklyReport: BusinessObjectBase
	{

        #region InnerClass
        public enum clsWeeklyReportFields
        {
            WR_ID,
            WR_WEEK_RANGE_ID,
            WR_PROJ_ID,
            WR_REWORK,
            WR_REF_ID,
            WR_SUBJECT,
            WR_SEVERITY,
            WR_INC_TYPE,
            WR_EMP_ID,
            WR_PHASE,
            WR_STATUS,
            WR_DATE_STARTED,
            WR_DATE_TARGET,
            WR_DATE_FINISHED,
            WR_DATE_CREATED,
            WR_EFFORT_EST,
            WR_ACT_EFFORT_WK,
            WR_ACT_EFFORT,
            WR_COMMENTS,
            WR_INBOUND_CONTACTS
        }
        #endregion

        #region Data Members

        int _wk_ID;
        int _wk_range_ID;
        int _proj_ID;
        short _rework;
        string _ref_ID;
        string _subject;
        short _severity;
        short _inc_type;
        int _emp_ID;
        short _phase;
        short _status;
        DateTime _date_started;
        DateTime _date_target;
        DateTime _date_finished;
        double _effort_est;
        double _act_effort;
        double _act_effort_wk;
        string _comments;
        short _inbound_contacts;

        #endregion

		#region Properties

        public int WR_ID
        {
            get { return _wk_ID; }
            set
            {
                if (_wk_ID != value)
                {
                    _wk_ID = value;
                    PropertyHasChanged("WR_ID");
                }
            }
        }

        public int WR_WEEK_RANGE_ID
		{
            get { return _wk_range_ID; }
			 set
			 {
                 if (_wk_range_ID != value)
				 {
                     _wk_range_ID = value;
                     PropertyHasChanged("WR_WEEK_RANGE_ID");
				 }
			 }
		}

        public int WR_PROJ_ID
        {
            get { return _proj_ID; }
            set
            {
                if (_proj_ID != value)
                {
                    _proj_ID = value;
                    PropertyHasChanged("WR_PROJ_ID");
                }
            }
        }

        public short WR_REWORK
        {
            get { return _rework; }
            set
            {
                if (_rework != value)
                {
                    _rework = value;
                    PropertyHasChanged("WR_REWORK");
                }
            }
        }

        public string WR_REF_ID
        {
            get { return _ref_ID; }
            set
            {
                if (_ref_ID != value)
                {
                    _ref_ID = value;
                    PropertyHasChanged("WR_REF_ID");
                }
            }
        }

        public string WR_SUBJECT
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    PropertyHasChanged("WR_SUBJECT");
                }
            }
        }

        public short WR_SEVERITY
        {
            get { return _severity; }
            set
            {
                if (_severity != value)
                {
                    _severity = value;
                    PropertyHasChanged("WR_SEVERITY");
                }
            }
        }

        public short WR_INC_TYPE
        {
            get { return _inc_type; }
            set
            {
                if (_inc_type != value)
                {
                    _inc_type = value;
                    PropertyHasChanged("WR_INC_TYPE");
                }
            }
        }

        public int WR_EMP_ID
        {
            get { return _emp_ID; }
            set
            {
                if (_emp_ID != value)
                {
                    _emp_ID = value;
                    PropertyHasChanged("WR_EMP_ID");
                }
            }
        }

        public short WR_PHASE
        {
            get { return _phase; }
            set
            {
                if (_phase != value)
                {
                    _phase = value;
                    PropertyHasChanged("WR_PHASE");
                }
            }
        }

        public short WR_STATUS
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("WR_STATUS");
                }
            }
        }

        public DateTime WR_DATE_STARTED
		{
			 get { return _date_started; }
			 set
			 {
                 if (_date_started != value)
				 {
                     _date_started = value;
                     PropertyHasChanged("WR_DATE_STARTED");
				 }
			 }
		}

        public DateTime WR_DATE_TARGET
		{
			 get { return _date_target; }
			 set
			 {
                 if (_date_target != value)
				 {
                     _date_target = value;
                     PropertyHasChanged("WR_DATE_TARGET");
				 }
			 }
		}

        public DateTime WR_DATE_FINISHED
		{
			 get { return _date_finished; }
			 set
			 {
                 if (_date_finished != value)
				 {
                     _date_finished = value;
                     PropertyHasChanged("WR_DATE_FINISHED");
				 }
			 }
		}

        public double WR_EFFORT_EST
		{
			 get { return _effort_est; }
			 set
			 {
                 if (_effort_est != value)
				 {
                     _effort_est = value;
                     PropertyHasChanged("WR_EFFORT_EST");
				 }
			 }
		}

        public double WR_ACT_EFFORT_WK
		{
			 get { return _act_effort_wk; }
			 set
			 {
                 if (_act_effort_wk != value)
				 {
                     _act_effort_wk = value;
                     PropertyHasChanged("WR_ACT_EFFORT_WK");
				 }
			 }
		}

        public double WR_ACT_EFFORT
		{
			 get { return _act_effort; }
			 set
			 {
                 if (_act_effort != value)
				 {
                     _act_effort = value;
                     PropertyHasChanged("WR_ACT_EFFORT");
				 }
			 }
		}

        public string WR_COMMENTS
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    PropertyHasChanged("WR_COMMENTS");
                }
            }
        }

        public short WR_INBOUND_CONTACTS
		{
			 get { return _inbound_contacts; }
			 set
			 {
                 if (_inbound_contacts != value)
				 {
                     _inbound_contacts = value;
                     PropertyHasChanged("WR_INBOUND_CONTACTS");
				 }
			 }
		}

		#endregion

        //#region Validation

        //internal override void AddValidationRules()
        //{
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TASK_ID", "TASK_ID"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("INC_ID", "INC_ID",8));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TASK_TYPE", "TASK_TYPE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJ_ID", "PROJ_ID"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("INC_DESCR", "INC_DESCR",30));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TASK_DESCR", "TASK_DESCR",50));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_STARTED", "DATE_STARTED"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TARGET_DATE", "TARGET_DATE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("COMPLTD_DATE", "COMPLTD_DATE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_CREATED", "DATE_CREATED"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("REMARKS", "REMARKS"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("REMARKS", "REMARKS",200));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EFFORT_EST", "EFFORT_EST"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ACT_EFFORT_EST", "ACT_EFFORT_EST"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ACT_EFFORT_EST_WK", "ACT_EFFORT_EST_WK"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJECT_CODE", "PROJECT_CODE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("REWORK", "REWORK"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PHASE", "PHASE"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PHASE", "PHASE",20));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OTHERS_1", "OTHERS_1"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHERS_1", "OTHERS_1",100));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OTHERS_2", "OTHERS_2"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHERS_2", "OTHERS_2",100));
        //    ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OTHERS_3", "OTHERS_3"));
        //    ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHERS_3", "OTHERS_3",100));
        //}

        //#endregion

	}
}
