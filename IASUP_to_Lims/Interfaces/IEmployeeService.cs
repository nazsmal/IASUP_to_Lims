using Microsoft.Extensions.Logging;
using System.ServiceModel;
using static IASUP_to_Lims.Models.Employee;

namespace IASUP_to_Lims.Services
{
    [ServiceContract(Namespace = "urn:greenatom:ru:LIMS:Staff")]
    public interface IEmployeeService
    {
        /// <summary> Получение профиля сотрудника </summary>
        /// <param name="employeeData"></param>
        [OperationContract(Name = "Employee")]
        public void Employee(employeeData employeeData);
    }
}