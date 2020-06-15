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
    /// Data access layer class for clsContacts
    /// </summary>
    class clsComcellSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsComcellSql>
        public clsComcellSql()
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
        public bool InsertComcellMeeting(clsComcell businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertComcellMeeting]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@FACILITATOR", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FACILITATOR));
                sqlCommand.Parameters.Add(new SqlParameter("@MINUTES_TAKER", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MINUTES_TAKER));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEK", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEK));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsComcell:sp_InsertComcellMeeting:Error occured.", ex);
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
        public bool UpdateComcellMeeting(clsComcell businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateComcellMeeting]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@COMCELL_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMCELL_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@FACILITATOR", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FACILITATOR));
                sqlCommand.Parameters.Add(new SqlParameter("@MINUTES_TAKER", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MINUTES_TAKER));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEK", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.WEEK));

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
        public List<clsComcell> GetComcellMeeting(int empID, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetComcellMeeting]";
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
                throw new Exception("clsComcell::sp_GetComcellMeeting::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsComcell businessObject, IDataReader dataReader)
        {
            businessObject.COMCELL_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsComcell.clsComcellFields.COMCELL_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsComcell.clsComcellFields.EMP_ID.ToString()));
            businessObject.MONTH = dataReader.GetString(dataReader.GetOrdinal(clsComcell.clsComcellFields.MONTH.ToString()));
            businessObject.FACILITATOR = dataReader.GetString(dataReader.GetOrdinal(clsComcell.clsComcellFields.FACILITATOR.ToString()));
            businessObject.MINUTES_TAKER = dataReader.GetString(dataReader.GetOrdinal(clsComcell.clsComcellFields.MINUTES_TAKER.ToString()));
            businessObject.FY_START = dataReader.GetDateTime(dataReader.GetOrdinal(clsComcell.clsComcellFields.FY_START.ToString()));
            businessObject.FY_END = dataReader.GetDateTime(dataReader.GetOrdinal(clsComcell.clsComcellFields.FY_END.ToString()));
            businessObject.FACILITATOR_NAME = dataReader.GetString(dataReader.GetOrdinal(clsComcell.clsComcellFields.FAC_NAME.ToString()));
            businessObject.MINUTES_TAKER_NAME = dataReader.GetString(dataReader.GetOrdinal(clsComcell.clsComcellFields.MIN_NAME.ToString()));
            try
            {
                businessObject.WEEK = dataReader.GetInt32(dataReader.GetOrdinal(clsComcell.clsComcellFields.WEEK.ToString()));
                businessObject.WEEK_START = dataReader.GetDateTime(dataReader.GetOrdinal(clsComcell.clsComcellFields.WEEK_START.ToString()));
            }
            catch(Exception ex)
            {
                businessObject.WEEK = 0;
            }
            
            
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsComcell> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsComcell> list = new List<clsComcell>();

            while (dataReader.Read())
            {
                clsComcell businessObject = new clsComcell();
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
