using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace  GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsLessonLearnt
    /// </summary>
    class clsConcernSql : DataLayerBase
    {
        #region Constructor

        public clsConcernSql()
        {

        }

        #endregion

        #region Public Methods

       //SELECT
        public List<clsConcern> selectAllConcern(string email, int offsetVal , int nextval)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllConcernCauseCountermeasure]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@OFFSETVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, offsetVal));
                sqlCommand.Parameters.Add(new SqlParameter("@NEXTVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nextval));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        // insert CONCERN
        public bool insert(clsConcern businessObject, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertConcernCauseCounterMeasure]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                //sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CONCERN", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CONCERN));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE));
                sqlCommand.Parameters.Add(new SqlParameter("@COUNTERMEASURE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COUNTERMEASURE));
                sqlCommand.Parameters.Add(new SqlParameter("@DUE_DATE", SqlDbType.DateTime, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DUE_DATE));
               

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //GET GENERATED REFNO
        public clsConcern GetGeneratedRefNo()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetGeneratedRefNo]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsConcern businessObjects = new clsConcern();
                    //
                    PopulateBusinessObjectFromReaderGeneratedRefNo(businessObjects, dataReader);
                    //
                    return businessObjects;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("clsConcernGetGeneratedRefNo::getProfile::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        //SELECT
        public List<clsConcern> GetResultSearch (string email, string searchKeyWord, int offsetVal, int nextVal)
        {
           
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetConcernBySearchKeyword]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@KEYWORD", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchKeyWord));
                sqlCommand.Parameters.Add(new SqlParameter("@OFFSETVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, offsetVal));
                sqlCommand.Parameters.Add(new SqlParameter("@NEXTVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nextVal));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //DISPLAY TO LISTVIEW LIST OF ACTION
        public List<clsConcern> GetListOfACtion (string Ref_id, string email)
        {         
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllActionLists]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Ref_id));
                sqlCommand.Parameters.Add(new SqlParameter("EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderAction(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //SELECT TO LISTVIEW THE ACTION_REFERENCES OF CONCERN
        public List<clsConcern> GetListOfACtionReferences(string Ref_id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllActionReferencesinConcern]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Ref_id));
               

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderActionReferences(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        // insert SelectedAction
        public bool insertAndDeleteSelectedAction(clsConcern businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAndDeleteSelectedAction]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
               
                //sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTREF", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTREF));


                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        // UPDATE Selected CONCERN
        public bool UpdateSelectedConcern(clsConcern businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateSelectedConcern]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@CONCERN", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CONCERN));
                sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE));
                sqlCommand.Parameters.Add(new SqlParameter("@COUNTERMEASURE", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COUNTERMEASURE));
                sqlCommand.Parameters.Add(new SqlParameter("@DUE_DATE", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DUE_DATE));

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //SELECT
        public List<clsConcern> GetBetweenSearchConcern(string email, int offsetVal, int nextval, DateTime date1, DateTime date2)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllConcernCauseCountermeasureByBetweenDates]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@OFFSETVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, offsetVal));
                sqlCommand.Parameters.Add(new SqlParameter("@NEXTVAL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nextval));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE1", SqlDbType.Date, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, date1));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE2", SqlDbType.Date, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, date2));



                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //DISPLAY TO LISTVIEW LIST OF ACTION VIA SEARCH
        public List<clsConcern> GetSearchAction(string Ref_id, string _keywordAction, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllActionListsViaSearch]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Ref_id));
                sqlCommand.Parameters.Add(new SqlParameter("@KEYWORDACTION", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _keywordAction));
                sqlCommand.Parameters.Add(new SqlParameter("EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderAction(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsConcern::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        #endregion

        #region Private Methods of SELECT ALL
        internal void PopulateBusinessObjectFromReader(clsConcern businessObject, IDataReader dataReader)
        {


            businessObject.REF_ID = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.REF_ID.ToString()));
            businessObject.CONCERN = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.CONCERN.ToString()));
            businessObject.CAUSE = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.CAUSE.ToString()));
            businessObject.COUNTERMEASURE = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.COUNTERMEASURE.ToString()));
            businessObject.EMP_ID = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.EMP_ID.ToString()));
                 if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACT_REFERENCE.ToString())))
            {
                businessObject.ACT_REFERENCE = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACT_REFERENCE.ToString()));
            }
            else
            {


                businessObject.ACT_REFERENCE = string.Empty;
            }
            businessObject.DUE_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsConcern.clsConcernFields.DUE_DATE.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.DESCR.ToString()));

         

            
                 }

     
        internal List<clsConcern> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsConcern> list = new List<clsConcern>();

            while (dataReader.Read())
            {
                clsConcern businessObject = new clsConcern();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

        #region Private Methods OF GETGENERATED REF No
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        /// 
        internal void PopulateBusinessObjectFromReaderGeneratedRefNo(clsConcern businessObject, IDataReader dataReader)
        {


            businessObject.GENERATEDREF_ID = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.GENERATEDREF_ID.ToString()));


        }
        #endregion       

        #region Private Methods of SELECT ALL ACTION LIST
        internal void PopulateBusinessObjectFromReaderAction(clsConcern businessObject, IDataReader dataReader)
        {
            businessObject.ACTREF = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACTREF.ToString()));
            businessObject.ACT_MESSAGE = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACT_MESSAGE.ToString()));
            businessObject.DUE_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsConcern.clsConcernFields.DUE_DATE.ToString()));
        }

     
        internal List<clsConcern> PopulateObjectsFromReaderAction(IDataReader dataReader)
        {
            List<clsConcern> list = new List<clsConcern>();

            while (dataReader.Read())
            {
                clsConcern businessObject = new clsConcern();
                PopulateBusinessObjectFromReaderAction(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

        #region Private Methods of SELECT ALL ACTION REFERENCES EACH CONCERN

        internal void PopulateBusinessObjectFromReaderActionReferences(clsConcern businessObject, IDataReader dataReader)
        {
         
            businessObject.ACTION_REFERENCES = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACTION_REFERENCES.ToString()));
            businessObject.ACTREF = dataReader.GetString(dataReader.GetOrdinal(clsConcern.clsConcernFields.ACTREF.ToString()));

        }

        internal List<clsConcern> PopulateObjectsFromReaderActionReferences(IDataReader dataReader)
        {
            List<clsConcern> list = new List<clsConcern>();

            while (dataReader.Read())
            {
                clsConcern businessObject = new clsConcern();
                PopulateBusinessObjectFromReaderActionReferences(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}

