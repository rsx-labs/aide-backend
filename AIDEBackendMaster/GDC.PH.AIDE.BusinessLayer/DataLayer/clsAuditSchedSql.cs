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
    /// Data access layer class for clsAuditSched
    /// </summary>
    class clsAuditSchedSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsAuditSchedSql>
        public clsAuditSchedSql()
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
        public bool InsertAuditSched(clsAuditSched businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAuditSched]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_START", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_START));
                sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_END", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_END));
                sqlCommand.Parameters.Add(new SqlParameter("@DAILY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAILY));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEKLY));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTHLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTHLY));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));

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
                sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_START", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_START));
                sqlCommand.Parameters.Add(new SqlParameter("@PERIOD_END", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PERIOD_END));
                sqlCommand.Parameters.Add(new SqlParameter("@DAILY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DAILY));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEKLY));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTHLY", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTHLY));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));
                
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
        /// <returns>list of clsContacts</returns>
        public List<clsAuditSched> GetAuditSched(int empID, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAuditSched]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAuditSched::sp_GetAuditSched::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsAuditSched businessObject, IDataReader dataReader)
        {
            businessObject.AUDIT_SCHED_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.AUDIT_SCHED_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.EMP_ID.ToString()));
            businessObject.FY_WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.FY_WEEK.ToString()));
            businessObject.PERIOD_START = dataReader.GetDateTime(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.PERIOD_START.ToString()));
            businessObject.PERIOD_END = dataReader.GetDateTime(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.PERIOD_END.ToString()));
            businessObject.DAILY = dataReader.GetString(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.DAILY.ToString()));
            businessObject.WEEKLY = dataReader.GetString(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.WEEKLY.ToString()));
            businessObject.MONTHLY = dataReader.GetString(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.MONTHLY.ToString()));
            businessObject.FY_START = dataReader.GetDateTime(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.FY_START.ToString()));
            businessObject.FY_END = dataReader.GetDateTime(dataReader.GetOrdinal(clsAuditSched.clsAuditSchedFields.FY_END.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsAuditSched> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsAuditSched> list = new List<clsAuditSched>();

            while (dataReader.Read())
            {
                clsAuditSched businessObject = new clsAuditSched();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
