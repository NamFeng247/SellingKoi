using Microsoft.EntityFrameworkCore;
using SellingKoi.Data;
using SellingKoi.Models;
using SellingKoi.Models.Entities;

namespace SellingKoi.Services
{
    public class KoiService : IKoiService
    {
        private readonly DataContext _context;
        public KoiService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task AddKoiAsync(KOI Koi)
        {
            _context.KOIs.Add(Koi);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KOI>> GetAllKoisAsync()
        {
            return await _context.KOIs.Where(k => k.Status == true).ToListAsync();
        }
        
        //not use
        public Task<Guid?> GetIdByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        //

        public async Task<KOI> GetKoiByIdAsync(Guid id)
        {
            return await _context.KOIs.FindAsync();
        }

        public async Task NegateKoiAsync(Guid id)
        {
            var koi = await _context.KOIs.FindAsync(id);
            if (koi != null)
            {
                try
                {
                    koi.Status = false;
                    _context.KOIs.Update(koi);
                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    // Log the exception
                    throw new Exception("An error occurred while deactivating the customer.", ex);
                }
            }
            else
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
        }

        public async Task UpdateKoiAsync(KOI koi)
        {
            _context.Entry(koi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
