using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAssignedProjectsFactory
    {

        #region data Members

        clsAssignedProjectsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAssignedProjectsFactory()
        {
            _dataObject = new clsAssignedProjectsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsAssignedProjects
        /// </summary>
        /// <param name="businessObject">clsAssignedProjects object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsAssignedProjects businessObject)
        {
            //if (!businessObject.IsValid)
            //{
            //    throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            //}


            return _dataObject.Insert(businessObject);

        }

       

        #endregion

    }
}
