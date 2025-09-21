using AutoMapper;
using DTLayer.Entities;
using Dtos.PeopleDtos;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class PeopleService
    {
        readonly PeopleRepo _peopleRepo;
        readonly IMapper _mapper;
        public PeopleService(PeopleRepo peopleRepo,IMapper mapper)
        {
            _peopleRepo = peopleRepo;
            _mapper = mapper;
        }

        public async Task<List<findPeopleDtos>?> GetAllPeopleAsync()
        {
            return _mapper.Map<List<findPeopleDtos>>(await _peopleRepo.GetAllPeopleAsync());
        }

        public async Task<findPeopleDtos?> GetByIDAsync(int id)
        {
            return _mapper.Map<findPeopleDtos>(await _peopleRepo.GetByIdAsync(id));
        }
        public async Task<int> AddAsync(addPeopleDtos dto)
        {
            return await _peopleRepo.AddAsync(_mapper.Map<People> (dto));
        }


        public async Task<bool> UpdateAsync(updatePeopleDtos dto)
        {
            return await _peopleRepo.UpdateAsync(_mapper.Map<People>(dto));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _peopleRepo.DeleteAsync(id);
        }





    }
}
