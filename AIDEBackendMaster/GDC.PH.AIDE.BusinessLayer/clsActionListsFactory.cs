using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsActionListsFactory
    {
        #region data Members

        clsActionListsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsActionListsFactory()
        {
            _dataObject = new clsActionListsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsAssignedProjects
        /// </summary>
        /// <param name="businessObject">clsAssignedProjects object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsActionLists businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsAssignedProjects
        /// </summary>
        /// <param name="businessObject">clsAssignedProjects object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsActionLists businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsAssignedProjects by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public List<clsActionLists> GetByPrimaryKey(clsActionListsKeys keys, string email)
        {
            return _dataObject.SelectActionListByMessage(keys, email);
        }

        /// <summary>
        /// get list of all clsActionList
        /// </summary>
        /// <returns>list</returns>
        public List<clsActionLists> GetAll(string email)
        {
            return _dataObject.SelectAllActionLists(email);
        }

        /// <summary>
        /// get list of clsActionList By action no
        /// </summary>
        /// <returns>list</returns>
        public List<clsActionLists> GetActionListByActionNo(string actionNo, int empID)
        {
            return _dataObject.GetActionListByActionNo(actionNo, empID);
        }

        /// <summary>
        /// get list of clsActionList
        /// </summary>
        /// <returns>list</returns>
        public List<clsActionLists> GetLessonLearntListOfActionSummary(int empID)
        {
            return _dataObject.GetLessonLearntListOfActionSummary(empID);
        }
        #endregion

    }
}
