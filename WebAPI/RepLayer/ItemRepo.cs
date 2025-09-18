using DTLayer.Data;
using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer
{
    public  class ItemRepo
    {
        readonly AppDbContext _context;
        public ItemRepo(AppDbContext context)
        {
            _context = context;
        }

        // Repo resoponsiable for Add CRUD Only.
        public async Task<bool> AddAsync(List< Items> entity)
        {
            try
            {
                await _context.items.AddRangeAsync(entity);
                short newId = (short)await _context.SaveChangesAsync();
                return newId > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
                public async Task<short> AddAsync(Items entity)
        {
            try
            {
                await _context.items.AddAsync(entity);
                short newId = (short)await _context.SaveChangesAsync();
                return newId > 0 ? entity.itemID: newId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<bool> UpdateAsync(Items entity)
        {
            try
            {
                byte res = (byte)await _context.items.Where(x => x.itemID == entity.itemID)
                        .ExecuteUpdateAsync
                        (i => i.SetProperty(x => x.itemName, entity.itemName));
                return res != 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(short id)
        {
            byte res = (byte)await _context.items.Where(x => x.itemID== id)
                       .ExecuteDeleteAsync();
            return res != 0;
        }
        public async Task<Items?> FindItemDetialsAsync(short id)
        {
            return await _context.items.AsNoTracking().Include(x=>x.specilize).FirstOrDefaultAsync(x => x.itemID == id);
        }
        public async Task<List<Items>?> GetAllAsync()
        {
            return await _context.items.AsNoTracking().Include(x => x.specilize).ToListAsync();
        }
        public async Task<bool> IsExistItemName(List<Items> list)
        {
            var names = list.Select(y => y.itemName).ToList(); // قائمة أسماء العناصر
            return await _context.items.AnyAsync(x => names.Contains(x.itemName));
        }

    }
}
