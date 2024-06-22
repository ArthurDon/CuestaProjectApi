using CustaProject.Dtos;
using CustaProject.Infra.Data.Contexts;
using CustaProject.Infra.Data.SqlCommand;
using CustaProject.Services.Contracts;
using Dapper;
using Microsoft.AspNetCore.Mvc;
namespace CustaProject.Infra.Data.Repositories
{
    public class CuestaRepository : ICuestaRepository
    {

        private readonly IDbContext _dbcontext;

        public CuestaRepository(IDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<CuestaResponse>> GetResult(string earringId, string category)
        {
            var sql = SqlCommands.GetInformation;

            using var connection = _dbcontext.GetConnection();

            var @params = new
            {
                EarringId = earringId,
                Category = category
            };

            var result = await connection.QueryAsync<CuestaResponse>(sql, @params);
            return result;
        }

        public async Task<IEnumerable<CuestaResponse>> GetResultAll()
        {
            var sql = SqlCommands.GetInformationAll;

            using var connection = _dbcontext.GetConnection();

            return await connection.QueryAsync<CuestaResponse>(sql);
        }


        public async Task<bool> InsertAnimal(AnimalDto animalDto)
        {
            try
            {
                var sql = SqlCommands.InsertAnimal;

                using var connection = _dbcontext.GetConnection();

                var @params = new
                {
                    AnimalGenus = animalDto.AnimalGenus,
                    DateBirth = animalDto.DateBirth,
                    Weight = animalDto.Weight,
                    Dentition = animalDto.Dentition,
                    Quantity = animalDto.Quantity,
                    NameDad = animalDto.NameDad,
                    Category = animalDto.Category,
                    NameMom = animalDto.NameMom,
                    DadAnimal = animalDto.DadAnimal,
                    MomAnimal = animalDto.MomAnimal,
                    CreatedBy = animalDto.CreatedBy,
                    EarringId = animalDto.EarringId,
                };

                var affectedRows = await connection.ExecuteAsync(sql, @params);

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir animal: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAnimal(string earringId, string category)
        {
            try
            {
                var sql = SqlCommands.DeleteAnimal;

                using var connection = _dbcontext.GetConnection();

                var @params = new
                {
                    EarringId = earringId,
                    Category = category
                };

                var affectedRows = await connection.ExecuteAsync(sql, @params);

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir animal: {ex.Message}");
                return false;
            }
        }
        public async Task<AnimalDto> GetAnimalByDentition(string earringId)
        {
            var sql = @"
    SELECT 
        AnimalGenus,
        DateBirth,
        Weight,
        Dentition,
        Quantity,
        NameDad,
        Category,
        NameMom,
        DadAnimal,
        MomAnimal,
        CreatedBy,
        EarringId
    FROM AnimalRecords
    WHERE EarringId = @EarringId";

            using var connection = _dbcontext.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<AnimalDto>(sql, new { EarringId = earringId });
        }



        public async Task<bool> UpdateAnimal(string earringId, AnimalUpdateDto animalDto)
        {
            try
            {
                var sql = SqlCommands.UpdateAnimal;

                using var connection = _dbcontext.GetConnection();

                var @params = new
                {
                    AnimalGenus = animalDto.AnimalGenus,
                    DateBirth = animalDto.DateBirth,
                    Weight = animalDto.Weight,
                    Dentition = animalDto.Dentition,
                    Quantity = animalDto.Quantity,
                    CreatedDt = animalDto.CreatedDt,
                    NameDad = animalDto.NameDad,
                    Category = animalDto.Category,
                    NameMom = animalDto.NameMom,
                    DadAnimal = animalDto.DadAnimal,
                    MomAnimal = animalDto.MomAnimal,
                    EarringId = earringId,
                };

                var affectedRows = await connection.ExecuteAsync(sql, @params);

                if (affectedRows > 0)
                {
                    Console.WriteLine("Atualização bem-sucedida.");
                }
                else
                {
                    Console.WriteLine("Nenhuma linha foi atualizada.");
                }

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar animal: {ex.Message}");
                return false;
            }
        }


    }
}

