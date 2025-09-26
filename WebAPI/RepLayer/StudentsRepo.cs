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
    public  class StudentsRepo
    {
        readonly AppDbContext _context;
        public StudentsRepo(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Students>?> GetStudentsAsync()
        {
            return await _context.students.AsNoTracking()
                    .Include(x => x.person).ToListAsync();
        }

        public async Task<Students?> GetStudentByIDAsync(int studentID)
        {
            return await _context.students.AsNoTracking()
            .Include(x => x.person).FirstOrDefaultAsync(x=>x.StudnetID==studentID);
        }

        public async Task<int> AddStudentAsync(Students entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.StudnetID : 0;
        }


        public async Task<int>GetPersonID(int studentID)
        {
            var res = await _context.students.AsNoTracking().FirstOrDefaultAsync(x => x.StudnetID == studentID);
            return  res.PersonID!=0?res.PersonID:0;
        }


    }
}
