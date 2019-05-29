using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsLateFactory
    {

        #region data Members

        clsLateSql _dataObject = null;

        #endregion

        #region Constructor

        public clsLateFactory()
        {
            _dataObject = new clsLateSql();
        }

        #endregion

        #region Public Methods

        public List<clsLate> GetLate(int empID, int month, int year, int toDisplay)
        {
            return _dataObject.sp_GetLate(empID, month, year, toDisplay);
        }

        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
