﻿namespace admission_office
{
    class SqlQuery
    {
        public static string[] SqlQueries { get; } = new string[]
        {
            @"SELECT e.id, CONCAT(speciality,' (',education_form,')') as Edu FROM admission_office.education e 
                INNER JOIN admission_office.speciality s ON e.id_speciality = s.id
                INNER JOIN admission_office.education_form ef ON e.id_education_form = ef.id
                ORDER BY e.id",
            "SELECT id, subject FROM admission_office.subject ORDER BY id",
            "SELECT id FROM admission_office.speciality WHERE speciality = @speciality",
            "SELECT * FROM admission_office.report"
    };
    }
    enum SqlQueryNum
    {
        EduSpec,
        Subject,
        SpecId,
        Report
    }
}