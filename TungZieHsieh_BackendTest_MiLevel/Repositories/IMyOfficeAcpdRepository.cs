using TungZieHsieh_BackendTest_MiLevel.Models;

namespace TungZieHsieh_BackendTest_MiLevel.Repositories;

public interface IMyOfficeAcpdRepository
{
    Task<IEnumerable<MyOfficeAcpd>> GetAllAsync();
    Task<MyOfficeAcpd?> GetByIdAsync(string sid);
    Task<string> CreateAsync(AcpdCreateDto dto);
    Task<bool> UpdateAsync(string sid, AcpdUpdateDto dto);
    Task<bool> DeleteAsync(string sid);
}
