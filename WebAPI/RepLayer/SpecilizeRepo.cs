using DTLayer.Data;
using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RepLayer
{
    public class SpecilizeRepo
    {
        readonly AppDbContext _context;
        public SpecilizeRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<short> AddAsync(Specilzeations entity) 
        {
            try
            {
                await _context.specilzeations.AddAsync(entity);
                short newId = (short)await _context.SaveChangesAsync();
                return newId > 0 ? entity.specilizeId : newId;

            }
            catch (Exception ex) 
            {
               
                return 0;
            }        
        }
        public async Task<bool> UpdateAsync(Specilzeations entity)
        {
            try
            {
                byte res = (byte)await _context.specilzeations.Where(x => x.specilizeId == entity.specilizeId)
                        .ExecuteUpdateAsync
                        (i => i.SetProperty(x => x.specilizeName, entity.specilizeName));
                return res != 0;

            }
            catch (Exception ex)
            {
                return false;
            }
                
        }
        public async Task<bool> DeleteAsync(short id)
        {
            byte res = (byte)await _context.specilzeations.Where(x => x.specilizeId == id)
                       .ExecuteDeleteAsync();
            return res != 0;
        }
        public async Task<Specilzeations?> FindAsync(short id) 
        {
            return await _context.specilzeations.AsNoTracking().FirstOrDefaultAsync(x => x.specilizeId == id);
        }
        public async Task<List<Specilzeations>?> GetAllAsync()
        {
            return await _context.specilzeations.AsNoTracking().ToListAsync();
        }

        public async Task<bool>IsExist(string name)
        {
            return await _context.specilzeations.AnyAsync(x => x.specilizeName.Equals(name));
        }

    }
}
