using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsWeeklyReportFactory
    {
        #region Data Members

        clsWeeklyReportSql _dataObject = null;

        #endregion

        #region Constructor

        public clsWeeklyReportFactory()
        {
            _dataObject = new clsWeeklyReportSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsWeeklyReport
        /// </summary>
        /// <param name="businessObject">clsWeeklyReport object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsWeeklyReport businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);
        }

        /// <summary>
        /// Update existing clsWeeklyReport
        /// </summary>
        /// <param name="businessObject">clsWeeklyReport object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsWeeklyReport businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// Delete existing clsWeeklyReport
        /// </summary>
        /// <param name="businessObject">clsWeeklyReport object</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsWeeklyReport businessObject, int weekID)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Delete(businessObject, weekID);
        }

        /// <summary>
        /// Insert week range
        /// </summary>
        /// <returns>true for successfully saved</returns>
        public bool InsertWeekRange(clsWeekRange businessObject)
        {
            return _dataObject.InsertWeekRange(businessObject);
        }

        /// <summary>
        /// Insert week range
        /// </summary>
        /// <returns>true for successfully saved</returns>
        public bool InsertWeeklyReportXref(clsWeekRange businessObject)
        {
            return _dataObject.InsertWeeklyReportXref(businessObject);
        }

        /// <summary>
        /// Insert week range
        /// </summary>
        /// <returns>true for successfully saved</returns>
        public bool UpdateWeeklyReportXref(clsWeekRange businessObject)
        {
            return _dataObject.UpdateWeeklyReportXref(businessObject);
        }

        #region STORED PROCS

        public List<clsWeekRange> GetWeekRange(DateTime currentDate, int weekID, int empID)
        {
            return _dataObject.GetWeekRange(currentDate, weekID, empID);
        }

        public List<clsWeekRange> GetWeekRangeByMonthYear(int empID, int month, int year)
        {
            return _dataObject.GetWeekRangeByMonthYear(empID, month, year);
        }

        public List<clsWeekRange> GetWeeklyReportsByEmpID(int empID, int month, int year)
        {
            return _dataObject.GetWeeklyReportsByEmpID(empID, month, year);
        }

        public List<clsWeeklyReport> GetWeeklyReportsByWeekRangeID(int weekRangeID, DateTime currentDate, int empID)
        {
            return _dataObject.GetWeeklyReportsByWeekRangeID(weekRangeID, currentDate, empID);
        }

        public List<clsWeeklyReport> GetTasksDataByEmpID(int weekRangeID, int empID)
        {
            return _dataObject.GetTasksDataByEmpID(weekRangeID, empID);
        }

        public List<clsWeeklyTeamStatusReport> GetWeeklyTeamStatusReport(int empID, int month, int year, int weekID, int entryType)
        {
            return _dataObject.GetWeeklyTeamStatusReport(empID, month, year, weekID, entryType);
        }

        #endregion

        /// <summary>
        /// get list of all clsWeeklyReport
        /// </summary>
        /// <returns>list</returns>
        public List<clsWeeklyReport> GetAll()
        {
            return _dataObject.SelectAll();
        }

        /// <summary>
        /// get list of clsWeeklyReport by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>

        public bool Delete(clsWeeklyReportKeys keys)
        {
            return _dataObject.Delete(keys);
        }

        #endregion

    }
}
