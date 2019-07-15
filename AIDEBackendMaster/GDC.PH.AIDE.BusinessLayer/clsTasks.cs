using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsTasks: BusinessObjectBase
	{

        #region InnerClass
        public enum clsTASKSFields
        {
            TASK_ID,
            PROJ_ID,
            PROJECT_CODE,
            REWORK,
            REF_ID,
            INC_DESCR,
            SEVERITY,
            INC_TYPE,
            EMP_ID,
            PHASE,
            STATUS,
            DATE_STARTED,
            TARGET_DATE,
            COMPLTD_DATE,
            DATE_CREATED,
            EFFORT_EST,
            ACT_EFFORT,
            ACT_EFFORT_WK,
            COMMENTS,
            OTHERS_1,
            OTHERS_2,
            OTHERS_3
        }

        public enum clsTasks_spFields
        {
            EmployeeName,
            LastWeekOutstanding,
            Mon_AT,
            Mon_CT,
            Mon_OT,
            Tue_AT,
            Tue_CT,
            Tue_OT,
            Wed_AT,
            Wed_CT,
            Wed_OT,
            Thu_AT,
            Thu_CT,
            Thu_OT,
            Fri_AT,
            Fri_CT,
            Fri_OT
        }

        #endregion

        #region Data Members

        int _task_ID;
        int _proj_ID;
        int _project_code;
        short _rework;
        string _ref_ID;
        string _inc_descr;
        short _severity;
        short _inc_type;
        int _emp_ID;
        short _phase;
        short _status;
        DateTime _date_started;
        DateTime _target_date;
        DateTime _compltd_date;
        DateTime _date_created;
        double _effort_est;
        double _act_effort;
        double _act_effort_wk;
        string _comments;

        string _others_1;
        string _others_2;
        string _others_3;

        string _employeeName;
        int _lastWeekOutstanding;
        int _mon_AT;
        int _mon_CT;
        int _mon_OT;
        int _tue_AT;
        int _tue_CT;
        int _tue_OT;
        int _wed_AT;
        int _wed_CT;
        int _wed_OT;
        int _thu_AT;
        int _thu_CT;
        int _thu_OT;
        int _fri_AT;
        int _fri_CT;
        int _fri_OT;

        #endregion

		#region Properties

		public int TASK_ID
		{
			 get { return _task_ID; }
			 set
			 {
                 if (_task_ID != value)
				 {
                     _task_ID = value;
					 PropertyHasChanged("TASK_ID");
				 }
			 }
		}

        public int PROJ_ID
        {
            get { return _proj_ID; }
            set
            {
                if (_proj_ID != value)
                {
                    _proj_ID = value;
                    PropertyHasChanged("PROJ_ID");
                }
            }
        }

        public int PROJECT_CODE
        {
            get { return _project_code; }
            set
            {
                if (_project_code != value)
                {
                    _project_code = value;
                    PropertyHasChanged("PROJECT_CODE");
                }
            }
        }

        public short REWORK
        {
            get { return _rework; }
            set
            {
                if (_rework != value)
                {
                    _rework = value;
                    PropertyHasChanged("REWORK");
                }
            }
        }

        public string REF_ID
        {
            get { return _ref_ID; }
            set
            {
                if (_ref_ID != value)
                {
                    _ref_ID = value;
                    PropertyHasChanged("REF_ID");
                }
            }
        }

        public string INC_DESCR
        {
            get { return _inc_descr; }
            set
            {
                if (_inc_descr != value)
                {
                    _inc_descr = value;
                    PropertyHasChanged("INC_DESCR");
                }
            }
        }

        public short SEVERITY
        {
            get { return _severity; }
            set
            {
                if (_severity != value)
                {
                    _severity = value;
                    PropertyHasChanged("SEVERITY");
                }
            }
        }

        public short INC_TYPE
        {
            get { return _inc_type; }
            set
            {
                if (_inc_type != value)
                {
                    _inc_type = value;
                    PropertyHasChanged("INC_TYPE");
                }
            }
        }

		public int EMP_ID
		{
			 get { return _emp_ID; }
			 set
			 {
                 if (_emp_ID != value)
				 {
                     _emp_ID = value;
					 PropertyHasChanged("EMP_ID");
				 }
			 }
		}

        public short PHASE
        {
            get { return _phase; }
            set
            {
                if (_phase != value)
                {
                    _phase = value;
                    PropertyHasChanged("PHASE");
                }
            }
        }

        public short STATUS
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
		
		public DateTime DATE_STARTED
		{
			 get { return _date_started; }
			 set
			 {
                 if (_date_started != value)
				 {
                     _date_started = value;
					 PropertyHasChanged("DATE_STARTED");
				 }
			 }
		}

		public DateTime TARGET_DATE
		{
			 get { return _target_date; }
			 set
			 {
                 if (_target_date != value)
				 {
                     _target_date = value;
					 PropertyHasChanged("TARGET_DATE");
				 }
			 }
		}

		public DateTime COMPLTD_DATE
		{
			 get { return _compltd_date; }
			 set
			 {
                 if (_compltd_date != value)
				 {
                     _compltd_date = value;
					 PropertyHasChanged("COMPLTD_DATE");
				 }
			 }
		}

		public DateTime  DATE_CREATED
		{
			 get { return _date_created; }
			 set
			 {
                 if (_date_created != value)
				 {
                     _date_created = value;
					 PropertyHasChanged("DATE_CREATED");
				 }
			 }
		}

		public double EFFORT_EST
		{
			 get { return _effort_est; }
			 set
			 {
                 if (_effort_est != value)
				 {
                     _effort_est = value;
					 PropertyHasChanged("EFFORT_EST");
				 }
			 }
		}

		public double  ACT_EFFORT
		{
			 get { return _act_effort; }
			 set
			 {
                 if (_act_effort != value)
				 {
                     _act_effort = value;
					 PropertyHasChanged("ACT_EFFORT");
				 }
			 }
		}

		public double  ACT_EFFORT_WK
		{
			 get { return _act_effort_wk; }
			 set
			 {
                 if (_act_effort_wk != value)
				 {
                     _act_effort_wk = value;
					 PropertyHasChanged("ACT_EFFORT_WK");
				 }
			 }
		}

        public string COMMENTS
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    PropertyHasChanged("COMMENTS");
                }
            }
        }

		public string  OTHERS_1
		{
			 get { return _others_1; }
			 set
			 {
                 if (_others_1 != value)
				 {
                     _others_1 = value;
					 PropertyHasChanged("OTHERS_1");
				 }
			 }
		}

		public string  OTHERS_2
		{
			 get { return _others_2; }
			 set
			 {
                 if (_others_2 != value)
				 {
                     _others_2 = value;
					 PropertyHasChanged("OTHERS_2");
				 }
			 }
		}

		public string  OTHERS_3
		{
			 get { return _others_3; }
			 set
			 {
                 if (_others_3 != value)
				 {
                     _others_3 = value;
					 PropertyHasChanged("OTHERS_3");
				 }
			 }
		}

        #region StoredProcSetters&Getters

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    PropertyHasChanged("EmployeeName");
                }
            }
        }

        public int LastWeekOutstanding
        {
            get { return _lastWeekOutstanding; }
            set
            {
                if (_lastWeekOutstanding != value)
                {
                    _lastWeekOutstanding = value;
                    PropertyHasChanged("LastWeekOutstanding");
                }
            }
        }

        public int Mon_AT
        {
            get { return _mon_AT; }
            set
            {
                if (_mon_AT != value)
                {
                    _mon_AT = value;
                    PropertyHasChanged("Mon_AT");
                }
            }
        }

        public int Mon_CT
        {
            get { return _mon_CT; }
            set
            {
                if (_mon_CT != value)
                {
                    _mon_CT = value;
                    PropertyHasChanged("Mon_CT");
                }
            }
        }

        public int Mon_OT
        {
            get { return _mon_OT; }
            set
            {
                if (_mon_OT != value)
                {
                    _mon_OT = value;
                    PropertyHasChanged("Mon_OT");
                }
            }
        }

        public int Tue_AT
        {
            get { return _tue_AT; }
            set
            {
                if (_tue_AT != value)
                {
                    _tue_AT = value;
                    PropertyHasChanged("Tue_AT");
                }
            }
        }

        public int Tue_CT
        {
            get { return _tue_CT; }
            set
            {
                if (_tue_CT != value)
                {
                    _tue_CT = value;
                    PropertyHasChanged("Tue_CT");
                }
            }
        }

        public int Tue_OT
        {
            get { return _tue_OT; }
            set
            {
                if (_tue_OT != value)
                {
                    _tue_OT = value;
                    PropertyHasChanged("Tue_OT");
                }
            }
        }

        public int Wed_AT
        {
            get { return _wed_AT; }
            set
            {
                if (_wed_AT != value)
                {
                    _wed_AT = value;
                    PropertyHasChanged("Wed_AT");
                }
            }
        }

        public int Wed_CT
        {
            get { return _wed_CT; }
            set
            {
                if (_wed_CT != value)
                {
                    _wed_CT = value;
                    PropertyHasChanged("Wed_CT");
                }
            }
        }

        public int Wed_OT
        {
            get { return _wed_OT; }
            set
            {
                if (_wed_OT != value)
                {
                    _wed_OT = value;
                    PropertyHasChanged("Wed_OT");
                }
            }
        }

        public int Thu_AT
        {
            get { return _thu_AT; }
            set
            {
                if (_thu_AT != value)
                {
                    _thu_AT = value;
                    PropertyHasChanged("Thu_AT");
                }
            }
        }

        public int Thu_CT
        {
            get { return _thu_CT; }
            set
            {
                if (_thu_CT != value)
                {
                    _thu_CT = value;
                    PropertyHasChanged("Thu_CT");
                }
            }
        }

        public int Thu_OT
        {
            get { return _thu_OT; }
            set
            {
                if (_thu_OT != value)
                {
                    _thu_OT = value;
                    PropertyHasChanged("Thu_OT");
                }
            }
        }

        public int Fri_AT
        {
            get { return _fri_AT; }
            set
            {
                if (_fri_AT != value)
                {
                    _fri_AT = value;
                    PropertyHasChanged("Fri_AT");
                }
            }
        }

        public int Fri_CT
        {
            get { return _fri_CT; }
            set
            {
                if (_fri_CT != value)
                {
                    _fri_CT = value;
                    PropertyHasChanged("Fri_CT");
                }
            }
        }

        public int Fri_OT
        {
            get { return _fri_OT; }
            set
            {
                if (_fri_OT != value)
                {
                    _fri_OT = value;
                    PropertyHasChanged("Fri_OT");
                }
            }
        }

        #endregion

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
