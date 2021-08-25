using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core;
using WeatherApp.GetApi;

namespace WeatherApp.Handler
{
    public class HandlingData
    {
        private readonly WeatherAppContext _context;
        private readonly SqlConnection connection;
        private readonly GettingApi _api;

        public HandlingData()
        {
            _context = new WeatherAppContext();
            _api = new GettingApi();
            connection = (SqlConnection)_context.Database.Connection;
        }

        public async Task<bool> HandData()
        {
            var entity = _api.ApiCall();

            try
            {
                await connection.OpenAsync();

                SqlParameter Status = new SqlParameter("Status", entity.Weather[0].Main) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter Description = new SqlParameter("Description", entity.Weather[0].Description) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter Temperature = new SqlParameter("Temperature", entity.Main.Temp) { SqlDbType = SqlDbType.Float };
                SqlParameter HowTemperatureFeel = new SqlParameter("HowTemperatureFeel", entity.Main.Feels_Like) { SqlDbType = SqlDbType.Float };
                SqlParameter MinTemperature = new SqlParameter("MinTemperature", entity.Main.Temp_Min) { SqlDbType = SqlDbType.Float };
                SqlParameter MaxTemperature = new SqlParameter("MaxTemperature", entity.Main.Temp_Max) { SqlDbType = SqlDbType.Float };
                SqlParameter Humidity = new SqlParameter("Humidity", entity.Main.Humidity) { SqlDbType = SqlDbType.Float };
                SqlCommand command = new SqlCommand { Connection = connection, CommandType = CommandType.StoredProcedure, CommandText = $@"[dbo].[WeatherApp_Procedure]" };
                command.Parameters.Add(Status);
                command.Parameters.Add(Description);
                command.Parameters.Add(Temperature);
                command.Parameters.Add(HowTemperatureFeel);
                command.Parameters.Add(MinTemperature);
                command.Parameters.Add(MaxTemperature);
                command.Parameters.Add(Humidity);

                var result = await command.ExecuteNonQueryAsync();

                //var result = await _context.Database.ExecuteSqlCommandAsync($@"execute [dbo].[WeatherApp_Procedure] 
                //        @Status = @Status,
                //        @Description = @Description,
                //        @Temperature = @Temperature,
                //        @HowTemperatureFeel = @HowTemperatureFeel,
                //        @MinTemperature = @MinTemperature,
                //        @MaxTemperature = @MaxTemperature,
                //        @Humidity = @Humidity",
                //      Status, Description, Temperature, HowTemperatureFeel, MinTemperature, MaxTemperature, Humidity
                //    );

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
