using AutoMapper;
using DTLayer.Entities;
using Dtos.EnrollStudentsDtos.Enrollment;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class EnrollmentsDetilasService
    {

        readonly IMapper _mapper;
        readonly EnrollmentDetialsRepo _enrollmentDetialsRepo;

        public EnrollmentsDetilasService
        (   IMapper mapper, 
            EnrollmentDetialsRepo enrollmentDetialsRepo)
        {
            _mapper = mapper;
            _enrollmentDetialsRepo = enrollmentDetialsRepo;
        }

        public async Task<findEnrollmentDetialsDtos?> GetEnrollmentDetilasByIDAsync(int enrollDeitlasID)
        {
            return _mapper.Map<findEnrollmentDetialsDtos>(await _enrollmentDetialsRepo.GetEnrollmentDetilasByIDsAsync(enrollDeitlasID));
        }
        public async Task<List<findEnrollmentDetialsDtos>?> GetAllEnrollmentDetilasAsync()
        {
            return _mapper.Map<List<findEnrollmentDetialsDtos>>(await _enrollmentDetialsRepo.GetAllEnrollmentsDetialsAsync());
        }

        public async Task<bool> AddEnrollDetilasAsync(addStudentsEnrollmentDetialsDtos dto)
        {
            var TeacherIDS = await _enrollmentDetialsRepo
                .GetCoursesNotExistAsync(dto.enrollID,dto.TeacherCourseIDs);

            if (TeacherIDS.Count == 0) return false;


            var list = TeacherIDS.Select(teacherID =>
            new EnrollmentDetials
            { enrollID = dto.enrollID, TeacherCourseID = teacherID })
            .ToList();
            return await _enrollmentDetialsRepo.
                AddEnrollmentDetilasAsync(list);
        }

        public  async Task<bool> DeleteAsync(int enrollDetilasID)
        {
            return await _enrollmentDetialsRepo.DeleteAsync(enrollDetilasID);
        }



    }
}
