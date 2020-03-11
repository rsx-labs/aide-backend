using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsOptionFactory
    {
        #region Data Members

        clsOptionSql _dataObject = null;

        #endregion

        #region Constructor

        public clsOptionFactory()
        {
            _dataObject = new clsOptionSql();
        }

        #endregion

        #region Public Methods

        public List<clsOption> GetOptions(int optionID, int moduleID, int functionID)
        {
            return _dataObject.GetOption(optionID, moduleID, functionID);
        }
        #endregion
    }
}
