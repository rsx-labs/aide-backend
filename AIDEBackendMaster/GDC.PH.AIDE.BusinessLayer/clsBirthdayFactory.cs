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
    public class clsBirthdayFactory
    {

        #region data Members

        clsBirthdaySql _dataObject = null;

        #endregion

        #region Constructor

        public clsBirthdayFactory()
        {
            _dataObject = new clsBirthdaySql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// get list of all clsContactss
        /// </summary>
        /// <returns>list</returns>
        public List<clsBirthday> GetAll(string email)
        {
            return _dataObject.SelectAll(email);
        }

        /// <summary>
        /// get list of clsContacts by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsBirthday> GetAllByMonth(string email)
        {
            return _dataObject.SelectByMonth(email);
        }


        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
