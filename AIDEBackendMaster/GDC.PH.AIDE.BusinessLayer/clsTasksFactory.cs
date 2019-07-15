using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsTasksFactory
    {
        #region data Members

        clsTasksSql _dataObject = null;

        #endregion

        #region Constructor

        public clsTasksFactory()
        {
            _dataObject = new clsTasksSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsTASKS
        /// </summary>
        /// <param name="businessObject">clsTASKS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsTasks businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);
        }

        /// <summary>
        /// Update existing clsTASKS
        /// </summary>
        /// <param name="businessObject">clsTASKS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsTasks businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Update(businessObject);
        }

        #region STORED PROCS

        public List<clsTasks> getMyTasks(int empId)
        {
            return _dataObject.SelectByPrimaryKey(empId);
        }

        public clsTasks getTaskDetailByTaskId(clsTasksKeys keys)
        {
            return _dataObject.getTaskDetailByTaskId(keys);
        }

        public List<clsTasks_sp> getTaskSummaryAll(DateTime dateStart, string email)
        {
            return _dataObject.getTaskSummaryAll(dateStart, email);
        }

        public List<clsTasks_sp> getTaskSummaryByEmpId(int empID, DateTime dateStart)
        {
            return _dataObject.getTaskSummaryByEmpId(empID, dateStart);
        }

        public List<clsTasks> getTaskSummaryWeekly(int empId, DateTime dateStart)
        {
            return _dataObject.getTaskSummaryWeekly(empId,dateStart);
        }

        #endregion

        /// <summary>
        /// get list of all clsTASKSs
        /// </summary>
        /// <returns>list</returns>
        public List<clsTasks> GetAll()
        {
            return _dataObject.SelectAll();
        }

        /// <summary>
        /// get list of clsTASKS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
       
        public bool Delete(clsTasksKeys keys)
        {
            return _dataObject.Delete(keys);
        }

        /// <summary>
        /// delete clsTASKS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsTasks.clsTASKSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public List<clsTasks> GetTasksByEmpID(int empID)
        {
            return _dataObject.GetTasksByEmpID(empID);
        }


        #endregion

    }
}
