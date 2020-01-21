using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsSabaLearningSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsSabaLearningSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

       
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsAssignedProjects</returns>
        public List<clsSabaLearning> SelectAllSabaCourses(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllSabaCourses]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaLearning::SelectAllSabaCourses::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsSabaLearning> SelectAllSabaCoursesByTitle(clsSabaLearningKeys keys, int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSabaCourseByTitle]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.SABA_MESSAGE));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaLearning::SelectAllSabaCourseByTitle::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsSabaLearning> SelectAllSabaXref(int empID, int sabaID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllSabaXref]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@SABA_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sabaID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader2(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaLearning::SelectAllSabaCourses::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool Insert(clsSabaLearning businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertSabaCourses]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@END_DATE", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_DATE));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaCourses::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool Update(clsSabaLearning businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateSabaCourses]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@SABA_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SABA_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@END_DATE", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_DATE));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaCourses::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateXref(clsSabaLearning businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateSabaXref]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@SABA_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SABA_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_COMPLETED", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_COMPLETED));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSabaCourses::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsSabaLearning businessObject, IDataReader dataReader)
        {

            businessObject.SABA_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.SABA_ID.ToString()));

            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.EMP_ID.ToString()));


            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.TITLE.ToString())))
            {
                businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.TITLE.ToString()));
            }
            else
            {
                businessObject.TITLE = "";
            }

            businessObject.END_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.END_DATE.ToString()));

            businessObject.TOTAL_ENROLL = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.TOTAL_ENROLL.ToString()));

            businessObject.TOTAL_COMPLETED = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.TOTAL_COMPLETED.ToString()));

        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader2(clsSabaLearning businessObject, IDataReader dataReader)
        {

            businessObject.SABA_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.SABA_ID.ToString()));

            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.IMAGE_PATH.ToString())))
            {
                businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.IMAGE_PATH.ToString()));
            }
            else
            {
                businessObject.IMAGE_PATH = "";
            }


            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.DATE_COMPLETED.ToString())))
            {
                businessObject.DATE_COMPLETED = dataReader.GetString(dataReader.GetOrdinal(clsSabaLearning.clsSabaLearningFields.DATE_COMPLETED.ToString()));
            }
            else
            {
                businessObject.DATE_COMPLETED = "";
            }
           



        }


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsSabaLearning> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsSabaLearning> list = new List<clsSabaLearning>();

            while (dataReader.Read())
            {
                clsSabaLearning businessObject = new clsSabaLearning();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        internal List<clsSabaLearning> PopulateObjectsFromReader2(IDataReader dataReader)
        {

            List<clsSabaLearning> list = new List<clsSabaLearning>();

            while (dataReader.Read())
            {
                clsSabaLearning businessObject = new clsSabaLearning();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
