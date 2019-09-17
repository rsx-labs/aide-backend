using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class ClsKPISummaryFactory
    {

        #region data Members

        ClsKPISummarySql _dataObject = null;

        #endregion

        #region Constructor

        public ClsKPISummaryFactory()
        {
            _dataObject = new ClsKPISummarySql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ClsKPISummary
        /// </summary>
        /// <param name="businessObject">clsCommendations object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(ClsKPISummary businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }


        /// <summary>
        /// get list of all ClsKPISummary
        /// </summary>
        /// <returns>list</returns>
        public List<ClsKPISummary> GetAllKPISummary(ClsKPISummaryKeys keys)
        {
            return _dataObject.GetAllKPISummary(keys);
        }

        /// <summary>
        /// get list of all ClsKPISummary by Month
        /// </summary>
        /// <returns>list</returns>
        public List<ClsKPISummary> GetKPISummaryByMonth(ClsKPISummaryKeys keys)
        {
            return _dataObject.GetKPISummaryByMonth(keys);
        }


        public bool Update(ClsKPISummary businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);

        }

        #endregion

    }
}

