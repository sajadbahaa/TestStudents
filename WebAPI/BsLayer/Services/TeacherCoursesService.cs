using AutoMapper;
using DTLayer.Entities;
using Dtos.CoursesDtos;
using Dtos.TeacherCoursesDtos;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class TeacherCoursesService
    {
        readonly TeacherCourseRepo _teacherCourseRepo;
        readonly IMapper _mapper;
        public TeacherCoursesService(TeacherCourseRepo teacherCourseRepo, IMapper mapper)
        {
            _teacherCourseRepo = teacherCourseRepo;
            _mapper = mapper;
        }

        public async Task<bool> AddSingleTeacherWithCoursesAsync(addTeacherCourseDtos dto)
        {
            short teacherID = dto.TeacherCourse.Keys.First();

            // Flatten HashSet (لأن Values هو Collection of HashSet)
            var courseDtos = dto.TeacherCourse.Values.SelectMany(c => c).ToList();

            // نعمل Mapping من Dto -> Entity
            var teacherCourses = courseDtos.Select(c => new TeacherCourses
            {
                teacherID = teacherID,
                courseID = c.courseID,
                startDate = c.startDate,
                endDate = c.endDate
            }).ToList();

            return await _teacherCourseRepo.AddTeacherCourseAsync(teacherCourses);
        }

        public async Task<bool> UpdateAsync(updateTeacherCoursrDtos dto)
        {
            return await _teacherCourseRepo.UpdateAsync(_mapper.Map<TeacherCourses>(dto));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _teacherCourseRepo.DeleteAsync(id);
        }

        public async Task<findTeacherCourseDtos?> GetTeacherCoursByIDAsync(int id)
        {
            var entity = await _teacherCourseRepo.GetTeacherCourseByIDAsync(id);
            return _mapper.Map<findTeacherCourseDtos?>(entity);
        }

        public async Task<List<findTeacherCourseDtos>?> GetTeacherCoursByIDAsync()
        {
            var entities = await _teacherCourseRepo.GetAllTeacherCourseAsync();
            return _mapper.Map<List<findTeacherCourseDtos>?>(entities);
        }



        //public async Task<FindCourseDtos?> GetCourseByIDAsync(short CourseID)
        //{
        //    return _mapper.Map<FindCourseDtos>(await _courseRepo.FindAsync(CourseID));
        //}
        //public async Task<List<FindCourseDtos>?> GetAllCoursesAsync()
        //{
        //    return _mapper.Map<List<FindCourseDtos>>(await _courseRepo.GetAllAsync());
        //}



        // new TeacherCourses { courseID = x.courseID,teacherID=teacherID,startDate = x.startDate,endDate = x.endDate,note = x.note
    }
}

