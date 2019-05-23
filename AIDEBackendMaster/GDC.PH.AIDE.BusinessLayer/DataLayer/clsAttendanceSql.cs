using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
using GDC.PH.AIDE.BusinessLayer;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsAttendance
	/// </summary>
	class clsAttendanceSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public clsAttendanceSql()
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
		public bool Insert(clsAttendance businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAttendance]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
	
                MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                
				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("clsAttendance::Insert::Error occured.", ex);
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
        public bool Update(clsAttendance businessObject, int day, int status)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_updateAttendanceStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@Day", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(day)));
                sqlCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(status)));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool Update(clsAttendance businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_updateAttendanceStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY1", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY1));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY2", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY2));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY3", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY3));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY4", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY4));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY5", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY5));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY6", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY6));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY7", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY7));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY8", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY8));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY9", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY9));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY10", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY10));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY11", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY11));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY12", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY12));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY13", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY13));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY14", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY14));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY15", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY15));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY16", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY16));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY17", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY17));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY18", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY18));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY19", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY19));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY20", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY20));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY21", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY21));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY22", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY22));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY23", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY23));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY24", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY24));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY25", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY25));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY26", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY26));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY27", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY27));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY28", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY28));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY29", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY29));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY30", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY30));
                sqlCommand.Parameters.Add(new SqlParameter("@DAY31", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAY31));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::Update::Error occured.", ex);
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
        /// <returns>clsAttendance business object</returns>
        public clsAttendance SelectByPrimaryKey(clsAttendanceKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_ATTENDANCE_SelectByPrimaryKey]";
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
                    clsAttendance businessObject = new clsAttendance();

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
                throw new Exception("clsAttendance::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of clsAttendance</returns>
        public List<clsAttendance> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_ATTENDANCE_SelectAll]";
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
                throw new Exception("clsAttendance::SelectAll::Error occured.", ex);
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
        /// <returns>list of clsAttendance</returns>
        public List<clsAttendance> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_ATTENDANCE_SelectByField]";
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
                throw new Exception("clsAttendance::SelectByField::Error occured.", ex);
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
        public bool Delete(clsAttendanceKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_ATTENDANCE_DeleteByPrimaryKey]";
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
                throw new Exception("clsAttendance::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_ATTENDANCE_DeleteByField]";
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
                throw new Exception("clsAttendance::DeleteByField::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select by monthly for all
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsAttendance business object</returns>
        public List<clsAttendance> SelectByMonthly(clsAttendanceKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_attendanceMonthly]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.YEAR));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::SelectByMonthly::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select by weekly for emloyee
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsAttendance business object</returns>
        public List<clsAttendance> SelectByWeekly(int empId, DateTime weekOf)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_attendanceWeekly]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empId));
                sqlCommand.Parameters.Add(new SqlParameter("@DATENOW", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, weekOf));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::SelectByMonthly::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public List<clsAttendance> GetAttendanceToday(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAttendanceToday]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email)); 
                
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader3(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::GetAttendanceToday::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsAttendance businessObject, IDataReader dataReader)
        {


				businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMP_ID.ToString()));

                businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMPLOYEE_NAME.ToString()));
            
                businessObject.MONTH = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.MONTH.ToString()));

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.YEAR.ToString())))
                {
                    businessObject.YEAR = dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.YEAR.ToString()));
                }

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY1.ToString())))
				{
					businessObject.DAY1 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY1.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY2.ToString())))
				{
					businessObject.DAY2 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY2.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY3.ToString())))
				{
					businessObject.DAY3 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY3.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY4.ToString())))
				{
					businessObject.DAY4 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY4.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY5.ToString())))
				{
					businessObject.DAY5 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY5.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY6.ToString())))
				{
					businessObject.DAY6 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY6.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY7.ToString())))
				{
					businessObject.DAY7 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY7.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY8.ToString())))
				{
					businessObject.DAY8 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY8.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY9.ToString())))
				{
					businessObject.DAY9 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY9.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY10.ToString())))
				{
					businessObject.DAY10 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY10.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY11.ToString())))
				{
					businessObject.DAY11 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY11.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY12.ToString())))
				{
					businessObject.DAY12 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY12.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY13.ToString())))
				{
					businessObject.DAY13 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY13.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY14.ToString())))
				{
					businessObject.DAY14 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY14.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY15.ToString())))
				{
					businessObject.DAY15 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY15.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY16.ToString())))
				{
					businessObject.DAY16 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY16.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY17.ToString())))
				{
					businessObject.DAY17 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY17.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY18.ToString())))
				{
					businessObject.DAY18 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY18.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY19.ToString())))
				{
					businessObject.DAY19 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY19.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY20.ToString())))
				{
					businessObject.DAY20 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY20.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY21.ToString())))
				{
					businessObject.DAY21 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY21.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY22.ToString())))
				{
					businessObject.DAY22 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY22.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY23.ToString())))
				{
					businessObject.DAY23 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY23.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY24.ToString())))
				{
					businessObject.DAY24 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY24.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY25.ToString())))
				{
					businessObject.DAY25 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY25.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY26.ToString())))
				{
					businessObject.DAY26 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY26.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY27.ToString())))
				{
					businessObject.DAY27 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY27.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY28.ToString())))
				{
					businessObject.DAY28 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY28.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY29.ToString())))
				{
					businessObject.DAY29 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY29.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY30.ToString())))
				{
					businessObject.DAY30 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY30.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY31.ToString())))
				{
					businessObject.DAY31 = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DAY31.ToString()));
				}


        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader2(clsAttendance businessObject, IDataReader dataReader)
        {


            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMP_ID.ToString()));

            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMPLOYEE_NAME.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.MONDAY.ToString())))
            {
                businessObject.MONDAY = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.MONDAY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.TUESDAY.ToString())))
            {
                businessObject.TUESDAY = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.TUESDAY.ToString()));
            }


            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.WEDNESDAY.ToString())))
            {
                businessObject.WEDNESDAY = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.WEDNESDAY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.THURSDAY.ToString())))
            {
                businessObject.THURSDAY = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.THURSDAY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.FRIDAY.ToString())))
            {
                businessObject.FRIDAY = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(clsAttendance.clsAttendanceFieldsWeekly.FRIDAY.ToString()));
            }

        }


        internal void PopulateBusinessObjectFromReader3(clsAttendance businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.EMPLOYEE_NAME.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DESCR.ToString()));
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.STATUS.ToString()));
            businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsAttendance.clsAttendanceFields.IMAGE_PATH.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAttendance</returns>
        internal List<clsAttendance> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsAttendance> list = new List<clsAttendance>();

            while (dataReader.Read())
            {
                clsAttendance businessObject = new clsAttendance();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAttendance</returns>
        internal List<clsAttendance> PopulateObjectsFromReader2(IDataReader dataReader)
        {

            List<clsAttendance> list = new List<clsAttendance>();

            while (dataReader.Read())
            {
                clsAttendance businessObject = new clsAttendance();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        internal List<clsAttendance> PopulateObjectsFromReader3(IDataReader dataReader)
        {

            List<clsAttendance> list = new List<clsAttendance>();

            while (dataReader.Read())
            {
                clsAttendance businessObject = new clsAttendance();
                PopulateBusinessObjectFromReader3(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion



    }
}
  