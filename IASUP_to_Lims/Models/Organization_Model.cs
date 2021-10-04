using System;


namespace IASUP_to_Lims.Models
{
    /// <summary> Организации/Подразделения </summary> 
    public class OrganizationData
    {
        /// <summary> Организации/Подразделения </summary>
        public class organizationData
        {
            /// <summary> Тип операции </summary>
            public string TypeOperation { get; set; }

            /// <summary> Идентификатор организационной единицы </summary> 
            public int DepartmentID { get; set; }

            /// <summary> Объект </summary> 
            public OrgUnitVersion orgUnitVersion { get; set; }

            /// <summary> Вербальное описание(данные по организационным единицам) </summary>
            public OrgUnitDescription orgUnitDescription { get; set; }

            /// <summary> Соединения (данные по организационным единицам) </summary>
            public OrgUnitLink orgUnitLink { get; set; }
        }
        /// <summary> Объект </summary>
        public class OrgUnitVersion
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Краткое наименование организационной единицы </summary> 
            public string DepartmentName { get; set; }
        }
        /// <summary> Вербальное описание(данные по организационным единицам) </summary>
        public class OrgUnitDescription
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Полное наименование организационной единицы </summary>
            public string DepartmentNameFull { get; set; }
        }
        /// <summary> Соединения (данные по организационным единицам) </summary>
        public class OrgUnitLink
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Характеристика соединения </summary>
            public string LinkCharacteristic { get; set; }

            /// <summary> Идентификатор соединенного объекта </summary>
            public int LinkedSourceEntityId { get; set; }

            /// <summary> Соединение между объектами </summary>
            public int LinkSourceId { get; set; }

            /// <summary> Тип соединенного объекта </summary>
            public string LinkType { get; set; }
        }
    }
}
