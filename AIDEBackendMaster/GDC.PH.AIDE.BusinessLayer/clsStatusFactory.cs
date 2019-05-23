using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsStatusFactory
    {

        #region data Members

        clsStatusSql _dataObject = null;

        #endregion

        #region Constructor

        public clsStatusFactory()
        {
            _dataObject = new clsStatusSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsStatus
        /// </summary>
        /// <param name="businessObject">clsStatus object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsStatus businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsStatus
        /// </summary>
        /// <param name="businessObject">clsStatus object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsStatus businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsStatus by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public List<clsStatus> GetByPrimaryKey(clsStatusKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsStatuss
        /// </summary>
        /// <returns>list</returns>
        public List<clsStatus> GetAll()
        {
            return _dataObject.SelectAll(); 
        }
        public List<clsStatus> GetListByPrimaryKey(clsStatusKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of clsStatus by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsStatus> GetAllBy(clsStatus.clsStatusFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsStatusKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsStatus by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsStatus.clsStatusFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
