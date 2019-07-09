using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsContactsFactory
    {

        #region data Members

        clsContactsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsContactsFactory()
        {
            _dataObject = new clsContactsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsContacts
        /// </summary>
        /// <param name="businessObject">clsContacts object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsContacts businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsContacts
        /// </summary>
        /// <param name="businessObject">clsContacts object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsContacts businessObject, int selection)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject, selection);
        }

        /// <summary>
        /// get clsContacts by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsContacts GetByPrimaryKey(clsContactsKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all clsContactss
        /// </summary>
        /// <returns>list</returns>
        public List<clsContacts> GetAll(string email, int selection)
        {
            return _dataObject.SelectAll(email, selection);
        }

        /// <summary>
        /// get list of clsContacts by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsContacts> GetAllBy(clsContacts.clsContactsFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsContactsKeys keys)
        {
            return _dataObject.Delete(keys);
        }

        /// <summary>
        /// delete clsContacts by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsContacts.clsContactsFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
