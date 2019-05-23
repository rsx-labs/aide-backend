using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// By John Harvey Sanchez
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsLessonLearnt
    /// </summary>
    class clsLessonLearntSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsLessonLearntSql()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool Insert(clsLessonLearnt businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertLessonLearnt]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@REF_NO", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM));
                sqlCommand.Parameters.Add(new SqlParameter("@RESOLUTION", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESOLUTION));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_NO", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTION_NO));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsLessonLearnt::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(clsLessonLearnt businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateLessonLearnt]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@REF_NO", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REF_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM));
                sqlCommand.Parameters.Add(new SqlParameter("@RESOLUTION", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESOLUTION));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_NO", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTION_NO));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsLessonLearnt::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsLessonLearnt> SelectAll(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllLessonLearnt]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", email));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsLessonLearnt::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select records by problem
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsLessonLearnt> SelectByProblem(clsLessonLearntKeys keys, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetLessonLearntByProblem]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@Problem", keys.PROBLEM));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", email));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsLessonLearnt::SelectAll::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsLessonLearnt businessObject, IDataReader dataReader)
        {
            businessObject.REF_NO = dataReader.GetString(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.REF_NO.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.EMP_ID.ToString()));
            businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.NICK_NAME.ToString()));
            businessObject.PROBLEM = dataReader.GetString(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.PROBLEM.ToString()));
            businessObject.RESOLUTION = dataReader.GetString(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.RESOLUTION.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.ACTION_NO.ToString())))
            {
                businessObject.ACTION_NO = dataReader.GetString(dataReader.GetOrdinal(clsLessonLearnt.clsLessonLearntFields.ACTION_NO.ToString()));
            }
            else
            {
                businessObject.ACTION_NO = "";
            }

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsLessonLearnt</returns>
        internal List<clsLessonLearnt> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsLessonLearnt> list = new List<clsLessonLearnt>();

            while (dataReader.Read())
            {
                clsLessonLearnt businessObject = new clsLessonLearnt();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
