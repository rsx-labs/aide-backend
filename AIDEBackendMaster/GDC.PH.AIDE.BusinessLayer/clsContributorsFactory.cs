using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsContributorsFactory
    {
        #region data Members

        clsContributorsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsContributorsFactory()
        {
            _dataObject = new clsContributorsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// get list of all clsCommendations
        /// </summary>
        /// <returns>list</returns>
        public List<clsContributors> GetAnnouncements(int level)
        {
            return _dataObject.GetAllMainContributors(level);
        }

       #endregion
    }
}
