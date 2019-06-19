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
    class clsAnnouncementsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public clsAnnouncementsSql()
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
        public bool InsertAnnouncements(clsAnnouncements businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAnnouncement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                //sqlCommand.Parameters.Add(new SqlParameter("@COMMEND_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMMEND_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MESSAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@END_DATE", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_DATE));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAnnouncements:sp_InsertAnnouncement:Error occured.", ex);
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
        public List<clsAnnouncements> GetAnnouncements(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAnnouncements]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

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

        public bool Update(clsAnnouncements businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAnnouncement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ANNOUNCEMENT_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ANNOUNCEMENT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MESSAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@END_DATE", SqlDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_DATE));
                

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAnnouncements::Update::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsAnnouncements businessObject, IDataReader dataReader)
        {
            businessObject.ANNOUNCEMENT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAnnouncements.clsAnnouncementsFields.ANNOUNCEMENT_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAnnouncements.clsAnnouncementsFields.EMP_ID.ToString()));
            businessObject.MESSAGE = dataReader.GetString(dataReader.GetOrdinal(clsAnnouncements.clsAnnouncementsFields.MESSAGE.ToString()));
            businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(clsAnnouncements.clsAnnouncementsFields.TITLE.ToString()));
            businessObject.END_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsAnnouncements.clsAnnouncementsFields.END_DATE.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsAnnouncements> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsAnnouncements> list = new List<clsAnnouncements>();

            while (dataReader.Read())
            {
                clsAnnouncements businessObject = new clsAnnouncements();
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
