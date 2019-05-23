using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsBillablesFactory
    {

        #region data Members

        clsBillablesSql _dataObject = null;

        #endregion

        #region Constructor

        public clsBillablesFactory()
        {
            _dataObject = new clsBillablesSql();
        }

        #endregion


        #region Public Methods

        public List<clsBillables> sp_getBillabilityHoursAll(clsBillablesKeys keys)
        {
            return _dataObject.sp_getBillabilityHoursAll(keys);
        }

        public List<clsBillables> sp_getBillabilityHoursByEmpID(clsBillablesKeys keys)
        {
            return _dataObject.sp_getBillabilityHoursByEmpID(keys);
        }

        public List<clsBillables> sp_getBillableSummary(clsBillablesKeys keys)
        {
            return _dataObject.sp_getBillableSummary(keys);
        }
        #endregion

    }
}
