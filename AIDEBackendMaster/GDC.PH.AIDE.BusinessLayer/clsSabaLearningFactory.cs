using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSabaLearningFactory
    {

        #region data Members

        clsSabaLearningSql _dataObject = null;

        #endregion

         #region Constructor

        public clsSabaLearningFactory()
        {
            _dataObject = new clsSabaLearningSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// get list of all clsSabaLearning
        /// </summary>
        /// <returns>list</returns>
        public List<clsSabaLearning> GetAll(int empID)
        {
            return _dataObject.SelectAllSabaCourses(empID);
        }

        public List<clsSabaLearning> GetAllSabaXref(int empID, int sabaID)
        {
            return _dataObject.SelectAllSabaXref(empID, sabaID);
        }

        public bool Insert(clsSabaLearning businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);

        }

        public bool Update(clsSabaLearning businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        public bool UpdateXref(clsSabaLearning businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.UpdateXref(businessObject);
        }

        public List<clsSabaLearning> GetAllByTitle(clsSabaLearningKeys keys, int empID)
        {
            return _dataObject.SelectAllSabaCoursesByTitle(keys, empID);
        }


        #endregion
    }
}
