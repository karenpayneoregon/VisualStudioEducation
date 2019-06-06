using System;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace OracleDataLibrary.Classes
{
    public class BaseExceptionsHandler
    {
        protected static bool mHasException;
        /// <summary> 
        /// Indicate the last operation thrown an  
        /// exception or not 
        /// </summary> 
        /// <returns></returns> 
        public bool HasException
        {
            get
            {
                return mHasException;
            }
        }
        /// <summary>
        /// Represents the exception thrown in a derived class
        /// </summary>
        protected static Exception mLastException;
        /// <summary>
        /// Represents an SQL-Server exception 
        /// </summary>
        /// <remarks>Check <see cref="HasSqlServerException"></see> first</remarks>
        public SqlException SqlServerException => (SqlException)mLastException;
        /// <summary>
        /// Indicates if there was a sql related exception and if 
        /// so <see cref="SqlServerException"></see> will contain the exception.
        /// </summary>
        public bool HasSqlServerException
        {
            get
            {
                if (LastException != null)
                {
                    return LastException is SqlException;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Indicator if the last exception thrown was from Oracle. 
        /// If so then <see cref="OracleException"></see> will contain the exception.
        /// </summary>
        public bool HasOracleException
        {
            get
            {
                if (LastException != null)
                {
                    return LastException is OracleException;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Returns an Oracle exception. Check <see cref="HasOracleException"></see> first.
        /// </summary>
        public OracleException OracleException => (OracleException)mLastException;
        /// <summary> 
        /// Provides access to the last exception thrown.
        /// </summary> 
        /// <returns></returns> 
        public Exception LastException => mLastException;
        /// <summary> 
        /// If you don't need the entire exception as in  
        /// LastException this provides just the text of the exception 
        /// </summary> 
        /// <returns></returns> 
        public string LastExceptionMessage => mLastException.Message;

        /// <summary> 
        /// Indicate for return of a function if there was an exception thrown or not. 
        /// </summary> 
        /// <returns></returns> 
        public bool IsSuccessFul => !mHasException;
    }
}
