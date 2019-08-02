using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProjectFactory
    {

        #region data Members

        clsProjectSql _dataObject = null;

        #endregion

        #region Constructor

        public clsProjectFactory()
        {
            _dataObject = new clsProjectSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsPROJECT
        /// </summary>
        /// <param name="businessObject">clsPROJECT object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsProject businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);
        }

        /// <summary>
        /// Update existing clsPROJECT
        /// </summary>
        /// <param name="businessObject">clsPROJECT object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsProject businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsPROJECT by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsProject GetByPrimaryKey(clsProjectKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsPROJECTs
        /// </summary>
        /// <returns>list</returns>
        public List<clsProject> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        public List<clsProject> GetAllProjects(int empID, int displayStatus)
        {
            return _dataObject.SelectAllProjects(empID, displayStatus);
        }

        /// <summary>
        /// get list of clsPROJECT by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsProject> GetAllBy(clsProject.clsPROJECTFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsProjectKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsPROJECT by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsProject.clsPROJECTFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
      


              /// <summary>
        /// get list of all clsPROJECTs
        /// </summary>
        /// <returns>list</returns>
        public List<clsProject> GetAllProjectListofEmployee(int empID)
        {
            return _dataObject.GetAllProjectListofEmployee(empID);
        }

        #endregion
    }
}
