using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// BY GIANN CARLO CAMILO/CHRISTIAN VALONDO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
  public  class clsConcernFactory
    {
        #region data Members

        clsConcernSql _dataObject = null;

        #endregion

        #region Constructor

        public clsConcernFactory()
        {
            _dataObject = new clsConcernSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
       

        /// <summary>
        /// Update existing clsLessonLearnt
        /// </summary>
        /// <param name="businessObject">clsLessonLearnt object</param>
        /// <returns>true for successfully saved</returns>
    

        /// <summary>
        /// get clsLessonLearnt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>

        public List<clsConcern> selectAllConcern(string email, int offSetVal, int nextVal)
        {
            return _dataObject.selectAllConcern(email, offSetVal, nextVal);
        }


        /// <summary>
        /// insert into Concern.
        /// </summary>
        /// <param name="keys">primary key</param>
        public bool Insert(clsConcern businessObject, string email)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.insert(businessObject, email);
        }

        /// <summary>
        /// GET GENERATED REF NO
        /// </summary>
        /// <param name="keys">primary key</param>
        public clsConcern GetGeneratedRefNo()
        {
            return _dataObject.GetGeneratedRefNo();
        }

        /// <summary>
        /// SEARCH BY KEYWORD
        /// </summary>
        /// <param name="keys">primary key</param>
        public List<clsConcern> Search(string email, string searchKeyword, int offSetVal , int nextVal)
        {
            return _dataObject.GetResultSearch(email, searchKeyword, offSetVal, nextVal);
        }

        /// <summary>
        /// LIST OF ACTION LIST DISPLAY TO LISTVIEW.
        /// </summary>
        /// <param name="keys">primary key</param>
        public List<clsConcern> GetACtionList(string Ref_id, string email)
        {
            return _dataObject.GetListOfACtion(Ref_id, email);
        }


        /// <summary>
        /// LIST OF ACTION REFERENCES IN EACH CONCERN
        /// </summary>
        /// <param name="keys">primary key</param>
        public List<clsConcern> GetACtionListReferences(string Ref_id)
        {
            return _dataObject.GetListOfACtionReferences(Ref_id);
        }


        /// <summary>
        /// INSERT EACH SELECTED ACTION IN CONCERN
        /// </summary>
        /// <param name="keys">primary key</param>
        public bool insertAndDeleteSelectedAction(clsConcern businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.insertAndDeleteSelectedAction(businessObject);
        }


        /// <summary>
        /// UPDATE SELECTED CONCERN
        /// </summary>
        /// <param name="keys">primary key</param>
        public bool UpdateSelectedConcern(clsConcern businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.UpdateSelectedConcern(businessObject);
        }




        /// <summary>
        /// SEACH DUE DATE BETWEEN DATES
        /// </summary>
        /// <param name="keys">primary key</param>
        public List<clsConcern> GetBetweenSearchConcern(string email, int offSetVal, int nextVal, DateTime date1, DateTime date2)
        {
            return _dataObject.GetBetweenSearchConcern(email, offSetVal, nextVal, date1, date2);
        }



        /// <summary>
        /// LIST OF ACTION LIST VIA SEARCH KEYWORD
        /// </summary>
        /// <param name="keys">primary key</param>
        public List<clsConcern> GetSearchAction(string _keywordAction, string Ref_id, string email)
        {
            return _dataObject.GetSearchAction(_keywordAction, Ref_id, email);
        }



        #endregion
    }
}
