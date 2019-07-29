using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/// <summary>
/// By Jhunell G. Barcenas
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSkillsFactory
    {
        #region data Members

        clsSkillsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsSkillsFactory()
        {
            _dataObject = new clsSkillsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
        public bool InsertSkills(clsSkills businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.InsertSkillsProf(businessObject);
        }

        /// <summary>
        /// Update existing clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateSkills(clsSkills businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.UpdateSkills(businessObject);
        }

        /// <summary>
        /// Update existing clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
        public bool UpdateAllSkills(clsSkills businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.UpdateAllSkills(businessObject);
        }

        /// <summary>
        /// get clsLessonLearnt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        public clsSkills GetSkillsProfByEmpID(clsSkillsKeys keys)
        {
            return _dataObject.GetSkillsProfByEmpID(keys);
        }

        public clsSkills GetProfLvlByEmpIDSkillID(int empID, int skillID)
        {
            return _dataObject.GetProfLvlByEmpIDSkillID(empID, skillID);
        }

        public clsSkills GetSkillsLastReviewByEmpIDSkillID(int empID, int skillID)
        {
            return _dataObject.GetSkillsLastReviewByEmpIDSkillID(empID, skillID);
        }

        /// <summary>
        /// get list of all clsLessonLearnt
        /// </summary>
        /// <returns>list</returns>
        public List<clsSkills> GetSkillsList(int empID)
        {
            return _dataObject.SelectSkillList(empID);
        }

        public List<clsSkills> GetSkillsProfByEmpID(int id)
        {
            return _dataObject.GetSkillsProfByEmpID(id);
        }

        public List<clsSkills> ViewEmpSkills(int empID)
        {
            return _dataObject.ViewEmployeeSkills(empID);
        }

        #endregion
    }
}
