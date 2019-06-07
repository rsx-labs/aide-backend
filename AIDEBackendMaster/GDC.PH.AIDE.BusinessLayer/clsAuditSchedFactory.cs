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
    public class clsAuditSchedFactory
    {

        #region data Members

        clsAuditSchedSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAuditSchedFactory()
        {
            _dataObject = new clsAuditSchedSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsAuditSched
        /// </summary>
        /// <param name="businessObject">clsAuditSched object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertAuditSched(clsAuditSched businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertAuditSched(businessObject);

        }

        /// <summary>
        /// Update existing clsAuditSched
        /// </summary>
        /// <param name="businessObject">clsAuditSched object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateAuditSched(clsAuditSched businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateAuditSched(businessObject);
        }

        

        /// <summary>
        /// get list of all clsAuditSched
        /// </summary>
        /// <returns>list</returns>
        public List<clsAuditSched> GetAuditSched(int empID, int year)
        {
            return _dataObject.GetAuditSched(empID, year);
        }


        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
