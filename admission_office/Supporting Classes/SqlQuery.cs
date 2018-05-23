using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admission_office
{
    class SqlQuery
    {
        public static string[] SqlQueries { get; } = new string[]
        {
            @"SELECT e.id, CONCAT(speciality,' (',education_form,')') as Edu FROM admission_office.education e 
                INNER JOIN admission_office.speciality s ON e.id_speciality = s.id
                INNER JOIN admission_office.education_form ef ON e.id_education_form = ef.id
                ORDER BY e.id",
            @"SELECT `edu_type`.`id`, `edu_type`.`edu_type` FROM `admission_office`.`edu_type`;",
            "SELECT id, subject FROM admission_office.subject ORDER BY id"
    };
    }
    enum SqlQueryNum
    {
        EduSpec,
        EduType,
        Subject
    }
}
