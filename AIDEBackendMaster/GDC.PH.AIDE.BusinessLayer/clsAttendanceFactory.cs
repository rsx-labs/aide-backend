using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAttendanceFactory
    {

        #region data Members

        DataLayer.clsAttendanceSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAttendanceFactory()
        {
            _dataObject = new clsAttendanceSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsAttendance
        /// </summary>
        /// <param name="businessObject">clsAttendance object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsAttendance businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsAttendance
        /// </summary>
        /// <param name="businessObject">clsAttendance object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsAttendance businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        public bool Update(clsAttendance businessObject, int day, int status)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject, day, status);
        }

        public bool InsertLogoffTime(clsAttendance businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }            
            return _dataObject.InsertLogoffTime(businessObject);
        }
        /// <summary>
        /// get clsAttendance by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsAttendance GetByPrimaryKey(clsAttendanceKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsAttendances
        /// </summary>
        /// <returns>list</returns>
        public List<clsAttendance> GetAll()
        {
            return _dataObject.SelectAll(); 
        }


        /// <summary>
        /// get list of all clsAttendances
        /// </summary>
        /// <returns>list</returns>
        public List<clsAttendance> GetByMothly(clsAttendanceKeys keys)
        {
            return _dataObject.SelectByMonthly(keys);
        }

        /// <summary>
        /// get list of all clsAttendances
        /// </summary>
        /// <returns>list</returns>
        public List<clsAttendance> GetByWeekly(int empId, DateTime weekOf)
        {
            return _dataObject.SelectByWeekly(empId, weekOf);
        }

        /// <summary>
        /// get list of clsAttendance by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsAttendance> GetAllBy(clsAttendance.clsAttendanceFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsAttendanceKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsAttendance by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsAttendance.clsAttendanceFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public List<clsAttendance> GetAttendanceToday(string email)
        {
            return _dataObject.GetAttendanceToday(email);
        }

        public List<clsAttendance> GetAttendanceTodayBySearch(string email, string input)
        {
            return _dataObject.GetAttendanceTodayBySearch(email, input);
        }

        #endregion

    }
}
