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
    public class clsWorkplaceAuditFactory
    {

        #region data Members

        clsWorkplaceAuditSql _dataObject = null;

        #endregion

        #region Constructor

        public clsWorkplaceAuditFactory()
        {
            _dataObject = new clsWorkplaceAuditSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsWorkplaceAudit
        /// </summary>
        /// <param name="businessObject">clsWorkplaceAudit object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertAuditDaily(clsWorkplaceAudit businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertAuditDaily(businessObject);

        }

        /// <summary>
        /// Update existing clsWorkplaceAudit
        /// </summary>
        /// <param name="businessObject">clsWorkplaceAudit object</param>
        /// <returns>true for successfully saved</returns>
        //public bool UpdateAuditSched(clsWorkplaceAudit businessObject)
        //{
        //    if (!businessObject.IsValid)
        //    {
        //        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
        //    }


        //    return _dataObject.UpdateAuditSched(businessObject);
        //}

        

        /// <summary>
        /// get list of all clsWorkplaceAudit
        /// </summary>
        /// <returns>list</returns>
        public List<clsWorkplaceAudit> GetAuditDaily(int empID, DateTime parmDate)
        {
            return _dataObject.GetAuditDaily(empID, parmDate);
        }

        /// <summary>
        /// get list of all clsWorkplaceAudit
        /// </summary>
        /// <returns>list</returns>
        public List<clsWorkplaceAudit> GetAuditQuestions(int empID, string questionGroup)
        {
            return _dataObject.GetAuditQuestions(empID, questionGroup);
        }


        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
