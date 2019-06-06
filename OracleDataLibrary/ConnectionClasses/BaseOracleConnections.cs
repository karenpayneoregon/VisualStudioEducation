using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseConnectionLibrary.Interfaces;
using OracleDataLibrary.Classes;
using OracleDiagnostics;

namespace OracleDataLibrary.ConnectionClasses
{
    public enum OracleServerEnvironment { Development, Test };
    public class BaseOracleConnections : BaseExceptionsHandler
    {
        /// <summary>
        /// Represents an encrypted connection string to OCS dev server
        /// </summary>
        public string DevConnectionString => InternalDiagnostics.DecryptConnectionString(
            "Qscuv5aVJ4qOdpaw/3XgF6bvo1q3Sm3w4kFPc9zU5cT2fshizo+jOYocSedw2cWBIi9o7BTr8z4Vy1Txx99wldTC/ehkkTz43b2zAjFUr8Fy3PzZ33jjD2cR7p/G4meNeDHLuro4VKsNY5XIOZHqOkSD7J4YITNyXlHWI5WPcEiAdgYl3NsN3LX6pyjlqXHOVP7AUNlevFm6ZFMvakaQDAs1MVyDK6NTXUGVGii+fkY=");
        /// <summary>
        /// Represents an encrypted connection string to OCS test server
        /// </summary>
        public string TestConnectionString => InternalDiagnostics.DecryptConnectionString(
            "Qscuv5aVJ4qOdpaw/3XgF3F5EydGS8HSg2XekIUKuAMH3e013L5a8mYiDimy2MDi9bwYrtx3sYNOslGgAv9VrGkSClJsqUnJBWMn/bw2NgqGi4J1jTAjWfjBFrEm+SsJ0Mt2RFdfnMe5Y98P/zQWjKjUugB4PKCj8mj3//7CMR8s7yQh2NHMHrvQqVdZdzLMdSq4jG32u3ZE0Cw1U0fjrkvKluoiADXOBpbk+pR+gYw=");
        /// <summary>
        /// Dependent on the server pass in, provide a connection string for Oracle managed provider
        /// </summary>
        /// <param name="pEnvironment"></param>
        /// <returns></returns>
        public string ConnectionString(OracleServerEnvironment pEnvironment) // = OracleServerEnvironment.Development)
        {
            return pEnvironment == OracleServerEnvironment.Development ? DevConnectionString : TestConnectionString;
        }

    }
}
