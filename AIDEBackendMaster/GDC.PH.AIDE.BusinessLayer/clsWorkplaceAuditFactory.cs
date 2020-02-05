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
        /// <summary>
        /// Get weekly sched of audit display in dropdown
        /// </summary>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetAuditSChed_Month(int audit_grp, int yr, int month)
        {
            return _dataObject.GetAuditSChed_Month(audit_grp, yr, month);
        }
        /// <summary>
        /// Get daily auditor this week
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="parmDate"></param>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetDailyAuditorByWeek(int empID, string paramFYWeek)
        {
            return _dataObject.GetDailyAuditorByWeek(empID, paramFYWeek);
        }
        public bool UpdateCheckAuditQuestionStatus(clsWorkplaceAudit businessObject)
        {
          

            return _dataObject.UpdateCheckAuditQuestionStatus(businessObject);

        }
        public bool UpdateAuditSched(clsAuditSched businessObject)
        {


            return _dataObject.UpdateAuditSched(businessObject);

        }
        /// <summary>
        /// Get weekly Auditor
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="paraDate"></param>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetWeeklyAuditor(int empID, DateTime paraDate)
        {
            return _dataObject.GetWeeklyAuditor(empID, paraDate);
        }
        /// <summary>
        /// Monthly Auditor
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="paraDate"></param>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetMonthlyAuditor(int empID, int paraDate)
        {
            return _dataObject.GetMonthlyAuditor(empID, paraDate);
        }
        /// <summary>
        /// Quarterly Auditor
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="paraDate"></param>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetQuarterlyAuditor(int empID, int paraDate)
        {
            return _dataObject.GetQuarterlyAuditor(empID, paraDate);
        }

        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
