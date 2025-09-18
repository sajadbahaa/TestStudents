using AutoMapper;
using DTLayer.Entities;
using Dtos;
using RepLayer;
namespace BsLayer
{
    public class SpecilizationsService
    {
        readonly SpecilizeRepo _specilizeRepo;
        readonly IMapper _mapper;
          public SpecilizationsService(SpecilizeRepo specilizeRepo, IMapper mapper) 
        {
            _specilizeRepo = specilizeRepo;
            _mapper = mapper;
        }
        
        public async Task<List<addUpdateSpecilizesDto>?> GetAllAsync()
        {
            return  _mapper.Map<List<addUpdateSpecilizesDto>>(await _specilizeRepo.GetAllAsync());
        }

        public async Task<addUpdateSpecilizesDto?> GetByIdAsync(short id)
        {
            return _mapper.Map<addUpdateSpecilizesDto>(await _specilizeRepo.FindAsync(id));
        }
        public async Task<short> AddAsync(addUpdateSpecilizesDto dto)
        {
            var res = await _specilizeRepo.AddAsync(_mapper.Map<Specilzeations>(dto));
            return res;
        }

        public async Task<bool> UpdateAsync(addUpdateSpecilizesDto dto)
        {
            var res = await _specilizeRepo.UpdateAsync(_mapper.Map<Specilzeations>(dto));
            return res;
        }

        public async Task<bool> DeleteAsync(short id)
        {
            var res = await _specilizeRepo.DeleteAsync(id);
            return res;
        }




    }
}
