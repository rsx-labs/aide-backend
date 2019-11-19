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

        /// <summary>
        /// get list of all clsAssignedProjects
        /// </summary>
        /// <returns>list</returns>
        public List<clsAssignedProjects> GetAssignedProjects(int projId)
        {
            return _dataObject.GetAssignedProjects(projId);
        }

        /// <summary>
        /// Delete clsAssignedProjects by employee ID and project ID
        /// </summary>
        /// <param name="businessObject">clsAssignedProjects object</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(int empID, int projectId)
        {

            return _dataObject.Delete(empID, projectId);

        }

        /// <summary>
        /// Delete clsAssignedProjects by project ID
        /// </summary>
        /// <param name="businessObject">clsAssignedProjects object</param>
        /// <returns>true for successfully deleted</returns>
        public bool DeleteAll(int projId)
        {
            
            return _dataObject.DeleteAll(projId);

        }
        #endregion

    }
}
