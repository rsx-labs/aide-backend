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
    class ClsKPITargetsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public ClsKPITargetsSql()
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
        public bool InsertKPITargets(ClsKPITargets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertKPITargets]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@FY_START", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_START));
                sqlCommand.Parameters.Add(new SqlParameter("@FY_END", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FY_END));
                sqlCommand.Parameters.Add(new SqlParameter("@KPI_REF", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KPI_REF));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@SUBJECT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SUBJECT));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_CREATED", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_CREATED));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPITargetsSql:sp_InsertKPITargets:Error occured.", ex);
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
        /// <returns>list of ClsKPITargets</returns>
        public List<ClsKPITargets> GetKPITargetById(int id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetKPITargetById]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPITargetsSql::sp_GetKPITargetById::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<ClsKPITargets> GetKPITargetByFiscalYear(DateTime fyear)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetKPITargetByFiscalYear]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@FYEAR", SqlDbType.Date, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, fyear));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPITargetsSql::sp_GetKPITargetByFiscalYear::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public bool Update(ClsKPITargets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateKPITargets]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SUBJECT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SUBJECT));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ClsKPITargetsSql::Update::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(ClsKPITargets businessObject, IDataReader dataReader)
        {
            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.ID.ToString()));
            businessObject.FY_START = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.FY_START.ToString()));
            businessObject.FY_END = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.FY_END.ToString()));
            businessObject.KPI_REF = dataReader.GetString(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.KPI_REF.ToString()));
            businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.DESCRIPTION.ToString()));
            businessObject.SUBJECT = dataReader.GetString(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.SUBJECT.ToString()));
            businessObject.DATE_CREATED = dataReader.GetDateTime(dataReader.GetOrdinal(ClsKPITargets.ClsKPITargetsFields.DATE_CREATED.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of ClsKPITargets</returns>
        internal List<ClsKPITargets> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<ClsKPITargets> list = new List<ClsKPITargets>();

            while (dataReader.Read())
            {
                ClsKPITargets businessObject = new ClsKPITargets();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}

