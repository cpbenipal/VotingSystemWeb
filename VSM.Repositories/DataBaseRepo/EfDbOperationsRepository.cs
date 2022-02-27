
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using VSM.Model;

namespace VSM.Repositories.DataBaseRepo
{
    public class EfDbOperationsRepository
    {
        private readonly string connectionString;

        public EfDbOperationsRepository(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        #region Public methods
        public async Task<string> ExecuteDataSetAsync(string storedProcedureName,
         List<SqlParameterModel> sqlParameters = null)
        {
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;

            return await ExecuteDataSet(command, sqlParameters);

        }
        public string ExecuteDtblAsync(string storedProcedureName,
        List<SqlParameterModel> sqlParameters = null)
        {
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;

            return ExecuteDataTable(command, sqlParameters);
        }
        public async Task<T> ExecuteNonQueryAsync<T>(string storedProcedureName,
            string identityName,
            List<SqlParameterModel> sqlParameters = null)
        {
            SqlCommand command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName
            };

            return await ExecuteNonQuery<T>(command, identityName, sqlParameters);
        }

        public async Task ExecuteNonQueryAsync(string storedProcedureName,
            List<SqlParameterModel> sqlParameters = null)
        {
            SqlCommand command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName
            };

            await ExecuteNonQueryAsync(command, sqlParameters);
        }
        #endregion

        #region Private methods

        private async Task<string> ExecuteDataSet(SqlCommand command,
            List<SqlParameterModel> sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.Clear();

                    if (sqlParameters != null)
                    {
                        foreach (var param in sqlParameters)
                        {
                            if (param.Value == null)
                                command.Parameters.AddWithValue($"@{param.Name}", param.Type).Value = DBNull.Value;
                            else
                                command.Parameters.AddWithValue($"@{param.Name}", param.Type).Value = param.Value;
                            if (param.IsOutput)
                            {
                                command.Parameters[$"@{param.Name}"].Direction = ParameterDirection.Output;
                            }
                        }
                    }

                    command.Connection.Open();

                    var jsonResult = new System.Text.StringBuilder();
                    var reader = await command.ExecuteReaderAsync();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    { 
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        } 
                    }

                    command.Connection.Close();
                    return jsonResult.ToString();
                }
            }
        }

        private string ExecuteDataTable(SqlCommand command,
            List<SqlParameterModel> SQLParams)
        {

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (command)
                {

                    command.Connection = connection;
                    command.Parameters.Clear();

                    if (SQLParams != null)
                    {
                        if (SQLParams != null)
                        {
                            foreach (var param in SQLParams)
                            {
                                command.Parameters.AddWithValue($"@{param.Name}", param.Type).Value = param.Value;
                                if (param.IsOutput)
                                {
                                    command.Parameters[$"@{param.Name}"].Direction = ParameterDirection.Output;
                                }
                            }
                        }
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(dataTable);
                    }

                }
            }
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonResources = JsonConvert.SerializeObject(dataTable, settings);

            return jsonResources;

        }

        private async Task<T> ExecuteNonQuery<T>(SqlCommand command,
            string identityName,
            List<SqlParameterModel> sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.Clear();
                    if (sqlParameters != null)
                    {
                        foreach (var param in sqlParameters)
                        {
                            command.Parameters.AddWithValue($"@{param.Name}", param.Type).Value = param.Value;
                            if (param.IsOutput)
                            {
                                command.Parameters[$"@{param.Name}"].Direction = ParameterDirection.Output;
                            }
                        }
                    }

                    command.Parameters.Add($"@{identityName}", SqlDbType.Int).Direction = ParameterDirection.Output; // TODO: Fix the hard code  SqlDbType.Int type
                    await command.ExecuteNonQueryAsync();
                    T id = (T)(command.Parameters[$"@{identityName}"].Value);
                    return id;
                }
            }
        }

        private async Task ExecuteNonQueryAsync(SqlCommand command,
           List<SqlParameterModel> sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.Clear();
                    if (sqlParameters != null)
                    {
                        foreach (var param in sqlParameters)
                        {
                            command.Parameters.AddWithValue($"@{param.Name}", param.Type).Value = param.Value;
                            if (param.IsOutput)
                            {
                                command.Parameters[$"@{param.Name}"].Direction = ParameterDirection.Output;
                            }
                        }
                    }
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

    }
}