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
    public  class CourseRepo
    {

        readonly AppDbContext _context;
        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<short> AddAsync(Courses entity)
        {
            try
            {
                if (await IsItemCourseExist(entity.itemID)) return 0;

                await _context.courses.AddAsync(entity);
                short newId = (short)await _context.SaveChangesAsync();
                return newId > 0 ? entity.courseID : newId;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<bool> UpdateAsync(Courses entity)
        {
            try
            {
                byte res = (byte)await _context.courses.Where(x => x.courseID == entity.courseID)
                        .ExecuteUpdateAsync
                        (i => 
                        i.SetProperty(x => x.title, entity.title)
                        .SetProperty(x=>x.CreateAt,entity.CreateAt)
                        .SetProperty(x=>x.description,entity.description)
                        .SetProperty(x=>x.level,entity.level)
                        .SetProperty(x=>x.itemID,entity.itemID)
                        );
                return res != 0;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> ActivatedCourseAsync(short courseID)
        {
            try
            {
                byte res = (byte)await _context.courses.Where(x => x.courseID == courseID)
                        .ExecuteUpdateAsync
                        (i =>
                        i.SetProperty(x => x.IsActive, true));
                return res != 0;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeleteCourseAsync(short courseID)
        {
            try
            {
                byte res = (byte)await _context.courses.Where(x => x.courseID == courseID)
                        .ExecuteUpdateAsync
                        (i =>
                        i.SetProperty(x => x.IsActive, false));
                return res != 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> IsItemCourseExist(short itemID)
        {
            return await _context.courses.AsNoTracking()
                .AnyAsync(x => x.itemID == itemID);
        }
        public async Task<Courses?> FindAsync(short id)
        {
            return await _context.courses.AsNoTracking().Include(x => x.Items).FirstOrDefaultAsync(x => x.courseID== id);
        }
        public async Task<List<Courses>?> GetAllAsync()
        {
            return await _context.courses.AsNoTracking().Include(x=>x.Items).ToListAsync();
        }

    }
}
