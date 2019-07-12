using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsMessageFactory
    {
        #region data Members

        clsMessageSql _dataObject = null;

        #endregion

        #region Constructor

        public clsMessageFactory()
        {
            _dataObject = new clsMessageSql();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// get list of all clsMessage
        /// </summary>
        /// <returns>list</returns>
        public List<clsMessage> GetMessage(int msg_id, int sec_id)
        {
            return _dataObject.GetMessage(msg_id,sec_id);
        }
        #endregion
    }
}
