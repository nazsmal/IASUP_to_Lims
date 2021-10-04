using System;
using Microsoft.Data.SqlClient;
using NLog;
using NLog.Web;

namespace IASUP_to_Lims.Services
{
    public static class SqlQuery
    {
        public static void Update(string connectionString)
        {
            var logger = LogManager.Setup()
                                .LoadConfigurationFromAppSettings()
                                .GetCurrentClassLogger();
            try
            {
                string Update = "integration.sp_IasupToLims";
                using SqlConnection connection = new(connectionString);
                connection.Open();
                SqlCommand command = new(Update, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                int number = command.ExecuteNonQuery();
                logger.Info("Обновлено объектов: {0}", number);
                connection.Close();
            }
            catch (Exception)
            {
                logger.Error("Запрос не выполнен");
            }          
        }
        public static void Clear_IasupToLimsUsers(string connectionString)
        {
            var logger = LogManager.Setup()
                                .LoadConfigurationFromAppSettings()
                                .GetCurrentClassLogger();
            try
            {
                string ClearTable = "DELETE FROM [I-LDS].integration.IasupToLimsUsers";
                using SqlConnection connection = new(connectionString);
                connection.Open();
                SqlCommand command = new(ClearTable, connection);
                int number1 = command.ExecuteNonQuery();
                logger.Info("Удалено объектов из таблицы integration.IasupToLimsUsers: {0}", number1);
                connection.Close();
            }
            catch (Exception)
            {
                logger.Error("Таблица IasupToLimsUsers не очищена");
            }
        }
        public static void Clear_IasupToLimsOrganization(string connectionString)
        {
            var logger = LogManager.Setup()
                                .LoadConfigurationFromAppSettings()
                                .GetCurrentClassLogger();
            try
            {
                string ClearTable = "DELETE FROM [I-LDS].integration.IasupToLimsOrganization";
                using SqlConnection connection = new(connectionString);
                connection.Open();
                SqlCommand command = new(ClearTable, connection);
                int number2 = command.ExecuteNonQuery();
                logger.Info("Удалено объектов из таблицы integration.IasupToLimsOrganization: {0}", number2);
                connection.Close();
            }
            catch (Exception)
            {
                logger.Error("Таблица IasupToLimsOrganization не очищена");
            }
        }
    }
}
