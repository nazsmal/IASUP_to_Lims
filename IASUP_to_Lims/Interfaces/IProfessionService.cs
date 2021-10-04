using IASUP_to_Lims.Models;
using System.ServiceModel;


namespace IASUP_to_Lims.Interfaces
{
    [ServiceContract(Namespace = "urn:greenatom:ru:LIMS:Staff")]
    public interface IProfessionService
    {
        /// <summary> Получение профиля сотрудника </summary>
        /// <param name="employeeData"></param>
        [OperationContract(Name = "Profession")]
        public void Profession(Profession_Model profession_Model);
    }
}
