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

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FIRST_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@MIDDLE_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MIDDLE_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@BIRTHDATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BIRTHDATE));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_HIRED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_HIRED));
                sqlCommand.Parameters.Add(new SqlParameter("@IMAGE_PATH", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE_PATH));
                sqlCommand.Parameters.Add(new SqlParameter("@SHIFT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHIFT));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS2));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCATION));
                sqlCommand.Parameters.Add(new SqlParameter("@CEL_NO", SqlDbType.NVarChar, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCAL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCAL));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHERPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_PHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_REVIEWED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, System.DateTime.Now));
                sqlCommand.Parameters.Add(new SqlParameter("@MARITAL_STATUS_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MARITAL_STATUS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PERMISSION_GROUP_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERMISSION_GROUP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OLD_EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OLD_EMP_ID));
                
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
        public bool Update(clsContacts businessObject, int selection)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateContacts]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FIRST_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@MIDDLE_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MIDDLE_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@BIRTHDATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BIRTHDATE));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_HIRED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_HIRED));
                sqlCommand.Parameters.Add(new SqlParameter("@IMAGE_PATH", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE_PATH));
                sqlCommand.Parameters.Add(new SqlParameter("@SHIFT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHIFT));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS));
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS2));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCATION));
                sqlCommand.Parameters.Add(new SqlParameter("@CEL_NO", SqlDbType.NVarChar, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@LOCAL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCAL));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHERPHONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_PHONE));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_REVIEWED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, System.DateTime.Now));
                sqlCommand.Parameters.Add(new SqlParameter("@MARITAL_STATUS_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MARITAL_STATUS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PERMISSION_GROUP_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERMISSION_GROUP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DEPARTMENT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DIVISION_ID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DIVISION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OLD_EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OLD_EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SELECTION", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, selection));
                

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
        public List<clsContacts> SelectAll(int empID, int selection)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetContactListAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@SELECTION", selection));

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
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsContacts> GetMissingReportsByEmpID(int empID, DateTime currentDate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetMissingReportsByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@CURRENT_DATE", currentDate));

                MainConnection.Open();

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
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMP_ID.ToString())); //1
            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.LAST_NAME.ToString()));          
            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.FIRST_NAME.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.MIDDLE_NAME.ToString())))
            {
                businessObject.MIDDLE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.MIDDLE_NAME.ToString()));
            }
            else
            {
                businessObject.MIDDLE_NAME = String.Empty;
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.NICK_NAME.ToString())))
            {
                businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.NICK_NAME.ToString()));
            }
            else
            {
                businessObject.NICK_NAME = String.Empty;
            }
            businessObject.ACTIVE = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.ACTIVE.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.BIRTHDATE.ToString())))
            {
                businessObject.BIRTHDATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsContacts.clsContactsFields.BIRTHDATE.ToString()));
            }
            businessObject.POSITION = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.POSITION.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.DT_HIRED.ToString())))
            {
                businessObject.DT_HIRED = dataReader.GetDateTime(dataReader.GetOrdinal(clsContacts.clsContactsFields.DT_HIRED.ToString()));
            }
            businessObject.MARITAL_STATUS = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.MARITAL_STATUS.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsContacts.clsContactsFields.IMAGE_PATH.ToString())))
            {
                businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.IMAGE_PATH.ToString()));
            }
            else
            {
                businessObject.IMAGE_PATH = String.Empty;
            }
            businessObject.PERMISSION_GROUP = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.PERMISSION_GROUP.ToString()));
            businessObject.DEPARTMENT = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.DEPARTMENT.ToString()));
            businessObject.DIVISION = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.DIVISION.ToString()));
            businessObject.SHIFT = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.SHIFT.ToString()));
            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.EMAIL_ADDRESS.ToString()));
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
            //businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.STATUS.ToString()));

            businessObject.MARITAL_STATUS_ID = dataReader.GetString(dataReader.GetOrdinal(clsContacts.clsContactsFields.MARITAL_STATUS_ID.ToString()));
            businessObject.POSITION_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.POSITION_ID.ToString()));
            businessObject.PERMISSION_GROUP_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.PERMISSION_GROUP_ID.ToString()));
            businessObject.DEPARTMENT_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.DEPARTMENT_ID.ToString()));
            businessObject.DIVISION_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsContacts.clsContactsFields.DIVISION_ID.ToString()));

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
