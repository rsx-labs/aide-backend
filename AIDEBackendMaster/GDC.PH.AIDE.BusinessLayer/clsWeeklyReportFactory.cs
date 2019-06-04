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
        /// Insert week range
        /// </summary>
        /// <param name="currentDate">DateTime object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertWeekRange(clsWeekRange businessObject)
        {
            return _dataObject.InsertWeekRange(businessObject);
        }

        #region STORED PROCS

        public List<clsWeekRange> GetWeekRange(DateTime currentDate, int empID)
        {
            return _dataObject.GetWeekRange(currentDate, empID);
        }

        public List<clsWeekRange> GetWeeklyReportsByEmpID(int empID)
        {
            return _dataObject.GetWeeklyReportsByEmpID(empID);
        }

        public List<clsWeeklyReport> GetWeeklyReportsByWeekRangeID(int weekRangeID, int empID)
        {
            return _dataObject.GetWeeklyReportsByWeekRangeID(weekRangeID, empID);
        }

        //public clsTasks getTaskDetailByTaskId(clsTasksKeys keys)
        //{
        //    return _dataObject.getTaskDetailByTaskId(keys);
        //}

        //public List<clsTasks_sp> getTaskSummaryAll(DateTime dateStart, string email)
        //{
        //    return _dataObject.getTaskSummaryAll(dateStart, email);
        //}

        //public List<clsTasks_sp> getTaskSummaryByEmpId(int empID, DateTime dateStart)
        //{
        //    return _dataObject.getTaskSummaryByEmpId(empID, dateStart);
        //}

        //public List<clsTasks> getTaskSummaryWeekly(int empId, DateTime dateStart)
        //{
        //    return _dataObject.getTaskSummaryWeekly(empId,dateStart);
        //}

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

        /// <summary>
        /// delete clsWeeklyReport by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        //public bool Delete(clsTasks.clsTASKSFields fieldName, object value)
        //{
        //    return _dataObject.DeleteByField(fieldName.ToString(), value);
        //}

        //public List<clsTasks> GetTaskDetailByIncidentId(int id)
        //{
        //    return _dataObject.GetTaskDetailByIncidentId(id);
        //}


        #endregion

    }
}
