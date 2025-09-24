using DTLayer.Data;
using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer
{
    public  class TeacherCourseRepo
    {
        readonly AppDbContext _context;
        public TeacherCourseRepo
            (AppDbContext context) { _context = context; }

    public async Task<TeacherCourses?> GetTeacherCourseByIDAsync(int id)
        {
                return await _context.TeacherCourses
                .AsNoTracking()
                .Include(x => x.teacher).ThenInclude(x=>x.person).Include(x => x.course)
                .FirstOrDefaultAsync(x=>x.TeacherCourseID==id);
        }

        public async Task<List<TeacherCourses>?> GetAllTeacherCourseAsync()
        {
            return await _context.TeacherCourses.AsNoTracking()
                .Include(x=>x.teacher).ThenInclude(x => x.person).Include(x=>x.course)
                .ToListAsync();
        }
        
        public async Task<bool> AddTeacherCourseAsync(List<TeacherCourses>list)
        {
            _context.AddRange(list);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> UpdateAsync (TeacherCourses data)
        {
            var res = await _context.TeacherCourses
                .Where(x => x.TeacherCourseID == data.TeacherCourseID)
                .ExecuteUpdateAsync(
                i=>i.SetProperty(y=>y.startDate,data.startDate)
                .SetProperty(y=>y.endDate,data.endDate)
                .SetProperty(y=>y.note,data.note)
                .SetProperty(y=>y.courseID,data.courseID)
                );
            return res > 0;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _context.TeacherCourses
                .Where(x => x.TeacherCourseID == id)
                .ExecuteDeleteAsync();
            return res > 0;
        }





    }
}
