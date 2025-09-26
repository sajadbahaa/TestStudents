using DTLayer.Data;
using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer
{
     public  class EnrollmentRepo
    {
        readonly AppDbContext _context;
        public EnrollmentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Enrollments>?> GetEnrollmentsAsync()
        {
            return await _context.enrollments.AsNoTracking()
            .ToListAsync();
        }
        public async Task<Enrollments?> GetEnrollmentByIDsAsync(int enrollID)
        {
            return await _context.enrollments.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.enrollID == enrollID);
        }
        public async Task<int> addEnrollAsync(Enrollments entity)
        {
            await _context.enrollments.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.enrollID : 0 ;
        }
        public async Task<bool> ActivateEnrollmentAsync(int enrollID)
        {
            return await _ChangeEnrollStatusAsync(enrollID, EnrollmentEnums.Active);

        }
        private async Task<bool> _ChangeEnrollStatusAsync(int enrollID,EnrollmentEnums value)
        {
            var res = await _context.enrollments.Where(x => x.enrollID == enrollID)
                .ExecuteUpdateAsync(i => i.SetProperty(y => y.enrollStatus, value));
            return res > 0;
        } 
        public async Task<bool> UnActivateEnrollmentAsync(int enrollID)
        {
         return await _ChangeEnrollStatusAsync(enrollID,EnrollmentEnums.UnActive);
        }

      


    }
}
