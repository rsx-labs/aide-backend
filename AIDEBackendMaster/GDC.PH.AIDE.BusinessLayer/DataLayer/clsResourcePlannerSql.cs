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
    class clsResourcePlannerSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsResourcePlannerSql()
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
        /// 
        public bool InsertResourcePlanner(clsResourcePlanner businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAttendanceForManagers]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@from", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.from));
                sqlCommand.Parameters.Add(new SqlParameter("@to", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.to));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::Insert::Error occured.", ex);
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
        public bool UpdateResourcePlanner(clsResourcePlanner businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {               

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@from", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.from));
                sqlCommand.Parameters.Add(new SqlParameter("@to", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.to));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::UpdateResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> ViewEmpResourcePlanner(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetEmpResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::ViewEmpResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetStatusResourcePlanner(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetStatusResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetStatusResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //not in use
        public List<clsResourcePlanner> GetResourcePlannerByEmpID(int EMP_ID, int DEPT_ID, int MONTH, int YEAR)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetResourcePlannerByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DEPT_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DEPT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader3(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetResourcePlannerByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllEmpResourcePlanner(string email, int MONTH, int YEAR)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllEmpResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader4(dataReader);
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

        public List<clsResourcePlanner> GetAllEmpResourcePlannerByStatus(string email, int MONTH, int YEAR, int STATUS)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllEmpResourcePlannerByStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, STATUS));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader5(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllEmpResourcePlannerByStatus::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllStatusResourcePlanner()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllStatusResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader6(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllStatusResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetResourcePlanner(string email, int STATUS, int ToDisplay, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@ToDisplay", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ToDisplay));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader7(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetBillableHoursByMonth(int empID, int month, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBillableHoursByMonth]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year)); 
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader8(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetBillableHoursByMonth::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetBillableHoursByWeek(int empID, int weekID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBillableHoursByWeek]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKID", weekID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader8(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetBillableHoursByWeek::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetNonBillableHours(string email, int display, int month, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetNonBillableHours]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@DISPLAY", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, display));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReaderNonBillable(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetNonBillableHours::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllLeavesByEmployee(int empID, int leaveType, int statusCode)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllLeavesByEmployee]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@LEAVE_TYPE", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, leaveType));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_CODE", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, statusCode));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReaderLeaveList(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllLeavesByEmployee::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllLeavesHistoryByEmployee(int empID, int leaveType)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllLeavesHistoryByEmployee]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@LEAVE_TYPE", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, leaveType));
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReaderLeaveList(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllLeavesByEmployee::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateLeaves(clsResourcePlanner businessObject, int statusCD, int leaveType)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateLeaves]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@LEAVE_TYPE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, leaveType));
                sqlCommand.Parameters.Add(new SqlParameter("@START_DATE", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.START_DATE.ToString("MM/dd/yyyy")));
                sqlCommand.Parameters.Add(new SqlParameter("@END_DATE", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_DATE.ToString("MM/dd/yyyy")));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS_CD", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, statusCD));
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

        public List<clsResourcePlanner> GetAllPerfectAttendance(string email, int MONTH, int YEAR)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllPerfectAttendance]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader9(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllPerfectAttendance::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetLeavesByDateAndEmpID(int empID, int status,  DateTime dateFrom, DateTime dateTo)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetLeavesByDateAndEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", status));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_FROM", dateFrom));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_TO", dateTo));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader5(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetLeavesByDateAndEmpID::Error occured.", ex);
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
        internal void PopulateBusinessObjectRPFromReader(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.IMAGE_PATH.ToString())); 
        }

        internal void PopulateBusinessObjectRPFromReader2(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DESCR.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader3(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader4(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString())))
            {
                businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString())))
            {
                businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
            }
        }

        internal void PopulateBusinessObjectRPFromReader5(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader6(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DESCR.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader7(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
            businessObject.USEDLEAVES = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.USEDLEAVES.ToString()));
            businessObject.TOTALBALANCE = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.TOTALBALANCE.ToString()));
            businessObject.HALFBALANCE = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.HALFBALANCE.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader8(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader9(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
        }

        internal void PopulateObjectsRPFromReaderNonBillable(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.HOLIDAYHOURS = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.HOLIDAYHOURS.ToString()));
            businessObject.VLHOURS = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.VLHOURS.ToString()));
            businessObject.SLHOURS = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.SLHOURS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReaderLeaveList(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.START_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.START_DATE.ToString()));
            businessObject.END_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.END_DATE.ToString()));
            businessObject.DURATION = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DURATION.ToString()));
            businessObject.STATUS_CD = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS_CD.ToString()));
            businessObject.STATUS = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsStatus</returns>
        internal List<clsResourcePlanner> PopulateObjectsRPFromReader(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader2(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader3(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader3(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader4(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader4(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader5(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader5(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader6(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader6(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader7(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader7(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader8(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader8(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader9(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader9(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReaderNonBillable(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateObjectsRPFromReaderNonBillable(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReaderLeaveList(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReaderLeaveList(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
