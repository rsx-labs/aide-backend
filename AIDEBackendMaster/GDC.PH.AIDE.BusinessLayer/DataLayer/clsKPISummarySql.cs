using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class ClsKPISummarySql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public ClsKPISummarySql()
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
        public bool Insert(ClsKPISummary businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertKPISummary]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@FY_START", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_START));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_END", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_END));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_REF", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_REF));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_MONTH", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_TARGET", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_TARGET));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_ACTUAL", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_TARGET));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_OVERALL", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_TARGET));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_POSTED", SqlDbType.DateTime, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_POSTED));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPISummarySql:sp_InsertKPISummary:Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }


        /// <summary>
        /// Select all rescords By Month
        /// </summary>
        /// <returns>list of ClsKPITargets</returns>
        public List<ClsKPISummary> GetKPISummaryByMonth(ClsKPISummaryKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetKPITargetById]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@FY_START", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.FY_START));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_END", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.FY_END));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_MONTH", SqlDbType.SmallInt, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.Month));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPISummarySql::sp_GetKPITargetById::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords By Month
        /// </summary>
        /// <returns>list of ClsKPITargets</returns>
        public List<ClsKPISummary> GetAllKPISummary(ClsKPISummaryKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllKPISummary]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@FY_START", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.FY_START));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_END", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.FY_END));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPISummarySql::sp_GetAllKPISummary::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public bool Update(ClsKPISummary businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateKPISummary]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@KPI_REF", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_REF));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_MONTH", SqlDbType.SmallInt, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_FY_START", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_START));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_FY_END", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_END));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_TARGET", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_TARGET));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_ACTUAL", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_ACTUAL));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_OVERALL", SqlDbType.Float, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_OVERALL));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_POSTED", SqlDbType.DateTime, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_POSTED));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPISummarySql::Update::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(ClsKPISummary businessObject, IDataReader dataReader)
        {
            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.ID.ToString()));
            businessObject.FY_START = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.FY_START.ToString()));
            businessObject.FY_END = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.FY_END.ToString()));
            businessObject.KPI_MONTH = dataReader.GetInt16(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.KPI_MONTH.ToString()));
            businessObject.KPI_REF = dataReader.GetString(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.KPI_REF.ToString()));
            businessObject.SUBJECT = dataReader.GetString(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.SUBJECT.ToString()));
            businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.DESCRIPTION.ToString()));
            businessObject.KPI_TARGET = dataReader.GetDouble(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.KPI_TARGET.ToString()));
            businessObject.KPI_ACTUAL = dataReader.GetDouble(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.KPI_ACTUAL.ToString()));
            businessObject.KPI_OVERALL = dataReader.GetDouble(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.KPI_OVERALL.ToString()));
            businessObject.DATE_POSTED = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPISummary.ClsKPISummaryFields.DATE_POSTED.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of ClsKPISummary</returns>
        internal List<ClsKPISummary> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<ClsKPISummary> list = new List<ClsKPISummary>();

            while (dataReader.Read())
            {
                ClsKPISummary businessObject = new ClsKPISummary();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}

