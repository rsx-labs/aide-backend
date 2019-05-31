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
    public class clsComcellFactory
    {

        #region data Members

        clsComcellSql _dataObject = null;

        #endregion

        #region Constructor

        public clsComcellFactory()
        {
            _dataObject = new clsComcellSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsComcell
        /// </summary>
        /// <param name="businessObject">clsComcell object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertComcellMeeting(clsComcell businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertComcellMeeting(businessObject);

        }

        /// <summary>
        /// Update existing clsComcell
        /// </summary>
        /// <param name="businessObject">clsComcell object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateComcellMeeting(clsComcell businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateComcellMeeting(businessObject);
        }

        

        /// <summary>
        /// get list of all clsComcell
        /// </summary>
        /// <returns>list</returns>
        public List<clsComcell> GetComcellMeeting(int empID, int year)
        {
            return _dataObject.GetComcellMeeting(empID, year);
        }


        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
