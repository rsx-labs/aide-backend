using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

///<summary>
/// By John Harvey Sanchez
///<summary>

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsLessonLearntFactory
    {
        #region data Members

        clsLessonLearntSql _dataObject = null;

        #endregion

        #region Constructor

        public clsLessonLearntFactory()
        {
            _dataObject = new clsLessonLearntSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsLessonLearnt businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Insert(businessObject);
        }

        /// <summary>
        /// Update existing clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsLessonLearnt businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get list of all clsLessonLearnt
        /// </summary>
        /// <returns>list</returns>
        public List<clsLessonLearnt> GetAll(string email)
        {
            return _dataObject.SelectAll(email);
        }

        /// <summary>
        /// get clsLessonLearnt by Problem Encountered.
        /// </summary>
        public List<clsLessonLearnt> GetByProblem(clsLessonLearntKeys keys, string email)
        {
            return _dataObject.SelectByProblem(keys, email);
        }
        #endregion
    }
}
