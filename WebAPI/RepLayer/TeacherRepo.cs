using DTLayer.Data;
using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepLayer
{
    public class TeacherRepo
    {
        private readonly AppDbContext _context;

        public TeacherRepo(AppDbContext context)
        {
            _context = context;
        }

        // 1- GetAllTeachersAsync
        public async Task<List<Teachers>?> GetAllTeachersAsync()
        {
            return await _context.Teachers
                .AsNoTracking()
                .Include(t => t.person).Include(x=>x.specilze) // Include Person, if null it will just be null
                .ToListAsync();
        }

        // 2- GetTeacherByIDAsync
        public async Task<Teachers?> GetTeacherByIDAsync(short teacherId)
        {
            return await _context.Teachers
                .AsNoTracking()
                .Include(t => t.person).Include(x=>x.specilze)
                .FirstOrDefaultAsync(t => t.TeacherID == teacherId);
        }

        // 3- AddNewAsync


        public async Task<short> AddNewAsync(Teachers teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher.TeacherID; // assuming TeacherID is PK with identity
        }

        // 4- UpdateAsync
        public async Task<bool> UpdateAsync(Teachers teacher)
        {
            var result = await _context.Teachers
                .Where(t => t.TeacherID == teacher.TeacherID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(t => t.specilzeID, teacher.specilzeID)
                    .SetProperty(t => t.hireDate, teacher.hireDate)
                );

            return result > 0;
        }

                public async Task<int> GetPersonIDAsync(short teacherId)
        {
            var result = await _context.Teachers.AsNoTracking()
                .FirstOrDefaultAsync(t => t.TeacherID == teacherId);

            return result==null?0:result.personID;
        }
    }
}
