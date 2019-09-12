using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class ClsKPITargetsFactory
    {

        #region data Members

        ClsKPITargetsSql _dataObject = null;

        #endregion

        #region Constructor

        public ClsKPITargetsFactory()
        {
            _dataObject = new ClsKPITargetsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsCommendations
        /// </summary>
        /// <param name="businessObject">clsCommendations object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertKPITargets(ClsKPITargets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertKPITargets(businessObject);

        }


        /// <summary>
        /// get list of all ClsKPITargets by Id
        /// </summary>
        /// <returns>list</returns>
        public List<ClsKPITargets> GetKPITargetsById(int id)
        {
            return _dataObject.GetKPITargetById(id);
        }


        /// <summary>
        /// get list of all ClsKPITargets by fiscal year
        /// </summary>
        /// <returns>list</returns>
        public List<ClsKPITargets> GetKPITargetsByFiscalYear(DateTime fyear)
        {
            return _dataObject.GetKPITargetByFiscalYear(fyear);
        }

        public bool UpdateKPITargets(ClsKPITargets businessObject)
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

