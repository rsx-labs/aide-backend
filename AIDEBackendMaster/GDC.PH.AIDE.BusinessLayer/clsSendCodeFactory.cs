using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSendCodeFactory
    {

        #region data Members

        clsSendCodeSql _dataObject = null;

        #endregion

        #region Constructor

        public clsSendCodeFactory()
        {
            _dataObject = new clsSendCodeSql();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// get clsSendCode by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsSendCode GetByPrimaryKey(clsSendCodeKey keys)
        {
            return _dataObject.SelectWorkEmailbyEmail(keys);
        }

        #endregion
    }
}
