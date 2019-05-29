using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class clsContactsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsContactsSql()
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
        public bool Insert(clsContacts businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertContacts]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS2));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCATION));
                sqlCommand.Parameters.Add(new SqlParameter("@CEL_NO", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCAL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCAL));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPHONE", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHERPHONE", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_PHONE));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsContacts::Insert::Error occured.", ex);
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
        public bool Update(clsContacts businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateContacts]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS2));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCATION));
                sqlCommand.Parameters.Add(new SqlParameter("@CEL_NO", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCAL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCAL));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHERPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_PHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_REVIEWED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, System.DateTime.Now));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsContacts::Update::Error occured.", ex);
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
        /// <returns>clsContacts business object</returns>
        public clsContacts SelectByPrimaryKey(clsContactsKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Contacts_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.EMP_ID));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsContacts businessObject = new clsContacts();

                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsContacts::SelectByPrimaryKey::Error occured.", ex);
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
        public List<clsContacts> SelectAll(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetContactListAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsContacts::SelectAll::Error occured.", ex);
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
        /// <returns>list of clsContacts</returns>
        public List<clsContacts> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Contacts_SelectByField]";
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
                throw new Exception("clsContacts::SelectByField::Error occured.", ex);
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
        public bool Delete(clsContactsKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Contacts_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.EMP_ID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsContacts::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_Contacts_DeleteByField]";
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
                throw new Exception("clsContacts::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsContacts businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMP_ID.ToString()));

            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMAIL_ADDRESS.ToString()));
            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.FIRST_NAME.ToString()));
            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.LAST_NAME.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.IMAGE_PATH.ToString())))
            {
                businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.IMAGE_PATH.ToString()));
            }
            else
            {
                businessObject.IMAGE_PATH = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMAIL_ADDRESS2.ToString())))
            {
                businessObject.EMAIL_ADDRESS2 = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMAIL_ADDRESS2.ToString()));
            }
            else
            {
                businessObject.EMAIL_ADDRESS2 = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.LOCATION.ToString())))
            {
                businessObject.LOCATION = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.LOCATION.ToString()));
            }
            else
            {
                businessObject.LOCATION = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.CEL_NO.ToString())))
            {
                businessObject.CEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.CEL_NO.ToString()));
            }
            else
            {
                businessObject.CEL_NO = String.Empty;
            }
                             
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.LOCAL.ToString())))
            {
                businessObject.LOCAL = dataReader.GetInt32(dataReader.GetOrdinal(clsContacts.clsContactsFields.LOCAL.ToString()));
            }
            else
            {
                businessObject.LOCAL = 0;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.HOMEPHONE.ToString())))
            {
                businessObject.HOMEPHONE = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.HOMEPHONE.ToString()));
            }
            else
            {
                businessObject.HOMEPHONE = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.OTHER_PHONE.ToString())))
            {
                businessObject.OTHER_PHONE = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.OTHER_PHONE.ToString()));
            }
            else
            {
                businessObject.OTHER_PHONE = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.DT_REVIEWED.ToString())))
            {
                businessObject.DT_REVIEWED = dataReader.GetDateTime(dataReader.GetOrdinal(clsContacts.clsContactsFields.DT_REVIEWED.ToString()));
            }
            businessObject.POS_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.POS_ID.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.DESCR.ToString()));
            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.FIRST_NAME.ToString()));
            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.LAST_NAME.ToString()));

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsContacts> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsContacts> list = new List<clsContacts>();

            while (dataReader.Read())
            {
                clsContacts businessObject = new clsContacts();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
