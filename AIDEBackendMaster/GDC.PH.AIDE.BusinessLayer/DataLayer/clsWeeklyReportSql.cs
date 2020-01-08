using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsWeeklyReport
    /// </summary>
    class clsWeeklyReportSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsWeeklyReportSql()
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
        public bool Insert(clsWeeklyReport businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertWeeklyReport]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WR_RANGE_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_WEEK_RANGE_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@REWORK", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_REWORK));
                sqlCommand.Parameters.Add(new SqlParameter("@SUBJECT", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_SUBJECT));
                sqlCommand.Parameters.Add(new SqlParameter("@SEVERITY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_SEVERITY));
                sqlCommand.Parameters.Add(new SqlParameter("@INC_TYPE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_INC_TYPE));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PHASE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_PHASE));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_EFFORT_EST));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_WK", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_ACT_EFFORT_WK));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_ACT_EFFORT));
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_TASK_ID));
               
                if (businessObject.WR_REF_ID == null) 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                } 
                else 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_REF_ID));
                }

                if (businessObject.WR_DATE_STARTED == default(DateTime).Date) 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_STARTED));
                }

                if (businessObject.WR_DATE_TARGET == default(DateTime).Date) 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_TARGET", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_TARGET", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_TARGET));
                }

                if (businessObject.WR_DATE_FINISHED == default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_FINISHED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_FINISHED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_FINISHED));
                }

                if (businessObject.WR_COMMENTS == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.Text, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_COMMENTS));
                }

                if (businessObject.WR_INBOUND_CONTACTS == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INBOUND_CONTACTS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INBOUND_CONTACTS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_INBOUND_CONTACTS));
                }

                if (businessObject.WR_PROJ_CODE == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CODE", DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CODE", businessObject.WR_PROJ_CODE));
                }

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::Insert::Error occured.", ex);
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
        /// <param name="currentDate">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool InsertWeekRange(clsWeekRange businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertWeekRange]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CURRENT_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.StartWeek));
                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::InsertWeekRange::Error occured.", ex);
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
        /// <param name="currentDate">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool InsertWeeklyReportXref(clsWeekRange businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertWeeklyReportXref]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WEEK_RANGE", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WeekRangeID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EmpID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Status));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_SUBMITTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Date_Submitted));

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::InsertWeeklyReportXref::Error occured.", ex);
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
        public bool Update(clsWeeklyReport businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateWeeklyReport]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WR_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@WR_RANGE_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_WEEK_RANGE_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@REWORK", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_REWORK));
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_TASK_ID));
               
                if (businessObject.WR_REF_ID == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REF_ID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_REF_ID));
                }

                if (businessObject.WR_SUBJECT == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@SUBJECT", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@SUBJECT", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_SUBJECT));
                }

                sqlCommand.Parameters.Add(new SqlParameter("@SEVERITY", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_SEVERITY));
                sqlCommand.Parameters.Add(new SqlParameter("@INC_TYPE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_INC_TYPE));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PHASE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_PHASE));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_STATUS));

                if (businessObject.WR_DATE_STARTED == default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_STARTED));
                }

                if (businessObject.WR_DATE_TARGET == default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_TARGET", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_TARGET", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_TARGET));
                }

                if (businessObject.WR_DATE_FINISHED == default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_FINISHED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DATE_FINISHED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_DATE_FINISHED));
                }

                sqlCommand.Parameters.Add(new SqlParameter("@EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_EFFORT_EST));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_WK", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_ACT_EFFORT_WK));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_ACT_EFFORT));
                
                if (businessObject.WR_COMMENTS == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.Text, int.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_COMMENTS));
                }

                if (businessObject.WR_INBOUND_CONTACTS == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INBOUND_CONTACTS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INBOUND_CONTACTS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WR_INBOUND_CONTACTS));
                }

                if (businessObject.WR_PROJ_CODE == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CODE", DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PROJ_CODE", businessObject.WR_PROJ_CODE));
                }

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// delete row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsWeeklyReport businessObject, int weekID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_DeleteWeeklyReport]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WR_ID", businessObject.WR_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@WR_RANGE_ID", businessObject.WR_WEEK_RANGE_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", businessObject.WR_EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", businessObject.WR_TASK_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CURR_WEEK_ID", weekID));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::Delete::Error occured.", ex);
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
        /// <param name="currentDate">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool UpdateWeeklyReportXref(clsWeekRange businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateWeeklyReportXref]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WEEK_RANGE", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WeekRangeID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EmpID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Status));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_SUBMITTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Date_Submitted));

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyReport::UpdateWeeklyReportXref::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeekRange> GetWeekRange(DateTime currentDate, int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWeekRange]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CURRENT_DATE", currentDate));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForWeekRange(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeekRange::GetWeekRange::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeekRange> GetWeekRangeByMonthYear(int empID, int month, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWeekRangeByMonthYear]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForWeekRange(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeekRange::GetWeekRange::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeekRange> GetWeeklyReportsByEmpID(int empID, int month, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWeeklyReportsByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForWeeklyReports(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeekRange::GetWeekRange::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeeklyReport> GetWeeklyReportsByWeekRangeID(int weekRangeID, DateTime currentDate, int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWeeklyReportByWeekRangeAndEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WK_RANGE_ID", weekRangeID));
                sqlCommand.Parameters.Add(new SqlParameter("@CURRENT_DATE", currentDate));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeekRange::GetWeekRange::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeeklyReport> GetTasksDataByEmpID(int weekRangeID, int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetTasksDataByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@WK_RANGE_ID", weekRangeID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateTasksObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeekRange::GetWeekRange::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsWeeklyTeamStatusReport> GetWeeklyTeamStatusReport(int empID, int month, int year, int weekID, int entryType)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetWeeklyTeamStatusReport]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKID", weekID));
                sqlCommand.Parameters.Add(new SqlParameter("@ENTRYTYPE", entryType));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForWeeklyTeamStatusReport(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsWeeklyTeamStatus::GetWeeklyTeamStatusReport::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select all records
        /// </summary>
        /// <returns>list of clsTASKS</returns>
        public List<clsWeeklyReport> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllTasks]";
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
                throw new Exception("clsTASKS::SelectAll::Error occured.", ex);
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
        public List<clsWeeklyReport> SelectByPrimaryKey(int empId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getMyTasks]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empId));
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clstasks::SelectByPrimaryKey::Error occured.", ex);
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
        public bool Delete(clsWeeklyReportKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_TASKS_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                //sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.TASK_ID));

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsTASKS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_TASKS_DeleteByField]";
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
                throw new Exception("clsTASKS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsWeeklyReport businessObject, IDataReader dataReader)
        {
            businessObject.WR_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_ID.ToString()));
            businessObject.WR_WEEK_RANGE_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_WEEK_RANGE_ID.ToString()));
            businessObject.WR_PROJ_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_ID.ToString()));
            businessObject.WR_SUBJECT = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SUBJECT.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REWORK.ToString())))
            {
                businessObject.WR_REWORK = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REWORK.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REF_ID.ToString())))
            {
                businessObject.WR_REF_ID = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REF_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SEVERITY.ToString())))
            {
                businessObject.WR_SEVERITY = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SEVERITY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INC_TYPE.ToString())))
            {
                businessObject.WR_INC_TYPE = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INC_TYPE.ToString()));
            }

            businessObject.WR_EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PHASE.ToString())))
            {
                businessObject.WR_PHASE = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PHASE.ToString()));
            }

            businessObject.WR_STATUS = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_STATUS.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_STARTED.ToString())))
            {
                businessObject.WR_DATE_STARTED = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_STARTED.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_TARGET.ToString())))
            {
                businessObject.WR_DATE_TARGET = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_TARGET.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_FINISHED.ToString())))
            {
                businessObject.WR_DATE_FINISHED = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_FINISHED.ToString()));
            }

            businessObject.WR_EFFORT_EST = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_EFFORT_EST.ToString()));
            businessObject.WR_ACT_EFFORT = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_ACT_EFFORT.ToString()));
            businessObject.WR_ACT_EFFORT_WK = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_ACT_EFFORT_WK.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_COMMENTS.ToString())))
            {
                businessObject.WR_COMMENTS = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_COMMENTS.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INBOUND_CONTACTS.ToString())))
            {
                businessObject.WR_INBOUND_CONTACTS = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INBOUND_CONTACTS.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_CODE.ToString())))
            {
                businessObject.WR_PROJ_CODE = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_CODE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_TASK_ID.ToString())))
            {
                businessObject.WR_TASK_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_TASK_ID.ToString()));
            }
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessTasksObjectFromReader(clsWeeklyReport businessObject, IDataReader dataReader)
        {
            businessObject.WR_PROJ_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_ID.ToString()));
            businessObject.WR_SUBJECT = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SUBJECT.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REWORK.ToString())))
            {
                businessObject.WR_REWORK = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REWORK.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REF_ID.ToString())))
            {
                businessObject.WR_REF_ID = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_REF_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SEVERITY.ToString())))
            {
                businessObject.WR_SEVERITY = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_SEVERITY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INC_TYPE.ToString())))
            {
                businessObject.WR_INC_TYPE = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_INC_TYPE.ToString()));
            }

            businessObject.WR_EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PHASE.ToString())))
            {
                businessObject.WR_PHASE = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PHASE.ToString()));
            }

            businessObject.WR_STATUS = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_STATUS.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_STARTED.ToString())))
            {
                businessObject.WR_DATE_STARTED = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_STARTED.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_TARGET.ToString())))
            {
                businessObject.WR_DATE_TARGET = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_TARGET.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_FINISHED.ToString())))
            {
                businessObject.WR_DATE_FINISHED = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_DATE_FINISHED.ToString()));
            }

            businessObject.WR_EFFORT_EST = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_EFFORT_EST.ToString()));
            businessObject.WR_ACT_EFFORT = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_ACT_EFFORT.ToString()));
            businessObject.WR_ACT_EFFORT_WK = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_ACT_EFFORT_WK.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_COMMENTS.ToString())))
            {
                businessObject.WR_COMMENTS = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_COMMENTS.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_CODE.ToString())))
            {
                businessObject.WR_PROJ_CODE = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_PROJ_CODE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_TASK_ID.ToString())))
            {
                businessObject.WR_TASK_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyReport.clsWeeklyReportFields.WR_TASK_ID.ToString()));
            }
        }
        
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderForWeekRange(clsWeekRange businessObject, IDataReader dataReader)
        {
            businessObject.WeekRangeID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.WeekRangeID.ToString()));
            businessObject.StartWeek = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.StartWeek.ToString()));
            businessObject.EndWeek = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.EndWeek.ToString()));
            businessObject.DateRange = dataReader.GetString(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.DateRange.ToString()));
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderForWeeklyReports(clsWeekRange businessObject, IDataReader dataReader)
        {
            businessObject.WeekRangeID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.WeekRangeID.ToString()));
            businessObject.StartWeek = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.StartWeek.ToString()));
            businessObject.EndWeek = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.EndWeek.ToString()));
            businessObject.Status = dataReader.GetInt32(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.Status.ToString()));
            businessObject.Date_Submitted = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeekRange.clsWeekRangeFields.Date_Submitted.ToString()));
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderForWeeklyTeamStatusReport(clsWeeklyTeamStatusReport businessObject, IDataReader dataReader)
        {
            businessObject.WeekRangeID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.WeekRangeID.ToString()));
            businessObject.EmployeeID = dataReader.GetInt32(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.EmployeeID.ToString()));
            businessObject.EmployeeName = dataReader.GetString(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.EmployeeName.ToString()));
            businessObject.TotalHours = dataReader.GetDouble(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.TotalHours.ToString()));
            businessObject.Status = dataReader.GetInt16(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.Status.ToString()));
            businessObject.Date_Submitted = dataReader.GetDateTime(dataReader.GetOrdinal(clsWeeklyTeamStatusReport.clsWeeklyTeamStatusReportFields.Date_Submitted.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsWeeklyReport</returns>
        internal List<clsWeeklyReport> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsWeeklyReport> list = new List<clsWeeklyReport>();

            while (dataReader.Read())
            {
                clsWeeklyReport businessObject = new clsWeeklyReport();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsWeeklyReport> PopulateTasksObjectsFromReader(IDataReader dataReader)
        {
            List<clsWeeklyReport> list = new List<clsWeeklyReport>();

            while (dataReader.Read())
            {
                clsWeeklyReport businessObject = new clsWeeklyReport();
                PopulateBusinessTasksObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsWeekRange</returns>
        internal List<clsWeekRange> PopulateObjectsFromReaderForWeekRange(IDataReader dataReader)
        {
            List<clsWeekRange> list = new List<clsWeekRange>();

            while (dataReader.Read())
            {
                clsWeekRange businessObject = new clsWeekRange();
                PopulateBusinessObjectFromReaderForWeekRange(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsWeekRange</returns>
        internal List<clsWeekRange> PopulateObjectsFromReaderForWeeklyReports(IDataReader dataReader)
        {
            List<clsWeekRange> list = new List<clsWeekRange>();

            while (dataReader.Read())
            {
                clsWeekRange businessObject = new clsWeekRange();
                PopulateBusinessObjectFromReaderForWeeklyReports(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsWeeklyTeamStatusReport</returns>
        internal List<clsWeeklyTeamStatusReport> PopulateObjectsFromReaderForWeeklyTeamStatusReport(IDataReader dataReader)
        {
            List<clsWeeklyTeamStatusReport> list = new List<clsWeeklyTeamStatusReport>();

            while (dataReader.Read())
            {
                clsWeeklyTeamStatusReport businessObject = new clsWeeklyTeamStatusReport();
                PopulateBusinessObjectFromReaderForWeeklyTeamStatusReport(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
