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
            EMP_ID,
            INC_ID,
            TASK_TYPE,
            PROJ_ID,
            INC_DESCR,
            TASK_DESCR,
            DATE_STARTED,
            TARGET_DATE,
            COMPLTD_DATE,
            DATE_CREATED,
            HOURSWORKED_DATE,
            STATUS,
            REMARKS,
            EFFORT_EST,
            ACT_EFFORT_EST,
            ACT_EFFORT_EST_WK,
            PROJECT_CODE,
            REWORK,
            PHASE,
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

        int _tASK_ID;
        int _eMP_ID;
        string _iNC_ID;
        byte _tASK_TYPE;
        int _pROJ_ID;
        string _iNC_DESCR;
        string _tASK_DESCR;
        DateTime _dATE_STARTED;
        DateTime _tARGET_DATE;
        DateTime _cOMPLTD_DATE;
        DateTime _dATE_CREATED;
        DateTime _hOURSWORKED_DATE;
        byte _sTATUS;
        string _rEMARKS;
        double _eFFORT_EST;
        double _aCT_EFFORT_EST;
        double _aCT_EFFORT_EST_WK;
        int _pROJECT_CODE;
        short _rEWORK;
        int _pHASE;
        string _oTHERS_1;
        string _oTHERS_2;
        string _oTHERS_3;

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
			 get { return _tASK_ID; }
			 set
			 {
				 if (_tASK_ID != value)
				 {
					_tASK_ID = value;
					 PropertyHasChanged("TASK_ID");
				 }
			 }
		}

		public int  EMP_ID
		{
			 get { return _eMP_ID; }
			 set
			 {
				 if (_eMP_ID != value)
				 {
					_eMP_ID = value;
					 PropertyHasChanged("EMP_ID");
				 }
			 }
		}

		public string  INC_ID
		{
			 get { return _iNC_ID; }
			 set
			 {
				 if (_iNC_ID != value)
				 {
					_iNC_ID = value;
					 PropertyHasChanged("INC_ID");
				 }
			 }
		}

		public byte  TASK_TYPE
		{
			 get { return _tASK_TYPE; }
			 set
			 {
				 if (_tASK_TYPE != value)
				 {
					_tASK_TYPE = value;
					 PropertyHasChanged("TASK_TYPE");
				 }
			 }
		}

		public int  PROJ_ID
		{
			 get { return _pROJ_ID; }
			 set
			 {
				 if (_pROJ_ID != value)
				 {
					_pROJ_ID = value;
					 PropertyHasChanged("PROJ_ID");
				 }
			 }
		}

		public string  INC_DESCR
		{
			 get { return _iNC_DESCR; }
			 set
			 {
				 if (_iNC_DESCR != value)
				 {
					_iNC_DESCR = value;
					 PropertyHasChanged("INC_DESCR");
				 }
			 }
		}

		public string  TASK_DESCR
		{
			 get { return _tASK_DESCR; }
			 set
			 {
				 if (_tASK_DESCR != value)
				 {
					_tASK_DESCR = value;
					 PropertyHasChanged("TASK_DESCR");
				 }
			 }
		}

		public DateTime DATE_STARTED
		{
			 get { return _dATE_STARTED; }
			 set
			 {
				 if (_dATE_STARTED != value)
				 {
					_dATE_STARTED = value;
					 PropertyHasChanged("DATE_STARTED");
				 }
			 }
		}

		public DateTime TARGET_DATE
		{
			 get { return _tARGET_DATE; }
			 set
			 {
				 if (_tARGET_DATE != value)
				 {
					_tARGET_DATE = value;
					 PropertyHasChanged("TARGET_DATE");
				 }
			 }
		}

		public DateTime COMPLTD_DATE
		{
			 get { return _cOMPLTD_DATE; }
			 set
			 {
				 if (_cOMPLTD_DATE != value)
				 {
					_cOMPLTD_DATE = value;
					 PropertyHasChanged("COMPLTD_DATE");
				 }
			 }
		}

		public DateTime  DATE_CREATED
		{
			 get { return _dATE_CREATED; }
			 set
			 {
				 if (_dATE_CREATED != value)
				 {
					_dATE_CREATED = value;
					 PropertyHasChanged("DATE_CREATED");
				 }
			 }
		}

        public DateTime HOURSWORKED_DATE
        {
            get { return _hOURSWORKED_DATE; }
            set
            {
                if (_hOURSWORKED_DATE != value)
                {
                    _hOURSWORKED_DATE = value;
                    PropertyHasChanged("HOURSWORKED_DATE");
                }
            }
        }
        public byte  STATUS
		{
			 get { return _sTATUS; }
			 set
			 {
				 if (_sTATUS != value)
				 {
					_sTATUS = value;
					 PropertyHasChanged("STATUS");
				 }
			 }
		}

		public string  REMARKS
		{
			 get { return _rEMARKS; }
			 set
			 {
				 if (_rEMARKS != value)
				 {
					_rEMARKS = value;
					 PropertyHasChanged("REMARKS");
				 }
			 }
		}

		public double  EFFORT_EST
		{
			 get { return _eFFORT_EST; }
			 set
			 {
				 if (_eFFORT_EST != value)
				 {
					_eFFORT_EST = value;
					 PropertyHasChanged("EFFORT_EST");
				 }
			 }
		}

		public double  ACT_EFFORT_EST
		{
			 get { return _aCT_EFFORT_EST; }
			 set
			 {
				 if (_aCT_EFFORT_EST != value)
				 {
					_aCT_EFFORT_EST = value;
					 PropertyHasChanged("ACT_EFFORT_EST");
				 }
			 }
		}

		public double  ACT_EFFORT_EST_WK
		{
			 get { return _aCT_EFFORT_EST_WK; }
			 set
			 {
				 if (_aCT_EFFORT_EST_WK != value)
				 {
					_aCT_EFFORT_EST_WK = value;
					 PropertyHasChanged("ACT_EFFORT_EST_WK");
				 }
			 }
		}

		public int  PROJECT_CODE
		{
			 get { return _pROJECT_CODE; }
			 set
			 {
				 if (_pROJECT_CODE != value)
				 {
					_pROJECT_CODE = value;
					 PropertyHasChanged("PROJECT_CODE");
				 }
			 }
		}

		public short  REWORK
		{
			 get { return _rEWORK; }
			 set
			 {
				 if (_rEWORK != value)
				 {
					_rEWORK = value;
					 PropertyHasChanged("REWORK");
				 }
			 }
		}

		public int  PHASE
		{
			 get { return _pHASE; }
			 set
			 {
				 if (_pHASE != value)
				 {
					_pHASE = value;
					 PropertyHasChanged("PHASE");
				 }
			 }
		}

		public string  OTHERS_1
		{
			 get { return _oTHERS_1; }
			 set
			 {
				 if (_oTHERS_1 != value)
				 {
					_oTHERS_1 = value;
					 PropertyHasChanged("OTHERS_1");
				 }
			 }
		}

		public string  OTHERS_2
		{
			 get { return _oTHERS_2; }
			 set
			 {
				 if (_oTHERS_2 != value)
				 {
					_oTHERS_2 = value;
					 PropertyHasChanged("OTHERS_2");
				 }
			 }
		}

		public string  OTHERS_3
		{
			 get { return _oTHERS_3; }
			 set
			 {
				 if (_oTHERS_3 != value)
				 {
					_oTHERS_3 = value;
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
