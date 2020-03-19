using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsEmployeeFactory
    {

        #region data Members

        clsEmployeeSql _dataObject = null;

        #endregion

        #region Constructor

        public clsEmployeeFactory()
        {
            _dataObject = new clsEmployeeSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsEmployee
        /// </summary>
        /// <param name="businessObject">clsEmployee object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsEmployee businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsEmployee
        /// </summary>
        /// <param name="businessObject">clsEmployee object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsEmployee businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsEmployee by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsEmployee GetByPrimaryKey(clsEmployeeKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsEmployees
        /// </summary>
        /// <returns>list</returns>
        public List<clsEmployee> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<clsEmployee> GetNicknameByDeptID(string email)
        {
            return _dataObject.GetNicknameByDeptID(email);
        }

        /// <summary>
        /// get list of clsEmployee by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsEmployee> GetAllBy(clsEmployee.clsEmployeeFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsEmployeeKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsEmployee by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsEmployee.clsEmployeeFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        /// <summary>
        /// get all missing in resource planner.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsEmployee> GetMissingAttendanceForToday(int empID)
        {
            return _dataObject.GetMissingAttendanceForToday(empID);
        }
        /// <summary>
        /// get the emails of the employees for asset inventory movement.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsEmployee> GetEmployeeEmailForAssetMovement(int empID)
        {
            return _dataObject.GetEmployeeEmailForAssetMovement(empID);
        }
        /// <summary>
        /// get all missing in resource planner.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsEmployee> GetSkillAndContactsNotUpdated(int empID, int choice)
        {
            return _dataObject.GetSkillAndContactsNotUpdated(empID, choice);
        }
        #endregion

    }
}
