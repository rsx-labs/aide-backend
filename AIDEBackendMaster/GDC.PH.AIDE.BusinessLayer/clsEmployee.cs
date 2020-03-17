using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsEmployee: BusinessObjectBase
	{

		#region InnerClass
		public enum clsEmployeeFields
		{
			EMP_ID,
            EMPLOYEE_NAME,
			LAST_NAME,
			FIRST_NAME,
			MIDDLE_INITIAL,
			NICK_NAME,
			BIRTHDATE,
			POSITION,
			DATE_HIRED,
			STATUS,
			IMAGE_PATH,
			GRP_ID,
            EMAIL_ADDRESS,
            EMAIL_ADDRESS2,
            LOCATION,
            CEL_NO,
            LOCAL,
            HOMEPHONE,
            OTHER_PHONE,
            DT_REVIEWED,
			MANAGER_EMAIL
        }
		#endregion

		#region Data Members

			int _eMP_ID;
            string _EMPLOYEE_NAME;
			string _lAST_NAME;
			string _fIRST_NAME;
			string _mIDDLE_INITIAL;
			string _nICK_NAME;
			DateTime? _bIRTHDATE;
			byte _pOSITION;
			DateTime? _dATE_HIRED;
			byte _sTATUS;
			string _iMAGE_PATH;
			byte _gRP_ID;
        string _eMAIL_ADDRESS;
        string _eMAIL_ADDRESS2;
        string _lOCATION;
        string _cEL_NO;
        int _lOCAL;
        string _hOMEPHONE;
        string _oTHER_PHONE;
        DateTime? _dT_REVIEWED;
		string _managerEmail;

        #endregion

        #region Properties

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

        public string EMPLOYEE_NAME
        {
            get { return _EMPLOYEE_NAME; }
            set
            {
                if (_EMPLOYEE_NAME != value)
                {
                    _EMPLOYEE_NAME = value;
                    PropertyHasChanged("EMPLOYEE_NAME");
                }
            }
        }

		public string  LAST_NAME
		{
			 get { return _lAST_NAME; }
			 set
			 {
				 if (_lAST_NAME != value)
				 {
					_lAST_NAME = value;
					 PropertyHasChanged("LAST_NAME");
				 }
			 }
		}

		public string  FIRST_NAME
		{
			 get { return _fIRST_NAME; }
			 set
			 {
				 if (_fIRST_NAME != value)
				 {
					_fIRST_NAME = value;
					 PropertyHasChanged("FIRST_NAME");
				 }
			 }
		}

		public string  MIDDLE_INITIAL
		{
			 get { return _mIDDLE_INITIAL; }
			 set
			 {
				 if (_mIDDLE_INITIAL != value)
				 {
					_mIDDLE_INITIAL = value;
					 PropertyHasChanged("MIDDLE_INITIAL");
				 }
			 }
		}

		public string  NICK_NAME
		{
			 get { return _nICK_NAME; }
			 set
			 {
				 if (_nICK_NAME != value)
				 {
					_nICK_NAME = value;
					 PropertyHasChanged("NICK_NAME");
				 }
			 }
		}

		public DateTime?  BIRTHDATE
		{
			 get { return _bIRTHDATE; }
			 set
			 {
				 if (_bIRTHDATE != value)
				 {
					_bIRTHDATE = value;
					 PropertyHasChanged("BIRTHDATE");
				 }
			 }
		}

		public byte  POSITION
		{
			 get { return _pOSITION; }
			 set
			 {
				 if (_pOSITION != value)
				 {
					_pOSITION = value;
					 PropertyHasChanged("POSITION");
				 }
			 }
		}

		public DateTime?  DATE_HIRED
		{
			 get { return _dATE_HIRED; }
			 set
			 {
				 if (_dATE_HIRED != value)
				 {
					_dATE_HIRED = value;
					 PropertyHasChanged("DATE_HIRED");
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

		public string  IMAGE_PATH
		{
			 get { return _iMAGE_PATH; }
			 set
			 {
				 if (_iMAGE_PATH != value)
				 {
					_iMAGE_PATH = value;
					 PropertyHasChanged("IMAGE_PATH");
				 }
			 }
		}

		public byte  GRP_ID
		{
			 get { return _gRP_ID; }
			 set
			 {
				 if (_gRP_ID != value)
				 {
					_gRP_ID = value;
					 PropertyHasChanged("GRP_ID");
				 }
			 }
		}

        public string EMAIL_ADDRESS
        {
            get { return _eMAIL_ADDRESS; }
            set
            {
                if (_eMAIL_ADDRESS != value)
                {
                    _eMAIL_ADDRESS = value;
                    PropertyHasChanged("EMAIL_ADDRESS");
                }
            }
        }

        public string EMAIL_ADDRESS2
        {
            get { return _eMAIL_ADDRESS2; }
            set
            {
                if (_eMAIL_ADDRESS2 != value)
                {
                    _eMAIL_ADDRESS2 = value;
                    PropertyHasChanged("EMAIL_ADDRESS2");
                }
            }
        }

        public string LOCATION
        {
            get { return _lOCATION; }
            set
            {
                if (_lOCATION != value)
                {
                    _lOCATION = value;
                    PropertyHasChanged("LOCATION");
                }
            }
        }

        public string CEL_NO
        {
            get { return _cEL_NO; }
            set
            {
                if (_cEL_NO != value)
                {
                    _cEL_NO = value;
                    PropertyHasChanged("CEL_NO");
                }
            }
        }

        public int LOCAL
        {
            get { return _lOCAL; }
            set
            {
                if (_lOCAL != value)
                {
                    _lOCAL = value;
                    PropertyHasChanged("LOCAL");
                }
            }
        }

        public string HOMEPHONE
        {
            get { return _hOMEPHONE; }
            set
            {
                if (_hOMEPHONE != value)
                {
                    _hOMEPHONE = value;
                    PropertyHasChanged("HOMEPHONE");
                }
            }
        }

        public string OTHER_PHONE
        {
            get { return _oTHER_PHONE; }
            set
            {
                if (_oTHER_PHONE != value)
                {
                    _oTHER_PHONE = value;
                    PropertyHasChanged("OTHER_PHONE");
                }
            }
        }

        public DateTime? DT_REVIEWED
        {
            get { return _dT_REVIEWED; }
            set
            {
                if (_dT_REVIEWED != value)
                {
                    _dT_REVIEWED = value;
                    PropertyHasChanged("DT_REVIEWED");
                }
            }
        }

		public string MANAGER_EMAIL
		{
			get { return _managerEmail; }
			set
			{
				if (_managerEmail != value)
				{
					_managerEmail = value;
					PropertyHasChanged("MANAGER_EMAIL");
				}
			}
		}
		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPLOYEE_NAME", "EMPLOYEE_NAME"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LAST_NAME", "LAST_NAME"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LAST_NAME", "LAST_NAME",20));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FIRST_NAME", "FIRST_NAME"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FIRST_NAME", "FIRST_NAME",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("MIDDLE_INITIAL", "MIDDLE_INITIAL",10));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NICK_NAME", "NICK_NAME",10));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POSITION", "POSITION"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("POSITION", "POSITION",20));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
			//ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE_PATH", "IMAGE_PATH",50));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("GRP_ID", "GRP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMAIL_ADDRESS", "EMAIL_ADDRESS"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EMAIL_ADDRESS", "EMAIL_ADDRESS", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMAIL_ADDRESS2", "EMAIL_ADDRESS2"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EMAIL_ADDRESS2", "EMAIL_ADDRESS2", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCATION", "LOCATION"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LOCATION", "LOCATION", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CEL_NO", "CEL_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CEL_NO", "CEL_NO", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCAL", "LOCAL"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("HOMEPHONE", "HOMEPHONE"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("HOMEPHONE", "HOMEPHONE", 10));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("OTHER_PHONE", "OTHER_PHONE"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHER_PHONE", "OTHER_PHONE", 15));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DT_REVIEWED", "DT_REVIEWED"));
        }

		#endregion

	}
}
