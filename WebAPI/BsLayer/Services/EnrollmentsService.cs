using AutoMapper;
using DTLayer.Entities;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using Dtos.EnrollStudentsDtos.StudentsDtos;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class EnrollmentsService
    {
        readonly IMapper _mapper;
        readonly EnrollmentRepo _enrollmentRepo;

        public EnrollmentsService(IMapper mapper, EnrollmentRepo enrollmentRepo)
        {
            _mapper = mapper;
            _enrollmentRepo = enrollmentRepo;
        }
        public async Task<findEnrollmentDtos?> GetEnrollmentByIDAsync(int enrollID)
        {
            return _mapper.Map<findEnrollmentDtos>(await _enrollmentRepo.GetEnrollmentByIDsAsync(enrollID));
        }
        public async Task<List<findEnrollmentDtos>?> GetAllStudentsAsync()
        {
            return _mapper.Map<List<findEnrollmentDtos>>(await _enrollmentRepo.GetEnrollmentsAsync());
        }

        public async Task<bool> ActivateEnrollAsync(int enrollID)
        {
            return await _enrollmentRepo.ActivateEnrollmentAsync(enrollID);
        }

        public async Task<bool> UnActivateEnrollAsync(int enrollID)
        {
        return await _enrollmentRepo.UnActivateEnrollmentAsync(enrollID);
        }

    }
}
