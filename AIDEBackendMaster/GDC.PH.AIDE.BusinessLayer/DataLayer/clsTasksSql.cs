using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsTASKS
    /// </summary>
    class clsTasksSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsTasksSql()
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
        public bool Insert(clsTasks businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertTasks]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TASK_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 11, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                
                if (businessObject.INC_ID == null )
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INC_ID", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INC_ID", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.INC_ID));
                }

                sqlCommand.Parameters.Add(new SqlParameter("@TASK_TYPE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TASK_TYPE));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@INC_DESCR", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.INC_DESCR));

                if (businessObject.TASK_DESCR == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@TASK_DESCR", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@TASK_DESCR", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TASK_DESCR));
                }

                if (businessObject.REMARKS == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REMARKS", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REMARKS", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REMARKS));
                }

                sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_STARTED));


                if (businessObject.TARGET_DATE ==  default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@TARGET_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@TARGET_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TARGET_DATE));
                }


                if (businessObject.COMPLTD_DATE ==  default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMPLTD_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMPLTD_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMPLTD_DATE));
                }

                sqlCommand.Parameters.Add(new SqlParameter("@DATE_CREATED", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_CREATED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

                if (businessObject.EFFORT_EST == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EFFORT_EST));
                }

                if (businessObject.ACT_EFFORT_EST_WK == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST_WK", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST_WK", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_EFFORT_EST_WK));
                }

                if (businessObject.ACT_EFFORT_EST == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_EFFORT_EST));
                }
               
                sqlCommand.Parameters.Add(new SqlParameter("@PROJECT_CODE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJECT_CODE));
                sqlCommand.Parameters.Add(new SqlParameter("@REWORK", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REWORK));
                sqlCommand.Parameters.Add(new SqlParameter("@PHASE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PHASE));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsTASKS::Insert::Error occured.", ex);
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
        public bool Update(clsTasks businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_updateTasksStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TASKS_ID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TASK_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TARGET_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TARGET_DATE));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

                if (businessObject.COMPLTD_DATE == default(DateTime).Date)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMPLTD_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@COMPLTD_DATE", SqlDbType.Date, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMPLTD_DATE));
                }
                
                sqlCommand.Parameters.Add(new SqlParameter("@EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EFFORT_EST));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_EFFORT_EST));
                sqlCommand.Parameters.Add(new SqlParameter("@ACT_EFFORT_EST_WK", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_EFFORT_EST_WK));
                
                if (businessObject.INC_DESCR == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INC_DESCR", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@INC_DESCR", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.INC_DESCR));
                }

                if (businessObject.REMARKS == null)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REMARKS", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@REMARKS", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REMARKS));
                }
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsTASKS::Update::Error occured.", ex);
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
        /// <returns>list of clsTASKS</returns>
        public List<clsTasks> SelectAll()
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
        public List<clsTasks> SelectByPrimaryKey(int empId)
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
        public bool Delete(clsTasksKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_TASKS_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.TASK_ID));

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

        public List<clsTasks_sp> getTaskSummaryAll(DateTime dateStart, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetTasksSummaryAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@DATENOW", dateStart));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForStoredProcedure(dataReader);
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

        public List<clsTasks_sp> getTaskSummaryByEmpId(int empID, DateTime dateStart)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetTasksSummaryByEmpId]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATENOW", dateStart));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForStoredProcedure(dataReader);
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

        public List<clsTasks> getTaskSummaryWeekly(int empID, DateTime dateStart)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_TaskSummaryWeekly]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_STARTED", dateStart));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
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

        public clsTasks getTaskDetailByTaskId(clsTasksKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getTaskDetailByTaskId]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@TASK_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.TASK_ID));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsTasks businessObject = new clsTasks();

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
                throw new Exception("clsTASKS::SelectByPrimaryKey::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }


        public List<clsTasks> GetTaskDetailByIncidentId(int empID)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetTaskDetailByIncidentId]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::GetSkillsProfByEmpID::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsTasks businessObject, IDataReader dataReader)
        {
            businessObject.TASK_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TASK_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsTasks.clsTASKSFields.EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.INC_ID.ToString())))
            {
                businessObject.INC_ID = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.INC_ID.ToString()));
            }

            businessObject.TASK_TYPE = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TASK_TYPE.ToString()));
            businessObject.PROJ_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsTasks.clsTASKSFields.PROJ_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.INC_DESCR.ToString())))
            {
                businessObject.INC_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.INC_DESCR.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TASK_DESCR.ToString())))
            {
                businessObject.TASK_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TASK_DESCR.ToString()));
            }

            businessObject.DATE_STARTED = dataReader.GetDateTime(dataReader.GetOrdinal(clsTasks.clsTASKSFields.DATE_STARTED.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TARGET_DATE.ToString())))
            {
                businessObject.TARGET_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsTasks.clsTASKSFields.TARGET_DATE.ToString()));
            }

            

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.COMPLTD_DATE.ToString())))
            {
                businessObject.COMPLTD_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsTasks.clsTASKSFields.COMPLTD_DATE.ToString()));
            }

            businessObject.DATE_CREATED = dataReader.GetDateTime(dataReader.GetOrdinal(clsTasks.clsTASKSFields.DATE_CREATED.ToString()));
            businessObject.STATUS = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsTasks.clsTASKSFields.STATUS.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.REMARKS.ToString())))
            {
                businessObject.REMARKS = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.REMARKS.ToString()));
            }

            businessObject.EFFORT_EST = dataReader.GetDouble(dataReader.GetOrdinal(clsTasks.clsTASKSFields.EFFORT_EST.ToString()));
            businessObject.ACT_EFFORT_EST = dataReader.GetDouble(dataReader.GetOrdinal(clsTasks.clsTASKSFields.ACT_EFFORT_EST.ToString()));
            businessObject.ACT_EFFORT_EST_WK = dataReader.GetDouble(dataReader.GetOrdinal(clsTasks.clsTASKSFields.ACT_EFFORT_EST_WK.ToString()));
            businessObject.PROJECT_CODE = dataReader.GetInt32(dataReader.GetOrdinal(clsTasks.clsTASKSFields.PROJECT_CODE.ToString()));
            businessObject.REWORK = dataReader.GetInt16(dataReader.GetOrdinal(clsTasks.clsTASKSFields.REWORK.ToString()));
            businessObject.PHASE = dataReader.GetInt16(dataReader.GetOrdinal(clsTasks.clsTASKSFields.PHASE.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_2.ToString())))
            {
                businessObject.OTHERS_1 = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_1.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_2.ToString())))
            {
                businessObject.OTHERS_2 = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_2.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_3.ToString())))
            {
                businessObject.OTHERS_3 = dataReader.GetString(dataReader.GetOrdinal(clsTasks.clsTASKSFields.OTHERS_3.ToString()));
            }
        }

        internal void PopulateBusinessObjectFromReaderForStoredProcedure(clsTasks_sp bO, IDataReader dR)
        {
            if (!dR.IsDBNull(dR.GetOrdinal(clsTasks.clsTasks_spFields.EmployeeName.ToString())))
            {
                bO.EmployeeName = dR.GetString(dR.GetOrdinal(clsTasks.clsTasks_spFields.EmployeeName.ToString()));
            }

            bO.LastWeekOutstanding = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.LastWeekOutstanding.ToString()));

            bO.Mon_AT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Mon_AT.ToString()));
            bO.Mon_CT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Mon_CT.ToString()));
            bO.Mon_OT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Mon_OT.ToString()));

            bO.Tue_AT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Tue_AT.ToString()));
            bO.Tue_CT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Tue_CT.ToString()));
            bO.Tue_OT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Tue_OT.ToString()));

            bO.Wed_AT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Wed_AT.ToString()));
            bO.Wed_CT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Wed_CT.ToString()));
            bO.Wed_OT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Wed_OT.ToString()));

            bO.Thu_AT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Thu_AT.ToString()));
            bO.Thu_CT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Thu_CT.ToString()));
            bO.Thu_OT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Thu_OT.ToString()));

            bO.Fri_AT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Fri_AT.ToString()));
            bO.Fri_CT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Fri_CT.ToString()));
            bO.Fri_OT = dR.GetInt32(dR.GetOrdinal(clsTasks.clsTasks_spFields.Fri_OT.ToString()));
        }

        
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsTASKS</returns>
        internal List<clsTasks> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsTasks> list = new List<clsTasks>();

            while (dataReader.Read())
            {
                clsTasks businessObject = new clsTasks();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsTasks_sp> PopulateObjectsFromReaderForStoredProcedure(IDataReader dR)
        {
            List<clsTasks_sp> list = new List<clsTasks_sp>();

            while (dR.Read())
            {
                clsTasks_sp bO = new clsTasks_sp();
                PopulateBusinessObjectFromReaderForStoredProcedure(bO, dR);
                list.Add(bO);
            }
            return list;
        }
        #endregion
    }
}
