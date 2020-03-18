using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{/// <summary>
    /// BY GIANN CARLO CAMILO
    /// </summary>
    class clsProfileSql : DataLayerBase
    {
        #region Constructor
        public clsProfileSql()
        {

        }

        #endregion

        #region Public Methods
        public clsProfile getProfile(clsProfileKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_getProfile]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {


                sqlCommand.Parameters.Add(new SqlParameter("@empID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.EMP_ID));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsProfile businessObject = new clsProfile();

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
                throw new Exception("clsProfile::getProfile::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public clsProfile getProfileByEmailAddress(string emailAddress)
        
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_getProfileByEmail]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, emailAddress));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsProfile businessObject = new clsProfile();
                   //
                    PopulateBusinessObjectFromReader(businessObject, dataReader);
                   //
                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
             String mess=   ex.Message;
                throw new Exception("clsProfile::getProfile::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public bool UpdateProfile(clsProfile businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_updateProfile]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                //sqlCommand.Parameters.Add(new SqlParameter("@IMGPATH", businessObject.IMAGE_PATH));
                //sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                //sqlCommand.Parameters.Add(new SqlParameter("@CEL_NO", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CEL_NO));
                //sqlCommand.Parameters.Add(new SqlParameter("@HOMEPHONE", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPHONE));
                //sqlCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCATION));
                //sqlCommand.Parameters.Add(new SqlParameter("@LOCAL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LOCAL));
                //sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADD2", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMAIL_ADDRESS2));
                //sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                //sqlCommand.Parameters.Add(new SqlParameter("@DATEREVIEWED", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DT_REVIEWED));
                //MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProfile::updateProfile::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsProfile businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProfile.clsProfileFields.EMP_ID.ToString()));

            businessObject.WS_EMP_ID = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.WS_EMP_ID.ToString()));

            businessObject.DEPT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProfile.clsProfileFields.DEPT_ID.ToString()));

            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.LAST_NAME.ToString()));

            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.FIRST_NAME.ToString()));

            //MIDDLENAME
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.MIDDLE_NAME.ToString())))
            {
                businessObject.MIDDLE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.MIDDLE_NAME.ToString()));
            }
            else
            {
                businessObject.MIDDLE_NAME = String.Empty;
            }

            //NICKNAME
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.NICK_NAME.ToString())))
            {
                businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.NICK_NAME.ToString()));
            }
            else
            {
                businessObject.NICK_NAME = String.Empty;
            }

            //BIRTHDATE
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.BIRTHDATE.ToString())))
            {
                businessObject.BIRTHDATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsProfile.clsProfileFields.BIRTHDATE.ToString()));
            }
            else
            {
                businessObject.BIRTHDATE = DateTime.Today;
            }

            //DATEHIRED
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.DATE_HIRED.ToString())))
            {
                businessObject.DATE_HIRED = dataReader.GetDateTime(dataReader.GetOrdinal(clsProfile.clsProfileFields.DATE_HIRED.ToString()));
            }
            else
            {
                businessObject.DATE_HIRED = DateTime.Today;
            }
        
            //IMAGE_PATH
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.IMAGE_PATH.ToString())))
            {
                businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.IMAGE_PATH.ToString()));
            }
            else
            {
                businessObject.IMAGE_PATH = String.Empty;
            }

            //DEPARTMENT
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.DEPARTMENT.ToString())))
            {
                businessObject.DEPARTMENT = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.DEPARTMENT.ToString()));
            }
            else
            {
                businessObject.DEPARTMENT = string.Empty;
            }

            //DIVISION
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.DIVISION.ToString())))
            {
                businessObject.DIVISION = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.DIVISION.ToString()));
            }
            else
            {
                businessObject.DIVISION = string.Empty;
            }

            //POSITION
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.POSITION.ToString())))
            {
                businessObject.POSITION = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.POSITION.ToString()));
            }
            else
            {
                businessObject.POSITION = string.Empty;
            }

            //EMAIL_ADDRESS
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.EMAIL_ADDRESS.ToString())))
            {
                businessObject.EMAIL_ADDRESS = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.EMAIL_ADDRESS.ToString()));
            }
            else
            {
                businessObject.EMAIL_ADDRESS = string.Empty;
            }

            //EMAIL_ADDRESS2
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.EMAIL_ADDRESS2.ToString())))
            {
                businessObject.EMAIL_ADDRESS2 = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.EMAIL_ADDRESS2.ToString()));
            }
            else
            {
                businessObject.EMAIL_ADDRESS2 = string.Empty;
            }

            //LOCATION
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.LOCATION.ToString())))
            {
                businessObject.LOCATION = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.LOCATION.ToString()));
            }
            else
            {
                businessObject.LOCATION = string.Empty;
            }

            //CEL_NO
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.CEL_NO.ToString())))
            {
                businessObject.CEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.CEL_NO.ToString()));
            }
            else
            {
                businessObject.CEL_NO = string.Empty;
            }

            //LOCAL
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.LOCAL.ToString())))
            {
                businessObject.LOCAL = dataReader.GetInt32(dataReader.GetOrdinal(clsProfile.clsProfileFields.LOCAL.ToString()));
            }
            else
            {
                businessObject.LOCAL = 0;
            }

            //HOMEPHONE
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.HOMEPHONE.ToString())))
            {
                businessObject.HOMEPHONE = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.HOMEPHONE.ToString()));
            }
            else
            {
                businessObject.HOMEPHONE = string.Empty;
            }

            //OTHERPHONE
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.OTHER_PHONE.ToString())))
            {
                businessObject.OTHER_PHONE = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.OTHER_PHONE.ToString()));
            }
            else
            {
                businessObject.OTHER_PHONE = string.Empty;
            }

            //DT_REVIEWED
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.DT_REVIEWED.ToString())))
            {
                businessObject.DT_REVIEWED = dataReader.GetDateTime(dataReader.GetOrdinal(clsProfile.clsProfileFields.DT_REVIEWED.ToString()));
            }
            else
            {
                businessObject.DT_REVIEWED = DateTime.Now;
            }

            //PERMISSION
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.Permission.ToString())))
            {
                businessObject.PERMISSION = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.Permission.ToString()));
            }
            else
            {
                businessObject.PERMISSION = string.Empty;
            }

            businessObject.PERMISSION_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsProfile.clsProfileFields.PERMISSION_ID.ToString()));

            //CIVILSTATUS
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.CivilStatus.ToString())))
            {
                businessObject.CIVILSTATUS = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.CivilStatus.ToString()));
            }
            else
            {
                businessObject.CIVILSTATUS = string.Empty;
            }

            //SHIFTSTATUS
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsProfile.clsProfileFields.SHIFT_STATUS.ToString())))
            {
                businessObject.SHIFT_STATUS = dataReader.GetString(dataReader.GetOrdinal(clsProfile.clsProfileFields.SHIFT_STATUS.ToString()));
            }
            else
            {
                businessObject.SHIFT_STATUS = string.Empty;
            }
        }
        #endregion
    }
}
