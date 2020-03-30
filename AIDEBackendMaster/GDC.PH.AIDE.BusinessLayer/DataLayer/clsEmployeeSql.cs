using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsEmployee
	/// </summary>
	class clsEmployeeSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public clsEmployeeSql()
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
		public bool Insert(clsEmployee businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FIRST_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@MIDDLE_INITIAL", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MIDDLE_INITIAL));
				sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@BIRTHDATE", SqlDbType.Text, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BIRTHDATE));
				sqlCommand.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION));
				sqlCommand.Parameters.Add(new SqlParameter("@DATE_HIRED", SqlDbType.Text, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_HIRED));
				sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@IMAGE_PATH", businessObject.IMAGE_PATH));
				sqlCommand.Parameters.Add(new SqlParameter("@GRP_ID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GRP_ID));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.EMP_ID = (int)sqlCommand.Parameters["@EMP_ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("clsEmployee::Insert::Error occured.", ex);
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
        public bool Update(clsEmployee businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FIRST_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@MIDDLE_INITIAL", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MIDDLE_INITIAL));
				sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
				sqlCommand.Parameters.Add(new SqlParameter("@BIRTHDATE", SqlDbType.Text, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BIRTHDATE));
				sqlCommand.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION));
				sqlCommand.Parameters.Add(new SqlParameter("@DATE_HIRED", SqlDbType.Text, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_HIRED));
				sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
				sqlCommand.Parameters.Add(new SqlParameter("@IMAGE_PATH", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE_PATH));
				sqlCommand.Parameters.Add(new SqlParameter("@GRP_ID", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GRP_ID));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmployee::Update::Error occured.", ex);
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
        /// <returns>clsEmployee business object</returns>
        public clsEmployee SelectByPrimaryKey(clsEmployeeKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_SelectByPrimaryKey]";
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
                    clsEmployee businessObject = new clsEmployee();

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
                throw new Exception("clsEmployee::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of clsEmployee</returns>
        public List<clsEmployee> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM vw_Employees";
            sqlCommand.CommandType = CommandType.Text;

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
                throw new Exception("clsEmployee::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsEmployee> GetNicknameByDeptID(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetNicknameByDeptID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@TO_DISPLAY", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllEmpResourcePlanner::Error occured.", ex);
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
        /// <returns>list of clsEmployee</returns>
        public List<clsEmployee> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_SelectByField]";
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
                throw new Exception("clsEmployee::SelectByField::Error occured.", ex);
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
        public bool Delete(clsEmployeeKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_DeleteByPrimaryKey]";
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
                throw new Exception("clsEmployee::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_EMPLOYEE_DeleteByField]";
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
                throw new Exception("clsEmployee::DeleteByField::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsEmployee> GetMissingAttendanceForToday(int empID, int choice)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetMissingAttendanceForToday]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@CHOICE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, choice));
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader3(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmployee::GetMissingAttendanceForToday::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        public List<clsEmployee> GetEmployeeEmailForAssetMovement(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetEmployeeEmailForAssetMovement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader6(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmployee::GetEmployeeEmailForAssetMovement::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        public List<clsEmployee> GetSkillAndContactsNotUpdated(int empID, int choice)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillAndContactsNotUpdated]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@CHOICE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, choice));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader4(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmployee::GetContactsNotUpdated::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public clsEmployee GetWorkPlaceAuditor(int empID, int choice)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWorkPlaceAuditor]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@CHOICE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, choice));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsEmployee businessObject = new clsEmployee();

                    PopulateBusinessObjectFromReader5(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmployee::GetGetWorkPlaceAuditor::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsEmployee businessObject, IDataReader dataReader)
        {


				businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMP_ID.ToString()));

				businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.LAST_NAME.ToString()));

				businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.FIRST_NAME.ToString()));

				

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.NICK_NAME.ToString())))
				{
					businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.NICK_NAME.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.BIRTHDATE.ToString())))
				{
					businessObject.BIRTHDATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.BIRTHDATE.ToString()));
				}

                //businessObject.POSITION = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.POSITION.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.DATE_HIRED.ToString())))
				{
					businessObject.DATE_HIRED = dataReader.GetDateTime(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.DATE_HIRED.ToString()));
				}
              
			
				businessObject.GRP_ID = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.GRP_ID.ToString()));
                
                if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.CEL_NO.ToString())))
                {
                    businessObject.CEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.CEL_NO.ToString()));
                }

                //if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.DEPT_ID.ToString())))
                //{
                //    businessObject.HOMEPHONE = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.DEPT_ID.ToString()));
                //}
                
            


                //if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.WS_EMP_ID.ToString())))
                //{
                //    businessObject.LOCAL = dataReader.GetInt32(dataReader.GetOrdinal(clsProfile.clsProfileFields.WS_EMP_ID.ToString()));
                //}

               


        }


        internal void PopulateBusinessObjectFromReader2(clsEmployee businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.NICK_NAME.ToString())))
            {
                businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.NICK_NAME.ToString()));
            }

            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMPLOYEE_NAME.ToString()));
        }

        internal void PopulateBusinessObjectFromReader3(clsEmployee businessObject, IDataReader dataReader)
        {
            businessObject.WEEK_DATE = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.WEEK_DATE.ToString()));

            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMPLOYEE_NAME.ToString()));

            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMAIL_ADDRESS.ToString()));

            businessObject.MANAGER_EMAIL = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.MANAGER_EMAIL.ToString()));
        }
        internal void PopulateBusinessObjectFromReader6(clsEmployee businessObject, IDataReader dataReader)
        {

            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMPLOYEE_NAME.ToString()));

            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMAIL_ADDRESS.ToString()));

            businessObject.MANAGER_EMAIL = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.MANAGER_EMAIL.ToString()));
        }
        internal void PopulateBusinessObjectFromReader4(clsEmployee businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMPLOYEE_NAME.ToString()));

            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMAIL_ADDRESS.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsEmployee</returns>
        internal List<clsEmployee> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsEmployee> list = new List<clsEmployee>();

            while (dataReader.Read())
            {
                clsEmployee businessObject = new clsEmployee();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        internal List<clsEmployee> PopulateObjectsFromReader2(IDataReader dataReader)
        {
            List<clsEmployee> list = new List<clsEmployee>();

            while (dataReader.Read())
            {
                clsEmployee businessObject = new clsEmployee();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsEmployee> PopulateObjectsFromReader3(IDataReader dataReader)
        {
            List<clsEmployee> list = new List<clsEmployee>();

            while (dataReader.Read())
            {
                clsEmployee businessObject = new clsEmployee();
                PopulateBusinessObjectFromReader3(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsEmployee> PopulateObjectsFromReader4(IDataReader dataReader)
        {
            List<clsEmployee> list = new List<clsEmployee>();

            while (dataReader.Read())
            {
                clsEmployee businessObject = new clsEmployee();
                PopulateBusinessObjectFromReader4(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader5(clsEmployee businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMPLOYEE_NAME.ToString()));
            businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsEmployee.clsEmployeeFields.EMAIL_ADDRESS.ToString()));
        }

        internal List<clsEmployee> PopulateObjectsFromReader6(IDataReader dataReader)
        {
            List<clsEmployee> list = new List<clsEmployee>();

            while (dataReader.Read())
            {
                clsEmployee businessObject = new clsEmployee();
                PopulateBusinessObjectFromReader6(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}
