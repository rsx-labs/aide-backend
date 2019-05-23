using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsStatus
	/// </summary>
	class clsStatusSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public clsStatusSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public bool Insert(clsStatus businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[sp_STATUS_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{

                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_ID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@DESCR", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCR));
				sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                
				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("clsStatus::Insert::Error occured.", ex);
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
        public bool Update(clsStatus businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_STATUS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_ID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@DESCR", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCR));
				sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsStatus::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsStatus business object</returns>
        public List<clsStatus> SelectByPrimaryKey(clsStatusKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Status_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_ID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.GRP_ID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsStatus::SelectAll::Error occured.", ex);
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
        /// <returns>list of clsStatus</returns>
        public List<clsStatus> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_STATUS_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {                
                throw new Exception("clsStatus::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>list of clsStatus</returns>
        public List<clsStatus> SelectByField(string fieldName, object value)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_STATUS_SelectByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsStatus::SelectByField::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsStatusKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_STATUS_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsStatus::DeleteByKey::Error occured.", ex);
            }
            finally
            {                
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Delete records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>true for successfully deleted</returns>
        public bool DeleteByField(string fieldName, object value)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_STATUS_DeleteByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {                
                throw new Exception("clsStatus::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsStatus businessObject, IDataReader dataReader)
        {
            businessObject.STATUS_ID = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsStatus.clsStatusFields.STATUS_ID.ToString()));
                businessObject.STATUS_NAME = dataReader.GetString(dataReader.GetOrdinal(clsStatus.clsStatusFields.STATUS_NAME.ToString()));
				businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsStatus.clsStatusFields.DESCR.ToString()));
				businessObject.STATUS = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsStatus.clsStatusFields.STATUS.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsStatus</returns>
        internal List<clsStatus> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsStatus> list = new List<clsStatus>();

            while (dataReader.Read())
            {
                clsStatus businessObject = new clsStatus();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
	}
}
