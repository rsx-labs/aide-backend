using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class clsBirthdaySql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsBirthdaySql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsBirthday> SelectAll(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBirthdayListAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsBirthday::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all records by month
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsBirthday> SelectByMonth(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBirthdayListAllByMonth]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsBirthday::SelectByMonth::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all records by day
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsBirthday> SelectByDay(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBirthdayListAllByDay]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsBirthday::SelectByDay::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsBirthday businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.EMP_ID.ToString()));

            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.FIRST_NAME.ToString()));
            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.LAST_NAME.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.IMAGE_PATH.ToString())))
            {
                businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.IMAGE_PATH.ToString()));
            }
            else
            {
                businessObject.IMAGE_PATH = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.BIRTHDATE.ToString())))
            {
                businessObject.BIRTHDAY = dataReader.GetDateTime(dataReader.GetOrdinal(clsBirthday.clsBirthdayFields.BIRTHDATE.ToString()));
            }
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsBirthday> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsBirthday> list = new List<clsBirthday>();

            while (dataReader.Read())
            {
                clsBirthday businessObject = new clsBirthday();
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
