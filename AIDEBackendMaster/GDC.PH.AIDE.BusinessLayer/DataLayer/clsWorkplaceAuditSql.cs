using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsWorkplaceAuditSql
    /// </summary>
    class clsWorkplaceAuditSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsWorkplaceAuditSql>
        public clsWorkplaceAuditSql()
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
        public bool InsertAuditDaily(clsWorkplaceAudit businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAuditDaily]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_QUESTIONS_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUDIT_QUESTIONS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_WEEK", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_WEEK));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_CHECKED", SqlDbType.DateTime, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_CHECKED));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched:sp_InsertAuditSched:Error occured.", ex);
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
        /// 
        public bool UpdateAuditSched(clsAuditSched businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAuditSched]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_SCHED_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUDIT_SCHED_ID));
                //sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_START", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_START));
                //sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_END", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_END));
                sqlCommand.Parameters.Add(new SqlParameter("@DAILY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAILY));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEKLY));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTHLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTHLY));
                //sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));

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
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsWorkplaceAudit</returns>
        public List<clsWorkplaceAudit> GetAuditDaily(int empID, DateTime parmDate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAuditDaily]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, parmDate));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
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
        /// <returns>list of clsWorkplaceAudit</returns>
        public List<clsWorkplaceAudit> GetAuditQuestions(int empID, string questionGroup)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getAuditQuestion]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@QUESTION_GROUP", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, questionGroup));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        /// <summary>
        /// Select records daily auditor this week
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="parmDateRange"></param>
        /// <returns></returns>
        public List<clsWorkplaceAudit> GetDailyAuditorByWeek(int empID, string paramFYWeek, DateTime paramdate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getDailyAuditorByWeek]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_WEEK", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, paramFYWeek));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE", SqlDbType.Date, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, paramdate));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderDailyAuditorByWeek(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        
               public List<clsWorkplaceAudit> GetMonthlyAuditor(int empID, int paramDate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getMonthlyAuditor]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@date ", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, paramDate));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderWeeklyAuditor(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<clsWorkplaceAudit> GetQuarterlyAuditor(int empID, int paramDate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getQuarterlyAuditor]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@date ", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, paramDate));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderWeeklyAuditor(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<clsWorkplaceAudit> GetWeeklyAuditor(int empID, DateTime paramDate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getWeeklyAuditor]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@date ", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, paramDate));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderWeeklyAuditor(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        /// <summary>
        /// Get Daily audit question
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="parmDateRange"></param>
        /// <returns></returns>
        public bool UpdateCheckAuditQuestionStatus(clsWorkplaceAudit businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[UpdateCheckAuditQuestionStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@DT_CHECK_FLG", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_CHECK_FLG));
                sqlCommand.Parameters.Add(new SqlParameter("@DT_CHECKED", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_CHECKED));
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_QUESTIONS_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUDIT_QUESTIONS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_WEEK", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_WEEK));
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_DAILY_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUDIT_DAILY_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKDATE", SqlDbType.Date, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEKDATE));
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_GROUP_QUESTION", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUDIT_QUESTIONS_GROUP));
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
        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsWorkplaceAudit businessObject, IDataReader dataReader)
        {
            businessObject.AUDIT_DAILY_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_DAILY_ID.ToString()));
            businessObject.AUDIT_QUESTIONS_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_QUESTIONS_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.EMP_ID.ToString()));
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.FY_WEEK.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.STATUS.ToString()));
            businessObject.DT_CHECKED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECKED.ToString()));
        }
        internal void PopulateObjectsFromReaderAudtiSchedMonth(clsWorkplaceAudit businessObject, IDataReader dataReader)
        {
            businessObject.AUDITSCHED_MONTH = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDITSCHED_MONTH.ToString()));
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.FY_WEEK.ToString()));
        }
        internal void PopulateBusinessObjectFromReaderDailyAuditorByWeek(clsWorkplaceAudit businessObject, IDataReader dataReader)
        {
            businessObject.WEEKDAYS = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDAYS.ToString()));
            businessObject.NICKNAME = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.NICKNAME.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.EMP_ID.ToString()));
            businessObject.WEEKDATE = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDATE.ToString()));
            businessObject.DT_CHECK_FLG = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECK_FLG.ToString()));
            businessObject.WEEKDATESCHED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDATESCHED.ToString()));
            
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DATE_CHECKED.ToString())))
            {
                businessObject.DATE_CHECKED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DATE_CHECKED.ToString()));
            }
            else
            {
                businessObject.DATE_CHECKED = "NULL";
            }
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.FY_WEEK.ToString()));
        }
        internal void PopulateBusinessObjectFromReaderWeeklyAuditor(clsWorkplaceAudit businessObject, IDataReader dataReader)
        {
            businessObject.WEEKDAYS = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDAYS.ToString()));
            businessObject.NICKNAME = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.NICKNAME.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.EMP_ID.ToString()));
            businessObject.WEEKDATE = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDATE.ToString()));
            businessObject.DT_CHECK_FLG = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECK_FLG.ToString()));
            businessObject.WEEKDATESCHED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDATESCHED.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DATE_CHECKED.ToString())))
            {
                businessObject.DATE_CHECKED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DATE_CHECKED.ToString()));
            }
            else
            {
                businessObject.DATE_CHECKED = "NULL";
            }
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.FY_WEEK.ToString()));
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader2(clsWorkplaceAudit businessObject, IDataReader dataReader)
        {
            //businessObject.AUDIT_QUESTIONS_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_QUESTIONS_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.EMP_ID.ToString()));
            businessObject.AUDIT_QUESTIONS = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_QUESTIONS.ToString()));
            businessObject.OWNER = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.OWNER.ToString()));
            businessObject.AUDIT_QUESTIONS_GROUP = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_QUESTIONS_GROUP.ToString()));
           
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECKED.ToString())))
            {
                businessObject.DT_CHECKED = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECKED.ToString()));
            }
            else
            {
                businessObject.DT_CHECKED = "NULL";
            }
            businessObject.DT_CHECK_FLG = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.DT_CHECK_FLG.ToString()));
            businessObject.AUDIT_QUESTIONS_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_QUESTIONS_ID.ToString()));
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.FY_WEEK.ToString()));
            businessObject.WEEKDATE = dataReader.GetString(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.WEEKDATE.ToString()));
            businessObject.AUDIT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsWorkplaceAudit.clsWorkplaceAuditFields.AUDIT_ID.ToString()));
        }
    


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsWorkplaceAudit> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsWorkplaceAudit> list = new List<clsWorkplaceAudit>();

            while (dataReader.Read())
            {
                clsWorkplaceAudit businessObject = new clsWorkplaceAudit();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        internal List<clsWorkplaceAudit> PopulateObjectsFromReaderDailyAuditorByWeek(IDataReader dataReader)
        {
            List<clsWorkplaceAudit> list = new List<clsWorkplaceAudit>();

            while (dataReader.Read())
            {
                clsWorkplaceAudit businessObject = new clsWorkplaceAudit();
                PopulateBusinessObjectFromReaderDailyAuditorByWeek(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        internal List<clsWorkplaceAudit> PopulateObjectsFromReaderWeeklyAuditor(IDataReader dataReader)
        {
            List<clsWorkplaceAudit> list = new List<clsWorkplaceAudit>();

            while (dataReader.Read())
            {
                clsWorkplaceAudit businessObject = new clsWorkplaceAudit();
                PopulateBusinessObjectFromReaderDailyAuditorByWeek(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        internal List<clsWorkplaceAudit> PopulateObjectsFromReaderAudtiSchedMonth(IDataReader dataReader)
        {
            List<clsWorkplaceAudit> list = new List<clsWorkplaceAudit>();

            while (dataReader.Read())
            {
                clsWorkplaceAudit businessObject = new clsWorkplaceAudit();
                PopulateObjectsFromReaderAudtiSchedMonth(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsWorkplaceAudit> PopulateObjectsFromReader2(IDataReader dataReader)
        {
            List<clsWorkplaceAudit> list = new List<clsWorkplaceAudit>();

            while (dataReader.Read())
            {
                clsWorkplaceAudit businessObject = new clsWorkplaceAudit();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

        #region Audti Sched Per Month SELECTION
        public List<clsWorkplaceAudit> GetAuditSChed_Month(int AUDIT_GROUP_ID, int yr , int month)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getAuditSChedByMonth]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@AUDIT_GROUP_ID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, AUDIT_GROUP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, yr));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, month));
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderAudtiSchedMonth(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsWorkplaceAudit::clsWorkplaceAudit::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion



    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
