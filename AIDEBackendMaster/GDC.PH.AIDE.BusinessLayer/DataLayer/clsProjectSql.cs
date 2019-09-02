using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// BY GIANN CARLO CAMILO, HYACINTH AMARLES AND HARVEY SANCHEZ
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsPROJECT
    /// </summary>
    class clsProjectSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsProjectSql()
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
        public bool Insert(clsProject businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_CD));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CATEGORY));
                sqlCommand.Parameters.Add(new SqlParameter("@BILLABILITY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BILLABILITY));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsPROJECT::Insert::Error occured.", ex);
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
        public bool Update(clsProject businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_CD));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CATEGORY));
                sqlCommand.Parameters.Add(new SqlParameter("@BILLABILITY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BILLABILITY));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsPROJECT::Update::Error occured.", ex);
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
        /// <returns>clsPROJECT business object</returns>
        public clsProject SelectByPrimaryKey(clsProjectKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.PROJ_ID));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsProject businessObject = new clsProject();

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
                throw new Exception("clsPROJECT::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of clsPROJECT</returns>
        public List<clsProject> SelectAll()
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_SelectAll]";
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
                throw new Exception("clsPROJECT::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

           
        }

        /// <summary>
        /// Select all rescords   -- GIANN CARLO CAMILO
        /// </summary>
        /// <returns>list of clsPROJECT</returns>
        public List<clsProject> GetAllProjectListofEmployee(int empID)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetProjectByEmployeeList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsPROJECTOFEMPLOYEES::GetAllProjectListofEmployee::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public List<clsNickname> GetEmployeePerProject(int empID, int projID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetEmployeePerProject]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;


            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, projID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForNickname(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::getNicknameByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// GIANN CARLO CAMILO- DISPLAY ALL PROJECTS IN COMBO BOX
        /// </summary>
        /// <returns></returns>
        public List<clsProject> SelectAllProjects(int empID, int displayStatus)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProjects]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@DISPLAY_STATUS", displayStatus));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsPROJECT::SelectAllProjects::Error occured.", ex);
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
        /// <returns>list of clsPROJECT</returns>
        public List<clsProject> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_SelectByField]";
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
                throw new Exception("clsPROJECT::SelectByField::Error occured.", ex);
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
        public bool Delete(clsProjectKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_PROJECT_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.PROJ_ID));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsPROJECT::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_PROJECT_DeleteByField]";
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
                throw new Exception("clsPROJECT::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsProject businessObject, IDataReader dataReader)
        {
            businessObject.PROJ_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProject.clsPROJECTFields.PROJ_ID.ToString()));
            businessObject.PROJ_CD = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields.PROJ_CD.ToString()));
            businessObject.PROJ_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields.PROJ_NAME.ToString()));
            businessObject.CATEGORY = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsProject.clsPROJECTFields.CATEGORY.ToString()));
            businessObject.BILLABILITY = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsProject.clsPROJECTFields.BILLABILITY.ToString()));
        }


        internal void PopulateBusinessObjectFromReader2(clsProject businessObject, IDataReader dataReader)
        {
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.STATUS.ToString())))
            {
                businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.STATUS.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.NAME.ToString())))
            {
                businessObject.NAME = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.NAME.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.FIRSTMONTH.ToString())))
            {
                businessObject.FIRSTMONTH = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.FIRSTMONTH.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.SECONDMONTH.ToString())))
            {
                businessObject.SECONDMONTH = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.SECONDMONTH.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.THIRDMONTH.ToString())))
            {
                businessObject.THIRDMONTH = dataReader.GetString(dataReader.GetOrdinal(clsProject.clsPROJECTFields2.THIRDMONTH.ToString()));
            }
        }

        internal void PopulateBusinessObjectFromReaderForNickname(clsNickname businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsNickname.clsNicknameFields.EMP_ID.ToString()));
            businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsNickname.clsNicknameFields.NICK_NAME.ToString()));

        }
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPROJECT</returns>
        internal List<clsProject> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsProject> list = new List<clsProject>();

            while (dataReader.Read())
            {
                clsProject businessObject = new clsProject();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsProject> PopulateObjectsFromReader2(IDataReader dataReader2)
        {
            List<clsProject> list = new List<clsProject>();

            while (dataReader2.Read())
            {
                clsProject businessObject = new clsProject();
                PopulateBusinessObjectFromReader2(businessObject, dataReader2);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsNickname> PopulateObjectsFromReaderForNickname(IDataReader dataReader)
        {
            List<clsNickname> list = new List<clsNickname>();

            while (dataReader.Read())
            {
                clsNickname businessObject = new clsNickname();
                PopulateBusinessObjectFromReaderForNickname(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion
    }
}