using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProblemFactory
    {
        #region data Members

        clsProblemSql _dataObject = null;

        #endregion

        #region Constructor

        public clsProblemFactory()
        {
            _dataObject = new clsProblemSql();
        }

        #endregion

        #region Public Methods - Problems

        public bool InsertProblem(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblem(businessObject);

        }

        public bool UpdateProblem(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateProblem(businessObject);
        }

        public List<clsProblem> GetAllProblems(int empID)
        {
            return _dataObject.GetAllProblems(empID);
        }
        #endregion

        #region Public Methods - Problem Cause
        public bool InsertProblemCause(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblemCause(businessObject);

        }
        public bool UpdateProblemCause(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateProblemCause(businessObject);
        }
        public List<clsProblem> GetAllProblemCause()
        {
            return _dataObject.GetAllProblemCause();
        }
        #endregion

        #region Public Methods - Problem Option
        public bool InsertProblemOption(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblemOption(businessObject);

        }
        public bool UpdateProblemOption(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateProblemOption(businessObject);
        }
        public List<clsProblem> GetAllProblemOption()
        {
            return _dataObject.GetAllProblemOption();
        }
        #endregion

        #region Public Methods - Problem Solution
        public bool InsertProblemSolution(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblemSolution(businessObject);

        }
        public bool UpdateProblemSolution(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateProblemSolution(businessObject);
        }
        public List<clsProblem> GetAllProblemSolution()
        {
            return _dataObject.GetAllProblemSolution();
        }
        #endregion

        #region Public Methods - Problem Implement
        public bool InsertProblemImplement(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblemImplement(businessObject);

        }
        public bool UpdateProblemImplement(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateProblemImplement(businessObject);
        }
        public List<clsProblem> GetAllProblemImplement()
        {
            return _dataObject.GetAllProblemImplement();
        }
        #endregion

        #region Public Methods - Problem Result
        public bool InsertProblemResult(clsProblem businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertProblemResult(businessObject);

        }
        public List<clsProblem> GetAllProblemResult(int problemID, int optionID)
        {
            return _dataObject.GetAllProblemResult(problemID, optionID);
        }
        #endregion
    }
}
