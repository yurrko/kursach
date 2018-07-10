namespace admission_office
{
    class SqlQueryList
    {
        public static string[] Queries { get; } = new string[]
        {
            @"SELECT e.id, CONCAT(speciality,' (',education_form,')') as Edu FROM admission_office.education e 
                INNER JOIN admission_office.speciality s ON e.id_speciality = s.id
                INNER JOIN admission_office.education_form ef ON e.id_education_form = ef.id
                ORDER BY e.id",
            "SELECT id, subject FROM `admission_office`.`subject` ORDER BY `id`",
            "SELECT id FROM `admission_office`.`speciality` WHERE `speciality` = @0",
            "SELECT * FROM `admission_office`.`report`",
            "INSERT INTO `admission_office`.`entrants` (`first_name`, `middle_name`, `last_name`, `birth_date`) VALUES (@0, @1, @2, @3)",
            "SELECT `role` FROM `admission_office`.`authorize` WHERE `login` = @0 AND `password` = @1",
            "INSERT INTO `admission_office`.`log` (`timestamp`, `user`, `success`) VALUES (@0, @1, @2)",
            "INSERT INTO `admission_office`.`authorize` (`login`, `password`, `role`) VALUES (@0, @1, @2)",
            "INSERT INTO `admission_office`.`ege_result` (`id_entrant`, `id_subject`, `result`) VALUES (@0, @1, @2)",
            "INSERT INTO `admission_office`.`entrance` (`id_entrant`, `id_education`, `date`) VALUES (@0, @1, @2)",
            "INSERT INTO `admission_office`.`subject` (`subject`) VALUES (@0)",
            "INSERT INTO `admission_office`.`speciality` (`speciality`) VALUES( @0 )",
            "INSERT INTO `admission_office`.`education` (`id_speciality`, `id_education_form`, `num_of_free_places`, `num_of_paid_places`) VALUES( @0, @1, @2, @3)",
            "INSERT INTO `admission_office`.`requirement` (`id_education`, `id_subject`, `min_requirement`) VALUES (@0, @1, @2)"
        };
    }
    enum SqlQueryNum
    {
        EduSpec,
        Subject,
        SpecId,
        Report,
        AddEntrant,
        SelectRole,
        Log,
        Register,
        AddEgeResult,
        AddEntrance,
        AddSubject,
        AddSpeciality,
        AddEducation,
        AddRequirement
    }
}