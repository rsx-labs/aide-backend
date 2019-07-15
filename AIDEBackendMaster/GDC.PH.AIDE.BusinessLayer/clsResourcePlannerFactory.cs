using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/// <summary>
/// By Jhunell G. Barcenas
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsResourcePlannerFactory
    {

        #region data Members

        clsResourcePlannerSql _dataObject = null;

        #endregion

        #region Constructor

        public clsResourcePlannerFactory()
        {
            _dataObject = new clsResourcePlannerSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsAttendance
        /// </summary>
        /// <param name="businessObject">clsAttendance object</param>
        /// <returns>true for successfully saved</returns>

        public bool InsertResourcePlanner(clsResourcePlanner businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertResourcePlanner(businessObject);
        }

        /// <summary>
        /// Update existing clsAttendance
        /// </summary>
        /// <param name="businessObject">clsAttendance object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateResourcePlanner(clsResourcePlanner businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }
            return _dataObject.UpdateResourcePlanner(businessObject);
        }

        public List<clsResourcePlanner> ViewEmpResourcePlanner(string email)
        {
            return _dataObject.ViewEmpResourcePlanner(email);
        }

        public List<clsResourcePlanner> GetStatusResourcePlanner()
        {
            return _dataObject.GetStatusResourcePlanner();
        }

        public List<clsResourcePlanner> GetResourcePlannerByEmpID(int empID, int deptID, int month, int year)
        {
            return _dataObject.GetResourcePlannerByEmpID(empID, deptID, month, year);
        }

        public List<clsResourcePlanner> GetAllEmpResourcePlanner(string email, int month, int year)
        {
            return _dataObject.GetAllEmpResourcePlanner(email, month, year);
        }

        public List<clsResourcePlanner> GetAllEmpResourcePlannerByStatus(string email, int month, int year, int status)
        {
            return _dataObject.GetAllEmpResourcePlannerByStatus(email, month, year, status);
        }

        public List<clsResourcePlanner> GetAllStatusResourcePlanner()
        {
            return _dataObject.GetAllStatusResourcePlanner();
        }

        public List<clsResourcePlanner> GetResourcePlanner(string email, int status, int toBeDisplayed, int year)
        {
            return _dataObject.GetResourcePlanner(email, status, toBeDisplayed, year);
        }

        public List<clsResourcePlanner> GetBillableHoursByMonth(int empID, int month, int year)
        {
            return _dataObject.GetBillableHoursByMonth(empID, month, year);
        }

        public List<clsResourcePlanner> GetBillableHoursByWeek(int empID, int weekID)
        {
            return _dataObject.GetBillableHoursByWeek(empID, weekID);
        }

        public List<clsResourcePlanner> GetNonBillableHours(string email, int display, int month, int year)
        {
            return _dataObject.GetNonBillableHours(email, display, month, year);
        }

        #endregion
    }
}
