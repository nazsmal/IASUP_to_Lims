using System.ServiceModel;
using static IASUP_to_Lims.Models.OrganizationData;


namespace IASUP_to_Lims.Services
{
    [ServiceContract(Namespace = "urn:greenatom:ru:LIMS:Staff")]
    interface IOrganizationService
    {
        /// <summary> Получение Организации/Подразделения </summary>
        /// <param name="organizationData"></param>
        [OperationContract(Name = "OrganizationData")]
        public void Organization(organizationData organizationData);
    }
}
 