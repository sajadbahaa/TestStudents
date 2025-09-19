using AutoMapper;
using DTLayer.Entities;
using Dtos.CoursesDtos;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class CourseService 
    {
        readonly CourseRepo _courseRepo;
        readonly IMapper _mapper;
        public CourseService(CourseRepo  courseRepo,IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        public async Task<FindCourseDtos?> GetCourseByIDAsync(short CourseID)
        {
            return _mapper.Map<FindCourseDtos>(await _courseRepo.FindAsync(CourseID));
        }
        public async Task<List<FindCourseDtos>?> GetAllCoursesAsync()
        {
            return _mapper.Map<List<FindCourseDtos>>(await _courseRepo.GetAllAsync());
        }

        public async Task<short> AddCourseAsync(addCourseDto dto)
        {
            var course = _mapper.Map<Courses>(dto);

            return await _courseRepo.AddAsync(course);
        }

        public async Task<bool> UpdateCourseAsync(updateCourseDtos dto)
        {
            var course = _mapper.Map<Courses>(dto);

            return await _courseRepo.UpdateAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(short courseID)
        {
            return await _courseRepo.DeleteCourseAsync(courseID);
        }
        public async Task<bool> ActivatedCourseAsync(short courseID)
        {
            return await _courseRepo.ActivatedCourseAsync(courseID);
        }

    }
}
