using DTLayer.Data;
using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class PeopleRepo
{
    private readonly AppDbContext _context;

    public PeopleRepo(AppDbContext context)
    {
        _context = context;
    }

    // Get All
    public async Task<List<People>?> GetAllPeopleAsync()
    {
        var people = await _context.people.AsNoTracking().ToListAsync();
        return people.Count>0? people : null;
    }

    // Get By Id
    public async Task<People?> GetByIdAsync(int id)
    {
        return await _context.people.AsNoTracking().FirstOrDefaultAsync(x=>x.PersonID==id);
    }

    // Add
    public async Task<int> AddAsync(People person)
    {
        if (await IsEmailOrPhoneExist(person.email, person.phone))
            return 0;

         await _context.people.AddAsync(person);
        
        return await _context.SaveChangesAsync()>0? person.PersonID:0; // EF Core يولد ID إذا Identity
    }

    // Update باستخدام ExecuteUpdateAsync
    public async Task<bool> UpdateAsync(People entity)
    {
        if (string.IsNullOrEmpty(entity.email)||string.IsNullOrEmpty(entity.phone))
        {
            if (await IsEmailOrPhoneExist(entity.email, entity.phone,entity.PersonID))
                return false;
        }
        
        byte res = (byte)await _context.people
            .Where(x => x.PersonID == entity.PersonID)
            .ExecuteUpdateAsync(i =>
                i.SetProperty(x => x.firstName, entity.firstName)
                 .SetProperty(x => x.secondName, entity.secondName)
                 .SetProperty(x => x.lastName, entity.lastName)
                 .SetProperty(x => x.email, entity.email)
                 .SetProperty(x => x.phone, entity.phone)
                 .SetProperty(x => x.birth, entity.birth)
                 .SetProperty(x => x.gendor, entity.gendor)
            );

        return res > 0;
    }

    // Delete باستخدام ExecuteDeleteAsync
    public async Task<bool> DeleteAsync(int id)
    {
        byte res = (byte)await _context.people
            .Where(x => x.PersonID == id)
            .ExecuteDeleteAsync();

        return res > 0;
    }
    public async Task<bool> IsEmailOrPhoneExist(string email, string phone, int id)
    {
        return await _context.people.AsNoTracking()
            .AnyAsync(x =>
                x.PersonID != id &&
                (
                    (!string.IsNullOrEmpty(email) && x.email == email) ||
                    (!string.IsNullOrEmpty(phone) && x.phone == phone)
                )
            );
    }

    public async Task<bool> IsEmailOrPhoneExist(string email, string phone)
    {
        return await _context.people.AsNoTracking()
            .AnyAsync(x =>
                
                (
                    (!string.IsNullOrEmpty(email) && x.email == email) ||
                    (!string.IsNullOrEmpty(phone) && x.phone == phone)
                )
            );
    }


}
