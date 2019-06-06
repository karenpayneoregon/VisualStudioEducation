using System;
using Oracle.ManagedDataAccess.Client;
using OracleDataLibrary.Classes;
using OracleDataLibrary.ConnectionClasses;


namespace OracleDataLibrary.DataClasses
{
    public class DataOperations : BaseOracleConnections
    {
        /// <summary>
        /// For demo purpose we are hard wired to dev environment
        /// </summary>
        public static OracleServerEnvironment DatabaseServer = OracleServerEnvironment.Development;
        public OracleServerEnvironment DatabaseEnvironment { get; set; }
        public OcsMessage GetOcsMessage(decimal pIndentifier, string pLanguage)
        {
            mHasException = false; // reset property

            var result = new OcsMessage();

            // one exceptions to using a parameter
            var selectStatement =
                "SELECT OCS_MESSAGE_TXT,OCS_LANG_CODE,OCS_FORM_FIELD_NAME,OCS_FORM_FIELD_ORDER FROM OCS_MESSAGES " +
                $"WHERE id = {pIndentifier}";

            using (var cn = new OracleConnection() { ConnectionString = ConnectionString(DatabaseEnvironment) })
            {
                using (var cmd = new OracleCommand() { Connection = cn })
                {
                    cmd.CommandText = selectStatement;
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        reader.Read();

                        result.Id = pIndentifier;
                        result.MessageText = reader.GetString(0);
                        result.LanguageCode = reader.GetString(1);
                        result.FormFieldName = reader.GetString(2);
                        result.FormFieldOrder = reader.GetInt32(3);

                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }
                }
            }

            return result;

        }

    }
}
