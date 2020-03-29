using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProblem : BusinessObjectBase
    {
		#region InnerClass
		public enum clsProblemFields
		{
			EMP_ID,
			EMPLOYEE_NAME,
			PROBLEM_ID,
			PROBLEM_DESCR,
			PROBLEM_INVOLVE,
			CAUSE_ID,
			CAUSE_DESCR,
			CAUSE_WHY,
			OPTION_ID,
			OPTION_DESCR,
			SOLUTION_ID,
			SOLUTION_DESCR,
			IMPLEMENT_ID,
			IMPLEMENT_DESCR,
			IMPLEMENT_ASSIGNEE,
			IMPLEMENT_VALUE,
			RESULT_ID,
			RESULT_DESCR,
			RESULT_VALUE
		}
		#endregion
		#region Data Members

		int _empID;
		string _empName;
		int _problemID;
		string _problemDescr;
		string _problemInvolve;
		int _causeID;
		string _causeDescr;
		string _causeWhy;
		int _optionID;
		string _optionDescr;
		int _solutionID;
		string _solutionDescr;
		int _implementID;
		string _implementDescr;
		int _implementAssignee;
		string _implementValue;
		int _resultID;
		string _resultDescr;
		string _resultValue;

		#endregion

		#region Properties

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

		public string EMPLOYEE_NAME
		{
			get { return _empName; }
			set
			{
				if (_empName != value)
				{
					_empName = value;
					PropertyHasChanged("EMPLOYEE_NAME");
				}
			}
		}

		public int PROBLEM_ID
		{
			get { return _problemID; }
			set
			{
				if (_problemID != value)
				{
					_problemID = value;
					PropertyHasChanged("PROBLEM_ID");
				}
			}
		}

		public string PROBLEM_DESCR
		{
			get { return _problemDescr; }
			set
			{
				if (_problemDescr != value)
				{
					_problemDescr = value;
					PropertyHasChanged("PROBLEM_DESCR");
				}
			}
		}

		public string PROBLEM_INVOLVE
		{
			get { return _problemInvolve; }
			set
			{
				if (_problemInvolve != value)
				{
					_problemInvolve = value;
					PropertyHasChanged("PROBLEM_DESCR");
				}
			}
		}

		public int CAUSE_ID
		{
			get { return _causeID; }
			set
			{
				if (_causeID != value)
				{
					_causeID = value;
					PropertyHasChanged("CAUSE_ID");
				}
			}
		}
		public string CAUSE_DESCR
		{
			get { return _causeDescr; }
			set
			{
				if (_causeDescr != value)
				{
					_causeDescr = value;
					PropertyHasChanged("CAUSE_DESCR");
				}
			}
		}
		public string CAUSE_WHY
		{
			get { return _causeWhy; }
			set
			{
				if (_causeWhy != value)
				{
					_causeWhy = value;
					PropertyHasChanged("CAUSE_WHY");
				}
			}
		}

		public int OPTION_ID
		{
			get { return _optionID; }
			set
			{
				if (_optionID != value)
				{
					_optionID = value;
					PropertyHasChanged("OPTION_ID");
				}
			}
		}
		public string OPTION_DESCR
		{
			get { return _optionDescr; }
			set
			{
				if (_optionDescr != value)
				{
					_optionDescr = value;
					PropertyHasChanged("OPTION_DESCR");
				}
			}
		}
		public int SOLUTION_ID
		{
			get { return _solutionID; }
			set
			{
				if (_solutionID != value)
				{
					_solutionID = value;
					PropertyHasChanged("SOLUTION_ID");
				}
			}
		}
		public string SOLUTION_DESCR
		{
			get { return _solutionDescr; }
			set
			{
				if (_solutionDescr != value)
				{
					_solutionDescr = value;
					PropertyHasChanged("SOLUTION_DESCR");
				}
			}
		}
		public int IMPLEMENT_ID
		{
			get { return _implementID; }
			set
			{
				if (_implementID != value)
				{
					_implementID = value;
					PropertyHasChanged("IMPLEMENT_ID");
				}
			}
		}
		public string IMPLEMENT_DESCR
		{
			get { return _implementDescr; }
			set
			{
				if (_implementDescr != value)
				{
					_implementDescr = value;
					PropertyHasChanged("IMPLEMENT_DESCR");
				}
			}
		}

		public int IMPLEMENT_ASSIGNEE
		{
			get { return _implementAssignee; }
			set
			{
				if (_implementAssignee != value)
				{
					_implementAssignee = value;
					PropertyHasChanged("IMPLEMENT_ASSIGNEE");
				}
			}
		}
		public string IMPLEMENT_VALUE
		{
			get { return _implementValue; }
			set
			{
				if (_implementValue != value)
				{
					_implementValue = value;
					PropertyHasChanged("IMPLEMENT_VALUE");
				}
			}
		}

		public int RESULT_ID
		{
			get { return _resultID; }
			set
			{
				if (_resultID != value)
				{
					_resultID = value;
					PropertyHasChanged("RESULT_ID");
				}
			}
		}
		public string RESULT_DESCR
		{
			get { return _resultDescr; }
			set
			{
				if (_resultDescr != value)
				{
					_resultDescr = value;
					PropertyHasChanged("RESULT_DESCR");
				}
			}
		}
		public string RESULT_VALUE
		{
			get { return _resultValue; }
			set
			{
				if (_resultValue != value)
				{
					_resultValue = value;
					PropertyHasChanged("RESULT_VALUE");
				}
			}
		}
		#endregion
		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
		}
	}
}
