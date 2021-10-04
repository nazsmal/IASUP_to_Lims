using IASUP_to_Lims.Interfaces;
using IASUP_to_Lims.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using System;
using System.IO;

namespace IASUP_to_Lims.Services
{
    public class ProfessionService : IProfessionService
    {
        protected string ConnectionString { get; set; }
        public void Profession(Profession_Model profession_Model)
        {
            string ObjID = profession_Model.ObjID;
            string SText = profession_Model.SText;
            string Short = profession_Model.Short;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/").AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var logger = LogManager.Setup()
                                 .LoadConfigurationFromAppSettings()
                                 .GetCurrentClassLogger();

            ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            string sqlExpression = "INSERT INTO [I-LDS].[integration].[IasupToLimsProfession] (ObjID, SText, Short) VALUES(" + ObjID + "," + "'" + SText + "'," + "'" + Short + "')";

            logger.Info(sqlExpression);

            using (SqlConnection connection = new(ConnectionString))
            {
                try
                {
                    connection.Open();
                    logger.Info("Подключение открыто");
                    SqlCommand command = new(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    logger.Info("Справочник обновлен: {0}", number + " : " + "ID должности: " + ObjID + " наименование: " + SText + " краткое наименование должности: " + Short + " ");
                    connection.Close();
                    logger.Info("Подключение закрыто...");
                }
                catch (Exception)
                {
                    logger.Error("Нет подключения к БД");
                }
            }
        }

    }
}
