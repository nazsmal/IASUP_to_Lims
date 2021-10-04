using System;
using System.Collections.ObjectModel;

namespace IASUP_to_Lims.Models
{
    /// <summary> профиль сотрудника </summary>
    public class Employee
    {
        /// <summary> Данные профиля сотрудника </summary>
        public class employeeData
        {
            /// <summary> Тип операции </summary>
            public string TypeOperation { get; set; }

            /// <summary> Табельный номер </summary> 
            public int Number { get; set; }

            public string StatusId { get; set; } //?

            /// <summary> Мероприятия </summary>
            public PersEvents persEvents { get; set; }

            /// <summary> Организационное присвоение </summary>
            public PersAssignment persAssignment { get; set; }

            /// <summary> Персональные данные </summary>
            public PersData persData { get; set; }

            /// <summary> Образование </summary>
            public PersEducation persEducation { get; set; }
        }
        /// <summary> Мероприятия </summary>
        public class PersEvents
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Ид статуса трудоустройства </summary>
            public string StatusId { get; set; }
        }
        /// <summary> Организационное присвоение </summary>
        public class PersAssignment
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Идентификатор должностной позиции </summary>
            public int UserPositionId { get; set; }

            /// <summary> Ид лаборатории </summary> 
            public int SubdivisionId { get; set; }

            /// <summary> Группа сотрудников </summary>
            public int UserGroup { get; set; }

            /// <summary> Наименование основного подразделения </summary>
            public string UserDepartmenName { get; set; }

            /// <summary> Наименование должности </summary>
            public string UserPositionName { get; set; }
        }
        /// <summary> Персональные данные </summary>
        public class PersData
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Дата рождения </summary>
            public string Birthday { get; set; }

            /// <summary> Имя </summary> 
            public string FirstName { get; set; }

            /// <summary> Фамилия </summary>
            public string LastName { get; set; }

            /// <summary> Отчество </summary>
            public string MiddleName { get; set; }
        }
        /// <summary> Образование </summary>
        public class PersEducation
        {
            /// <summary> Период действия с </summary>
            public string BEGDA { get; set; }

            /// <summary> Период действия по </summary>
            public string ENDDA { get; set; }

            /// <summary> Идентификатор оконченного учебного учреждения </summary>
            public string EducationCode { get; set; }
            public string EducationName { get; set; } //?
            public string SpecialityCode { get; set; } //?

            /// <summary> Год выпуска </summary>
            public string EdDate { get; set; }

            /// <summary> Основное образование </summary>
            public string PrimaryEd { get; set; }
            public string SUBTY { get; set; }

            /// <summary> Номер документа </summary>
            public string DocNumber { get; set; }
        }
    }
}

