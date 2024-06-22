namespace CustaProject.Infra.Data.SqlCommand
{
    public static class SqlCommands
    {
        public const string GetInformation = @"
            SELECT
            animalGenus as AnimalGenius,
            dateBirth as DateBirth,
            weight as Weight,
            dentition as Dentition,
            quantity as Quantity,
            createdDt as CreatedDt,
            createdBy as CreatedBy,
            nameDad as NameDad,
            category as Category,
            nameMom as NameMom,
            dadAnimal as DadAnimal,
            momAnimal as MomAnimal,
            earringId as EarringId
        FROM AnimalRecords
        WHERE earringId = @EarringId OR category = @Category";

        public const string GetInformationAll = @"
            SELECT
            animalGenus as AnimalGenius,
            dateBirth as DateBirth,
            weight as Weight,
            dentition as Dentition,
            quantity as Quantity,
            createdDt as CreatedDt,
            createdBy as CreatedBy,
            nameDad as NameDad,
            category as Category,
            nameMom as NameMom,
            dadAnimal as DadAnimal,
            momAnimal as MomAnimal,
            earringId as EarringId
            FROM AnimalRecords";

        public const string DeleteAnimal = @"
                DELETE FROM AnimalRecords
                WHERE earringId = @EarringId
                OR category = @Category";

        public const string InsertAnimal = @"
    INSERT INTO AnimalRecords (animalGenus, dateBirth, weight, dentition, quantity, createdDt, createdBy, nameDad, category, nameMom, dadAnimal, momAnimal, earringId)
    VALUES (@AnimalGenus, @DateBirth, @Weight, @Dentition, @Quantity, GETDATE(), @CreatedBy, @NameDad, @Category, @NameMom, @DadAnimal, @MomAnimal, @EarringId)";

        public const string UpdateAnimal = @"
    UPDATE AnimalRecords
    SET 
        animalGenus = @AnimalGenus,
        dateBirth = @DateBirth,
        weight = @Weight,
        quantity = @Quantity,
        createdDt = @CreatedDt,
        nameDad = @NameDad,
        category = @Category,
        nameMom = @NameMom,
        dadAnimal = @DadAnimal,
        momAnimal = @MomAnimal,
        dentition = @Dentition
    WHERE 
        earringId = @EarringId";

    }
}
