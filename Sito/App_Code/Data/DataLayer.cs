using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Mercenari.Data
{
    public class DataLayer
    {

        private IDbConnection _conn = null;
        private IDbCommand _command = null;

        private string _connString = Business.ConstWrapper.NomeConnessione;

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
        public System.Data.IDataReader GetDataReader(string sqlString)
        {

            _command = this.CreateCommand();

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
        public System.Data.IDataReader GetDataReader(IDbCommand dbCommand)
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

        public IDataParameter CreatePar(string ParamName, object ParamValue)
        {
            switch (Business.ConstWrapper.ConnectionType)
            {
                case "SqlServer":
                    return new SqlParameter(ParamName, ParamValue);

                case "OleDb":
                    return new OleDbParameter(ParamName, ParamValue);

                default:
                    throw new Exception("No ConnectionType initialized");
            }
        }
    }
}
