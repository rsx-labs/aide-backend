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
    public class clsCommendationsFactory
    {

        #region data Members

        clsCommendationsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsCommendationsFactory()
        {
            _dataObject = new clsCommendationsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsCommendations
        /// </summary>
        /// <param name="businessObject">clsCommendations object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertCommendations(clsCommendations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertCommendations(businessObject);

        }

        /// <summary>
        /// Update existing clsCommendations
        /// </summary>
        /// <param name="businessObject">clsCommendations object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateCommendations(clsCommendations businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateCommendations(businessObject);
        }

        

        /// <summary>
        /// get list of all clsCommendations
        /// </summary>
        /// <returns>list</returns>
        public List<clsCommendations> GetCommendations(int empID)
        {
            return _dataObject.GetCommendations(empID);
        }

        public List<clsCommendations> GetCommendationsBySearch(int empID, int month, int year)
        {
            return _dataObject.GetCommendationsBySearch(empID, month, year);
        }

        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
