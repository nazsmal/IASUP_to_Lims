using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using static IASUP_to_Lims.Models.OrganizationData;


namespace IASUP_to_Lims.Services
{
    public class OrganizationService : IOrganizationService
    {
        protected string ConnectionString { get; set; }
        public void Organization(organizationData organizationData)
        {
            string TypeOperation = organizationData.TypeOperation;
            int DepartmentID = organizationData.DepartmentID;
            string OrgUnitVersionBEGDA = organizationData.orgUnitVersion.BEGDA.ToString();
            string OrgUnitVersionENDDA = organizationData.orgUnitVersion.ENDDA.ToString();
            string DepartmentName = organizationData.orgUnitVersion.DepartmentName;
            string OrgUnitDescriptionBEGDA = organizationData.orgUnitDescription.BEGDA.ToString();
            string OrgUnitDescriptionENDDA = organizationData.orgUnitDescription.ENDDA.ToString();
            string DepartmentNameFull = organizationData.orgUnitDescription.DepartmentNameFull;
            string OrgUnitLinkBEGDA = organizationData.orgUnitLink.BEGDA.ToString();
            string OrgUnitLinkENDDA = organizationData.orgUnitLink.ENDDA.ToString();
            string LinkCharacteristic = organizationData.orgUnitLink.LinkCharacteristic;
            int LinkedSourceEntityId = organizationData.orgUnitLink.LinkedSourceEntityId;
            int LinkSourceId = organizationData.orgUnitLink.LinkSourceId;
            string LinkType = organizationData.orgUnitLink.LinkType;


            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/").AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var logger = LogManager.Setup()
                                 .LoadConfigurationFromAppSettings()
                                 .GetCurrentClassLogger();

            ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;


            string sqlExpression = "INSERT INTO [I-LDS].[integration].[IasupToLimsOrganization] (DepartmentID," +
                " TypeOperation," +
                " OrgUnitVersionBEGDA," +
                " OrgUnitVersionENDDA," +
                " DepartmentName," +
                " OrgUnitDescriptionBEGDA," +
                " OrgUnitDescriptionENDDA," +
                " DepartmentNameFull," +
                " OrgUnitLinkBEGDA," +
                " OrgUnitLinkENDDA," +
                " LinkCharacteristic," +
                " LinkedSourceEntityId," +
                " LinkSourceId," +
                " LinkType) VALUES(" + DepartmentID + ","
                                      + "'" + TypeOperation + "',"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitVersionBEGDA + "'='0000-00-00'),null," + "'" + OrgUnitVersionBEGDA + "'),101),"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitVersionENDDA + "'='0000-00-00'),null," + "'" + OrgUnitVersionENDDA + "'),101),"
                                      + "'" + DepartmentName + "',"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitDescriptionBEGDA + "'='0000-00-00'),null," + "'" + OrgUnitDescriptionBEGDA + "'),101),"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitDescriptionENDDA + "'='0000-00-00'),null," + "'" + OrgUnitDescriptionENDDA + "'),101),"
                                      + "'" + DepartmentNameFull + "',"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitLinkBEGDA + "'='0000-00-00'),null," + "'" + OrgUnitLinkBEGDA + "'),101),"
                                      + "CONVERT(datetime, iif " + "(('" + OrgUnitLinkENDDA + "'='0000-00-00'),null," + "'" + OrgUnitLinkENDDA + "'),101),"
                                      + "'" + LinkCharacteristic + "',"
                                      + "'" + LinkedSourceEntityId + "',"
                                      + "'" + LinkSourceId + "',"
                                      + "'" + LinkType + "')";
            logger.Info(sqlExpression);

            using (SqlConnection connection = new(ConnectionString))
            {
                try
                {
                    connection.Open();
                    logger.Info("Подключение открыто");
                    SqlCommand command = new(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    logger.Info("Добавлено объектов: {0}", number);
                    connection.Close();
                    logger.Info("Подключение закрыто...");
                }
                catch (Exception)
                {
                    logger.Error("Запрос не выполнен");
                }
            }
            
            SqlQuery.Update(ConnectionString);
            //SqlQuery.Clear_IasupToLimsOrganization(ConnectionString); //очищаем таблицы [integration].[IasupToLimsOrganization]
        }
    }
}
