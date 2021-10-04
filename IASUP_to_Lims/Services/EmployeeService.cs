using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using static IASUP_to_Lims.Models.Employee;


namespace IASUP_to_Lims.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected string ConnectionString { get; set; } 
        public void Employee(employeeData employeeData)
        {
            int Number = employeeData.Number;
            string LastName = employeeData.persData.LastName;
            string FirstName = employeeData.persData.FirstName;
            string MiddleName = employeeData.persData.MiddleName;
            string Birthday = employeeData.persData.Birthday.ToString();
            string PersData_BEGDA = employeeData.persData.BEGDA.ToString();
            string PersData_ENDDA = employeeData.persData.ENDDA.ToString();
            string TypeOperation = employeeData.TypeOperation;
            string StatusId = employeeData.StatusId;
            string PersEvents_BEGDA = employeeData.persEvents.BEGDA.ToString();
            string PersEvents_ENDDA = employeeData.persEvents.ENDDA.ToString();
            string SubdivisionId = employeeData.persAssignment.SubdivisionId.ToString();
            string PersAssignment_BEGDA = employeeData.persAssignment.BEGDA.ToString();
            string PersAssignment_ENDDA = employeeData.persAssignment.ENDDA.ToString();
            string UserDepartmenName = employeeData.persAssignment.UserDepartmenName;
            int UserGroup = employeeData.persAssignment.UserGroup;
            int UserPositionId = employeeData.persAssignment.UserPositionId;
            string UserPositionName = employeeData.persAssignment.UserPositionName;
            string PersEducation_BEGDA = employeeData.persEducation.BEGDA.ToString();
            string PersEducation_ENDDA = employeeData.persEducation.ENDDA.ToString();
            string EducationCode = employeeData.persEducation.EducationCode;
            string EducationName = employeeData.persEducation.EducationName;
            string SpecialityCode = employeeData.persEducation.SpecialityCode;
            string EdDate = employeeData.persEducation.EdDate.ToString();
            string PrimaryEd = employeeData.persEducation.PrimaryEd;
            string SUBTY = employeeData.persEducation.SUBTY;
            string DocNumber = employeeData.persEducation.DocNumber;

            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/").AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var logger = LogManager.Setup()
                                 .LoadConfigurationFromAppSettings()
                                 .GetCurrentClassLogger();


            ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            string sqlExpression = "INSERT INTO [I-LDS].[integration].[IasupToLimsUsers] (Number," +
                    " LastName," +
                    " FirstName," +
                    " MiddleName," +
                    " Birthday," +
                    " PersDataBEGDA," +
                    " PersDataENDDA," +
                    " TypeOperation," +
                    " StatusId," +
                    " PersEventsBEGDA," +
                    " PersEventsENDDA," +
                    " SubdivisionId," +
                    " PersAssignmentBEGDA," +
                    " PersAssignmentENDDA," +
                    " UserDepartmenName," +
                    " UserGroup," +
                    " UserPositionId," +
                    " UserPositionName," +
                    " PersEducationBEGDA," +
                    " PersEducationENDDA," +
                    " EducationCode," +
                    " EducationName," +
                    " SpecialityCode," +
                    " EdDate," +
                    " PrimaryEd," +
                    " SUBTY," +
                    " DocNumber) VALUES(" + Number + ","
                                          + "'" + LastName + "',"
                                          + "'" + FirstName + "',"
                                          + "'" + MiddleName + "',"
                                          + "CONVERT(datetime, iif " + "(('" + Birthday + "'='0000-00-00'),null," + "'" + Birthday + "'),101),"
                                          + "CONVERT(datetime, iif " + "(('" + PersData_BEGDA + "'='0000-00-00'),null," + "'" + PersData_BEGDA + "'),101),"
                                          + "CONVERT(datetime, iif " + "(('" + PersData_ENDDA + "'='0000-00-00'),null," + "'" + PersData_ENDDA + "'),101),"
                                          + "'" + TypeOperation + "',"
                                          + "'" + StatusId + "',"
                                          + "CONVERT(datetime, iif " + "(('" + PersEvents_BEGDA + "'='0000-00-00'),null," + "'" + PersEvents_BEGDA + "'),101),"
                                          + "CONVERT(datetime, iif " + "(('" + PersEvents_ENDDA + "'='0000-00-00'),null," + "'" + PersEvents_ENDDA + "'),101),"
                                          + "'" + SubdivisionId + "',"
                                          + "CONVERT(datetime, iif " + "(('" + PersAssignment_BEGDA + "'='0000-00-00'),null," + "'" + PersAssignment_BEGDA + "'),101),"
                                          + "CONVERT(datetime, iif " + "(('" + PersAssignment_ENDDA + "'='0000-00-00'),null," + "'" + PersAssignment_ENDDA + "'),101),"
                                          + "'" + UserDepartmenName + "',"
                                          + "'" + UserGroup + "',"
                                          + "'" + UserPositionId + "',"
                                          + "'" + UserPositionName + "',"
                                          + "CONVERT(datetime, iif " + "(('" + PersEducation_BEGDA + "'='0000-00-00'),null," + "'" + PersEducation_BEGDA + "'),101),"
                                          + "CONVERT(datetime, iif " + "(('" + PersEducation_ENDDA + "'='0000-00-00'),null," + "'" + PersEducation_ENDDA + "'),101),"
                                          + "'" + EducationCode + "',"
                                          + "'" + EducationName + "',"
                                          + "'" + SpecialityCode + "',"
                                          + "CONVERT(datetime, iif " + "(('" + EdDate + "'='0000-00-00'),null," + "'" + EdDate + "'),101),"
                                          + "'" + PrimaryEd + "',"
                                          + "'" + SUBTY + "',"
                                          + "'" + DocNumber + "')";

            logger.Info(sqlExpression);

            using (SqlConnection connection = new(ConnectionString))
                {
                try
                {
                    connection.Open();
                    logger.Info("Подключение открыто");
                    SqlCommand command = new(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    logger.Info("Добавлено пользователей: {0}", number + " : " + "Табельный номер: " + Number + " ФИО: " + LastName + " " + FirstName + " " + MiddleName + " ");
                    connection.Close();
                    logger.Info("Подключение закрыто...");
                }
                catch (Exception)
                {
                    logger.Error("Нет подключения к БД");
                }
            }
                
            SqlQuery.Update(ConnectionString);
            //SqlQuery.Clear_IasupToLimsUsers(ConnectionString); //очищаем таблицы [integration].[IasupToLimsUsers]
        }                 
    }
}
