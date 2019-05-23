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
    public class clsAssetsFactory
    {

        #region data Members

        clsAssetsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAssetsFactory()
        {
            _dataObject = new clsAssetsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsAssets
        /// </summary>
        /// <param name="businessObject">clsAssets object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertAssets(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertAssets(businessObject);

        }

        /// <summary>
        /// Update existing clsAssets
        /// </summary>
        /// <param name="businessObject">clsAssets object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateAssets(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateAssets(businessObject);
        }



        /// <summary>
        /// get list of all clsAssets
        /// </summary>
        /// <returns>list</returns>
        public List<clsAssets> GetAllAssetsByEmpID(int empID)
        {
            return _dataObject.GetAllAssetsByEmpID(empID);
        }

        public List<clsAssets> GetMyAssets(int empID)
        {
            return _dataObject.GetMyAssets(empID);
        }

        /// <summary>
        /// get list of all clsAssets by keyword
        /// </summary>
        /// <returns>list</returns>
        public List<clsAssets> GetAllAssetsBySearch(int empID, string input)
        {
            return _dataObject.GetAllAssetsBySearch(empID, input);
        }


        /// <summary>
        /// get list of all clsAssets
        /// </summary>
        /// <returns>list</returns>
        public List<clsAssets> GetAllAssetsInventoryByEmpID(int empID)
        {
            return _dataObject.GetAllAssetsInventoryByEmpID(empID);
        }

        public List<clsAssets> GetAllAssetsInventoryUnApproved(int empID)
        {
            return _dataObject.GetAllAssetsInventoryUnApproved(empID);
        }

        /// <summary>
        /// Update existing clsAssets
        /// </summary>
        /// <param name="businessObject">clsAssets object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateAssetsInventory(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateAssetsInventory(businessObject);
        }

        public bool UpdateAssetsInventoryApproval(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateAssetsInventoryApproval(businessObject);
        }

        public bool UpdateAssetsInventoryCancel(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateAssetsInventoryCancel(businessObject);
        }

        /// <summary>
        /// Insert new clsAssets
        /// </summary>
        /// <param name="businessObject">clsAssets object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertAssetsInventory(clsAssets businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertAssetsInventory(businessObject);

        }

        /// <summary>
        /// get list of all clsAssets
        /// </summary>
        /// <returns>list</returns>
        public List<clsAssets> GetAllAssetsUnAssigned(int empID)
        {
            return _dataObject.GetAllAssetsUnAssigned(empID);
        }

        public List<clsAssets> GetAllAssetsHistory(int empID)
        {
            return _dataObject.GetAllAssetsHistory(empID);
        }

        public List<clsAssets> GetAllAssetsHistoryBySearch(int empID, string input)
        {
            return _dataObject.GetAllAssetsHistoryBySearch(empID, input);
        }

        public List<clsAssets> GetAllAssetsInventoryBySearch(int empID, string input, string page)
        {
            return _dataObject.GetAllAssetsInventoryBySearch(empID, input, page);
        }

        public List<clsAssets> GetAssetManufacturer()
        {
            return _dataObject.GetAssetManufacturer();
        }

        public List<clsAssets> GetAssetDescription()
        {
            return _dataObject.GetAssetDescription();
        }
        #endregion
    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
