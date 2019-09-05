using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsComcellClockSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsComcellClockSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        public bool Update(clsComcellClock businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateComcellClock]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CLOCK_DAY", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CLOCK_DAY));
                sqlCommand.Parameters.Add(new SqlParameter("@CLOCK_HOUR", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CLOCK_HOUR));
                sqlCommand.Parameters.Add(new SqlParameter("@CLOCK_MINUTE", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CLOCK_MINUTE));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MIDDAY", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MIDDAY));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsComcellClock::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public clsComcellClock SelectClockByEmpID(clsComcellClockKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetComcellClockInfo]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {             
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.EMP_ID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    clsComcellClock businessObject = new clsComcellClock();

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
                throw new Exception("clsComcellClock::SelectClockByEmpID::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsComcellClock businessObject, IDataReader dataReader)
        {
            businessObject.CLOCK_DAY = dataReader.GetInt32(dataReader.GetOrdinal(clsComcellClock.clsComcellClockFields.CLOCK_DAY.ToString()));
            businessObject.CLOCK_HOUR = dataReader.GetInt32(dataReader.GetOrdinal(clsComcellClock.clsComcellClockFields.CLOCK_HOUR.ToString()));
            businessObject.CLOCK_MINUTE = dataReader.GetInt32(dataReader.GetOrdinal(clsComcellClock.clsComcellClockFields.CLOCK_MINUTE.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsComcellClock.clsComcellClockFields.EMP_ID.ToString()));
            businessObject.MIDDAY = dataReader.GetString(dataReader.GetOrdinal(clsComcellClock.clsComcellClockFields.MIDDAY.ToString()));
        }


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsComcellClock> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsComcellClock> list = new List<clsComcellClock>();

            while (dataReader.Read())
            {
                clsComcellClock businessObject = new clsComcellClock();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
