using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

////////////////////////////////////////////////
//AEVAN CAMILLE BATONGBACAL / JHUNELL BARCENAS//
///////////////////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class clsCommendationsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public clsCommendationsSql()
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
        public bool InsertCommendations(clsCommendations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertCommendations]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMPLOYEE));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJECT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJECT));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_SENT", SqlDbType.Date, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_SENT));
                sqlCommand.Parameters.Add(new SqlParameter("@SENT_BY", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SENT_BY));
                sqlCommand.Parameters.Add(new SqlParameter("@REASON", SqlDbType.Text, int.MaxValue, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REASON));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsCommendations:sp_InsertCommendation:Error occured.", ex);
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
        public bool UpdateCommendations(clsCommendations businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateCommendations]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@COMMEND_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMMEND_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMPLOYEE));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJECT", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJECT));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_SENT", SqlDbType.Date, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_SENT));
                sqlCommand.Parameters.Add(new SqlParameter("@SENT_BY", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SENT_BY));
                sqlCommand.Parameters.Add(new SqlParameter("@REASON", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REASON));

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
        public List<clsCommendations> GetCommendations(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetCommendations]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsCommendations::sp_GetCommendations::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsCommendations> GetCommendationsBySearch(int empID, int month, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetCommendationsBySearch]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsCommendations::GetCommendationsBySearch::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsCommendations businessObject, IDataReader dataReader)
        {
            businessObject.COMMEND_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.COMMEND_ID.ToString()));
            businessObject.EMPLOYEE = dataReader.GetString(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.EMPLOYEE.ToString()));
            businessObject.PROJECT = dataReader.GetString(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.PROJECT.ToString()));
            businessObject.DATE_SENT = dataReader.GetDateTime(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.DATE_SENT.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.SENT_BY.ToString())))
            {
                businessObject.SENT_BY = dataReader.GetString(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.SENT_BY.ToString()));
            }
            else
            {
                businessObject.SENT_BY = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.REASON.ToString())))
            {
                businessObject.REASON = dataReader.GetString(dataReader.GetOrdinal(clsCommendations.clsCommendationsFields.REASON.ToString()));
            }
            else
            {
                businessObject.REASON = String.Empty;
            }
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsCommendations> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsCommendations> list = new List<clsCommendations>();

            while (dataReader.Read())
            {
                clsCommendations businessObject = new clsCommendations();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
