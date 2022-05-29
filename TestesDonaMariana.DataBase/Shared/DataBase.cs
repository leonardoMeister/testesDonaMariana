﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TestesDonaMariana.DataBase.Shared
{
    public delegate T ConverterDelegate<T>(IDataReader reader);
    public static class DataBase
    {
        private static readonly string connectionString;
        private static readonly string nomeProvider;
        private static readonly SqlConnection conection;

        static DataBase()
        {
            connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;
                                Initial Catalog=TestesDonaMarianaDB;
                                Integrated Security=True;
                                Pooling=False";

            nomeProvider = "System.Data.SqlClient";

            conection = new SqlConnection(connectionString);
        }

        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql.AppendSelectIdentity();
                    command.Connection = connection;
                    command.SetParameters(parameters);

                    connection.Open();

                    int id = Convert.ToInt32(command.ExecuteScalar());

                    return id;
                }
            }
        }

        public static void Update(string sql, Dictionary<string, object> parameters = null)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }

        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    var list = new List<T>();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = convert(reader);
                            list.Add(obj);
                        }

                        return list;
                    }
                }
            }
        }


        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    T t = default;

                    using (IDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                            t = convert(reader);

                        return t;
                    }
                }
            }
        }

        public static void InsertNoReturn(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Connection = connection;
                    command.SetParameters(parameters);

                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
            }
        }

        public static bool Exists(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = conection)
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = conection.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    int numberRows = Convert.ToInt32(command.ExecuteScalar());

                    return numberRows > 0;
                }
            }
        }

        private static void SetParameters(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                string name = parameter.Key;

                object value = parameter.Value.IsNullOrEmpty() ? DBNull.Value : parameter.Value;

                IDataParameter dbParameter = command.CreateParameter();

                dbParameter.ParameterName = name;
                dbParameter.Value = value;

                command.Parameters.Add(dbParameter);
            }
        }

        private static string AppendSelectIdentity(this string sql)
        {
            switch (nomeProvider)
            {
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";

                case "System.Data.SQLite": return sql + ";SELECT LAST_INSERT_ROWID()";

                default: return sql;
            }
        }

        public static bool IsNullOrEmpty(this object value)
        {
            return (value is string && string.IsNullOrEmpty((string)value)) ||
                    value == null;
        }
    }
}
