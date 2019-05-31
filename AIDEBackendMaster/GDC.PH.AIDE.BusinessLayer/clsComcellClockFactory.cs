using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsComcellClockFactory
    {

        #region data Members

        clsComcellClockSql _dataObject = null;

        #endregion

        #region Constructor

        public clsComcellClockFactory()
        {
            _dataObject = new clsComcellClockSql();
        }

        #endregion

        #region Public Methods

        public bool Update(clsComcellClock businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }
            return _dataObject.Update(businessObject);
        }

        public clsComcellClock GetByPrimaryKey(clsComcellClockKeys keys)
        {
            return _dataObject.SelectClockByEmpID(keys);
        }

        #endregion
    }
}
