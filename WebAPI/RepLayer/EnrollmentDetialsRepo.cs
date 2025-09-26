using DTLayer.Data;
using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer
{
    public class EnrollmentDetialsRepo
    {
        readonly AppDbContext _context;
        public EnrollmentDetialsRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EnrollmentDetials>?> GetAllEnrollmentsDetialsAsync()
        {
            return await _context.enrollmentDetials.AsNoTracking().ToListAsync();
        }
        public async Task<EnrollmentDetials?> GetEnrollmentDetilasByIDsAsync(int enrolDetilasld)
        {
            return await _context.enrollmentDetials.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.enrollDetialsID == enrolDetilasld);
        }
        public async Task<bool> AddEnrollmentDetilasAsync(List<EnrollmentDetials>data)
        {
            _context.AddRange(data);
            return await _context.SaveChangesAsync()>0;
        }
        public async Task<bool> DeleteAsync(int enrollDetialsId)
        {
            var res = await _context.enrollmentDetials.AsNoTracking()
                .Where(x => x.enrollDetialsID == enrollDetialsId)
                .ExecuteDeleteAsync();
;return res>0;
        }
        public async Task<bool> IsEnrollActiveAsync(int enrollID)
        {
            bool res = await _context.enrollments.AnyAsync(x => x.enrollID == enrollID && x.enrollStatus == EnrollmentEnums.Active);

            return res;
        }

        public async Task<List<int>> GetCoursesNotExistAsync(int enrollID, List<int> teacherCourseIDs)
        {
            return await _context.TeacherCourses
                .Where(tc => teacherCourseIDs.Contains(tc.TeacherCourseID))  // نركز على IDs المرسلة
                .Where(tc => !_context.enrollmentDetials
                                .Any(ed => ed.enrollID == enrollID
                                        && ed.enrollment.enrollStatus == EnrollmentEnums.Active
                                        && ed.TeacherCourseID == tc.TeacherCourseID))
                .Select(tc => tc.TeacherCourseID)
                .ToListAsync();
        }


    }
}
