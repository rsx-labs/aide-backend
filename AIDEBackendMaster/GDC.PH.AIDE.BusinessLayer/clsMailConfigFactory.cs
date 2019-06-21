using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsMailConfigFactory
    {

        #region data Members

        clsMailConfigSql _dataObject = null;

        #endregion

         #region Constructor

        public clsMailConfigFactory()
        {
            _dataObject = new clsMailConfigSql();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// get clsMailConfig.
        /// </summary>
        public clsMailConfig GetItem()
        {
            return _dataObject.GetMailConfig();
        }

        #endregion

    }
}
