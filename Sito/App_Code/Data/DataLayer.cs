using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Data
{
    public class DataLayer
    {

        private IDbConnection _conn;
        private IDbCommand _command;

        private readonly string _connString = Business.ConstWrapper.NomeConnessione;

        public DataLayer()
        {
            _conn = Conn;
        }


        /// <summary>
        /// Connection to Database, connection string readed by Config.
        /// </summary>
        private IDbConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    switch (Business.ConstWrapper.ConnectionType)
                    {
                        case "SqlServer":

                            _conn = new SqlConnection(_connString);

                            // _conn.Open();
                            return _conn;

                        case "OleDb":
                            _conn = new OleDbConnection(_connString);
                            return _conn;

                        default:

                            throw new Exception("No ConnectionType initialized");


                    }

                }
                else
                {
                    if (_conn.State == ConnectionState.Closed)
                    {
                        _conn.Open();
                    }
                    return _conn;
                }
            }
        }

        public IDbCommand CreateCommand()
        {

            switch (Business.ConstWrapper.ConnectionType)
            {
                case "SqlServer":
                    _command = new SqlCommand();
                    return _command;

                case "OleDb":
                    _command = new OleDbCommand();
                    return _command;

                default:
                    throw new Exception("No ConnectionType initialized");
            }


        }


        /// <summary>
        /// Execute Sql Statement and retrieve an IDataReader
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public IDataReader GetDataReader(string sqlString)
        {

            _command = CreateCommand();

            using (_command)
            {
                _command.CommandText = sqlString;
                return GetDataReader(_command);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public IDataReader GetDataReader(IDbCommand dbCommand)
        {
            using (dbCommand)
            {
                dbCommand.Connection = Conn;
                return dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public int Execute(string sqlString)
        {

            _command = CreateCommand();

            using (_command)
            {
                _command.CommandText = sqlString;
                return Execute(_command);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public int Execute(IDbCommand dbCommand)
        {
            try
            {
                using (dbCommand)
                {
                    dbCommand.Connection = Conn;
                    return dbCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                Conn.Close();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public int ExecuteGetId(string sqlString)
        {

            _command = CreateCommand();

            using (_command)
            {
                _command.CommandText = sqlString;
                return ExecuteGetId(_command);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public int ExecuteGetId(IDbCommand dbCommand)
        {

            try
            {
                using (dbCommand)
                {
                    dbCommand.Connection = Conn;
                    if (dbCommand.ExecuteNonQuery() > 0)
                    {
                        // specific for sqlLite TODO
                        dbCommand.CommandText = "SELECT @@IDENTITY as Id;";
                        return int.Parse(dbCommand.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            finally { Conn.Close(); }
        }

        public object ExecuteScalar(string sqlString)
        {

            using (_command)
            {
                _command.CommandText = sqlString;
                return ExecuteScalar(_command);
            }
        }

        public object ExecuteScalar(IDbCommand dbCommand)
        {

            try
            {
                using (dbCommand)
                {
                    dbCommand.Connection = Conn;
                    return dbCommand.ExecuteScalar();
                }
            }
            finally { Conn.Close(); }
        }

        public IDataParameter CreatePar(string paramName, object paramValue)
        {
            switch (Business.ConstWrapper.ConnectionType)
            {
                case "SqlServer":
                    return new SqlParameter(paramName, paramValue);

                case "OleDb":
                    return new OleDbParameter(paramName, paramValue);

                default:
                    throw new Exception("No ConnectionType initialized");
            }
        }
    }
}
