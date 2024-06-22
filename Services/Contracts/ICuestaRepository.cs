using CustaProject.Dtos;

namespace CustaProject.Services.Contracts
{
    public interface ICuestaRepository
    {
        Task<IEnumerable<CuestaResponse>> GetResult(string earringId, string category);
        Task<IEnumerable<CuestaResponse>> GetResultAll();
        Task<bool> InsertAnimal(AnimalDto animalDto);
        Task<bool> DeleteAnimal(string earringId = null, string category = null);
        Task<bool> UpdateAnimal(string earringId, AnimalUpdateDto animalDto);
        Task<AnimalDto> GetAnimalByDentition(string earringId);
    }
}
