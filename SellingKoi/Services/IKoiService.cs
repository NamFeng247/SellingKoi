using SellingKoi.Models;

namespace SellingKoi.Services
{
    public interface IKoiService
    {
        Task<IEnumerable<KOI>> GetAllKoisAsync();
        Task<KOI> GetKoiByIdAsync(Guid id);
        Task<Guid?> GetIdByNameAsync(string name);
        Task AddKoiAsync(KOI Koi);
        Task UpdateKoiAsync(KOI Koi);
        Task NegateKoiAsync(Guid id);
    }
}
