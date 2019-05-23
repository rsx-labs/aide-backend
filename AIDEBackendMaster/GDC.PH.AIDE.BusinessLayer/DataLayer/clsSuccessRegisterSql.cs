using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Data access layer class for clsContacts
/// By Aevan Camille Batongbacal
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsSuccessRegisterSql : DataLayerBase
    {
        #region "Constructor"

        public clsSuccessRegisterSql()
        {
        }

        #endregion

        #region "Public Methods"

        public bool InsertSuccessRegister(clsSuccessRegister businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertNewSuccessRegister]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@WHOSINVOLVE", businessObject.WHOSINVOLVE));
                sqlCommand.Parameters.Add(new SqlParameter("@ADDITIONALINFORMATION", businessObject.ADDITIONALINFORMATION));
                sqlCommand.Parameters.Add(new SqlParameter("@DETAILSOFSUCCESS", businessObject.DETAILSOFSUCCESS));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_INPUT", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_INPUT));
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::InsertSuccessRegister::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsNickname> getNicknameByDeptID(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetNicknameByDeptID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;


            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForNickname(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::getNicknameByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsSuccessRegister> getSuccessRegisterAll(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetSuccessRegisterAll]";
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
                throw new Exception("clsSuccessRegister::getSuccessregisterAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsSuccessRegister> getSuccessRegisterByEmpID(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetSuccessRegisterByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;


            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
                
            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::getSuccessregisterByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsSuccessRegister> getSuccessRegisterBySearch(string input, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetSuccessRegisterBySearch]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;


            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@input", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, input));
                sqlCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);
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

        public bool UpdateSuccessRegister(clsSuccessRegister businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_UpdateSuccessRegister]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SUCCESS_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@WHOSINVOLVE", businessObject.WHOSINVOLVE));
                sqlCommand.Parameters.Add(new SqlParameter("@ADDITIONALINFORMATION", businessObject.ADDITIONALINFORMATION));
                sqlCommand.Parameters.Add(new SqlParameter("@DETAILSOFSUCCESS", businessObject.DETAILSOFSUCCESS));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_INPUT", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_INPUT));
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::updateSuccessRegister::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool DeleteSuccessRegister(int successID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_DeleteSuccessRegister]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, successID));
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::deleteSuccessRegister::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        #endregion

        #region "Private Methods"
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsSuccessRegister businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.EMP_ID.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DEPT_ID.ToString())))
            {
                businessObject.DEPT_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DEPT_ID.ToString()));                
            }
            else
            {
                businessObject.DEPT_ID = 0;
            }

            businessObject.SUCCESS_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.ID.ToString()));
            businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.NICK_NAME.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DATE_INPUT.ToString())))
            {
                businessObject.DATE_INPUT = dataReader.GetDateTime(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DATE_INPUT.ToString()));
            }
            else
            {
                businessObject.DATE_INPUT = DateTime.Today;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DETAILSOFSUCCESS.ToString())))
            {
                businessObject.DETAILSOFSUCCESS = dataReader.GetString(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.DETAILSOFSUCCESS.ToString()));
            }
            else
            {
                businessObject.DETAILSOFSUCCESS = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.WHOSINVOLVE.ToString())))
            {
                businessObject.WHOSINVOLVE = dataReader.GetString(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.WHOSINVOLVE.ToString()));
            }
            else
            {
                businessObject.WHOSINVOLVE = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.ADDITIONALINFORMATION.ToString())))
            {
                businessObject.ADDITIONALINFORMATION = dataReader.GetString(dataReader.GetOrdinal(clsSuccessRegister.clsSuccessRegisterFields.ADDITIONALINFORMATION.ToString()));
            }
            else
            {
                businessObject.ADDITIONALINFORMATION = String.Empty;
            }


        }

        internal List<clsSuccessRegister> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsSuccessRegister> list = new List<clsSuccessRegister>();

            while (dataReader.Read())
            {
                clsSuccessRegister businessObject = new clsSuccessRegister();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }


        internal void PopulateBusinessObjectFromReaderForNickname(clsNickname businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsNickname.clsNicknameFields.EMP_ID.ToString()));
            businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsNickname.clsNicknameFields.NICK_NAME.ToString()));
            
        }

        internal List<clsNickname> PopulateObjectsFromReaderForNickname(IDataReader dataReader)
        {
            List<clsNickname> list = new List<clsNickname>();

            while (dataReader.Read())
            {
                clsNickname businessObject = new clsNickname();
                PopulateBusinessObjectFromReaderForNickname(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }


        #endregion
    }
}
