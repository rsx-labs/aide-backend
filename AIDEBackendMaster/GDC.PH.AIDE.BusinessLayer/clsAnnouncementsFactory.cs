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
    public class clsAnnouncementsFactory
    {

        #region data Members

        clsAnnouncementsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAnnouncementsFactory()
        {
            _dataObject = new clsAnnouncementsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsCommendations
        /// </summary>
        /// <param name="businessObject">clsCommendations object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertAnnouncements(clsAnnouncements businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertAnnouncements(businessObject);

        }
       

        /// <summary>
        /// get list of all clsCommendations
        /// </summary>
        /// <returns>list</returns>
        public List<clsAnnouncements> GetAnnouncements(int empID)
        {
            return _dataObject.GetAnnouncements(empID);
        }

        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
