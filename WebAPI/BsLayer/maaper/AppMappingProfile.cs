using AutoMapper;
using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Dtos.CoursesDtos;
using Dtos.EnrollStudentsDtos.Enrollment;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using Dtos.EnrollStudentsDtos.StudentsDtos;
using Dtos.ItemWithSpeclizeDtos;
using Dtos.PeopleDtos;
using Dtos.TeacherCoursesDtos;
using Dtos.TeacherDtos;

namespace BsLayer.maaper
{
    public  class AppMappingProfile : Profile
    {

        public AppMappingProfile() 
        {
            CreateMap<addUpdateSpecilizesDto, Specilzeations>();

            CreateMap<Specilzeations, addUpdateSpecilizesDto>();

            //CreateMap<Items, UpdateItemsDto>();

            CreateMap<Items, ItemsDtos>();
            CreateMap<ItemsDtos, Items>().
                ForMember(x => x.specilize, y => y.Ignore())
                .ForMember(x=>x.specilizeID,y=>y.Ignore())
                .ForMember(x => x.itemID, y => y.Ignore());

            //CreateMap<UpdateItemsDto, Items>()
            //    .ForMember(x => x.specilize, y => y.Ignore()); ;

            CreateMap<UpdateItemsDto, Items>()
            .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.itemID))
            .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.itemName))
            .ForMember(dest => dest.specilizeID, opt => opt.Ignore())
            .ForMember(dest => dest.specilize, opt => opt.Ignore())
            .ForMember(des=>des.course,opt=>opt.Ignore());


            CreateMap<UpdateItemsWithSpecilzeDtos, Items>()
            .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.item.itemID))
            .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.item.itemName))
            .ForMember(dest => dest.specilizeID, opt => opt.Ignore())
            .ForMember(dest => dest.specilize, opt => opt.Ignore())
            .ForMember(des => des.course, opt => opt.Ignore()); ;

            CreateMap<UpdateItemsWithSpecilzeDtos, Specilzeations>()
            .ForMember(dest => dest.specilizeId, opt => opt.MapFrom(x => x.specilze.specilizeId))
            .ForMember(dest => dest.specilizeName, opt => opt.MapFrom(x => x.specilze.specilizeName));


            CreateMap<Items, FindItemsDtos>()
    .ForMember(dest => dest.itemID, opt => opt.MapFrom(src => src.itemID))
    .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.itemName))
    .ForMember(dest => dest.specilizeId, opt => opt.MapFrom(src => src.specilizeID))
    .ForMember(dest => dest.specilizeName, opt => opt.MapFrom(src => src.specilize.specilizeName));



            /// course///
            CreateMap<Courses, FindCourseDtos>()
                        .ForMember(x => x.courseID, opt => opt.MapFrom(o => o.courseID))
                        .ForMember(x => x.itemName, opt => opt.MapFrom(o => o.Items.itemName))
                        .ForMember(x => x.IsActive, opt => opt.MapFrom(o => o.IsActive))
                        .ForMember(x => x.title, opt => opt.MapFrom(o=>o.title))
                        .ForMember(x => x.CreateAt, opt => opt.MapFrom(o => o.CreateAt))
                        .ForMember(x => x.description, opt => opt.MapFrom(o => o.description))
                        .ForMember(x => x.level, opt => opt.MapFrom(o => o.level.ToString()))
                       ;


            CreateMap<addCourseDto, Courses>()
                .ForMember(x => x.courseID, opt => opt.Ignore())
                .ForMember(y => y.Items, o => o.Ignore())
                .ForMember(x => x.itemID, o => o.MapFrom(y => y.itemID))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(o => o.IsActive))
                        .ForMember(x => x.title, opt => opt.MapFrom(o => o.title))
                        .ForMember(x => x.CreateAt, opt => opt.MapFrom(o => o.CreateAt))
                        .ForMember(x => x.description, opt => opt.MapFrom(o => o.description))
                        .ForMember(x => x.level, opt => opt.MapFrom(o =>(CourseEnums)o.level));




            CreateMap<updateCourseDtos, Courses>()
                .ForMember(x => x.itemID, o => o.MapFrom(x=>x.itemID))
                .ForMember(y => y.Items, o => o.Ignore())
                .ForMember(x => x.title, opt => opt.MapFrom(o => o.title))
                        .ForMember(x => x.CreateAt, opt => opt.MapFrom(o => o.CreateAt))
                        .ForMember(x => x.description, opt => opt.MapFrom(o => o.description))
                        .ForMember(x => x.level, opt => opt.MapFrom(o => (CourseEnums)o.level));
            ;



///
// People Mapper.
///


            CreateMap<People, findPeopleDtos>()
                .ForMember(x => x.PersonID, opt => opt.MapFrom(x=>x.PersonID))
                .ForMember(x => x.email, opt => opt.MapFrom(x => x.email))
                .ForMember(x => x.phone, opt => opt.MapFrom(x => x.phone))

.ForMember(x => x.birth, opt => opt.MapFrom(x => x.birth))
   //.ForMember(x => x.fullName, opt => opt.MapFrom(x => new StringBuilder(x.firstName+' '+x.secondName+' '+x.lastName)))
   .ForMember(x => x.fullName, opt => opt.MapFrom(x => $"{x.firstName} {x.secondName} {x.lastName}"))

.ForMember(x => x.gendor, opt => opt.MapFrom(x => x.gendor.ToString()));



            CreateMap<addPeopleDtos, People>()
                .ForMember(x => x.PersonID, opt => opt.Ignore())
                .ForMember(x => x.email, opt => opt.MapFrom(x => x.email))
                .ForMember(x => x.phone, opt => opt.MapFrom(x => x.phone))

.ForMember(x => x.birth, opt => opt.MapFrom(x => x.birth))
                .ForMember(x => x.firstName, opt => opt.MapFrom(x => x.firstName))
                .ForMember(x => x.secondName, opt => opt.MapFrom(x => x.secondName))
.ForMember(x => x.lastName, opt => opt.MapFrom(x => x.lastName))

                .ForMember(x => x.gendor, opt => opt.MapFrom(x => (PeopleEnum)x.gendor));



            CreateMap<updatePeopleDtos, People>()
                .ForMember(x => x.PersonID, opt => opt.MapFrom(x=>x.PersonID))
                .ForMember(x => x.email, opt => opt.MapFrom(x => x.email))
                .ForMember(x => x.phone, opt => opt.MapFrom(x => x.phone))

.ForMember(x => x.birth, opt => opt.MapFrom(x => x.birth))
                .ForMember(x => x.firstName, opt => opt.MapFrom(x => x.firstName))
                .ForMember(x => x.secondName, opt => opt.MapFrom(x => x.secondName))
.ForMember(x => x.lastName, opt => opt.MapFrom(x => x.lastName))

                .ForMember(x => x.gendor, opt => opt.MapFrom(x => (PeopleEnum)x.gendor));

            //CreateMap<>

            /// Create Teacher Mapper.
            CreateMap<Teachers, findTeacherDtos>()
                    .ForMember(x => x.TeacherID, opt => opt.MapFrom(x => x.TeacherID))
                    .ForMember(x => x.hireDate, opt => opt.MapFrom(x => x.hireDate))
                    .ForMember(x => x.specilzeName, opt => opt.MapFrom(x => x.specilze.specilizeName))
                    .ForMember(x => x.person, opt => opt.MapFrom(x => x.person));


            CreateMap<addTeacherDtos, Teachers>()
                 .ForMember(x => x.specilze, opt => opt.Ignore());


            CreateMap<updateTeacherDtos, Teachers>()
                .ForMember(x=>x.TeacherID,opt=>opt.MapFrom(x=>x.TeacherID))
                 .ForMember(x => x.specilze, opt => opt.Ignore())
                 .ForMember(x=>x.person, opt => opt.Ignore());

            CreateMap<updateTeachrerPersonDtos, Teachers>()
                .ForMember(x => x.TeacherID, opt => opt.MapFrom(x => x.TeacherID))
                .ForMember(x => x.specilze, opt => opt.Ignore())
                 .ForMember(x => x.person, opt => opt.MapFrom(x=>x.person));

// Teacher Courses
            CreateMap<TeacherCourses, findTeacherCourseDtos>()
                .ForMember(x => x.TeacherCourseID, opt => opt.MapFrom(x => x.TeacherCourseID))

                    .ForMember(x => x.courseName, opt => opt.MapFrom(x => x.course.title))
                    .ForMember(x => x.teacherName, opt => opt.MapFrom(x => x.teacher.person.firstName+' '+ x.teacher.person.lastName))
                    .ForMember(x => x.startDate, opt => opt.MapFrom(x => x.startDate))
                    .ForMember(x => x.endDate, opt => opt.MapFrom(x => x.endDate))
                    .ForMember(x => x.note, opt => opt.MapFrom(x => x.note));

            CreateMap<updateTeacherCoursrDtos,TeacherCourses>()
                .ForMember(x => x.TeacherCourseID, opt => opt.MapFrom(x => x.TeacherCourseID))

                    .ForMember(x => x.courseID, opt => opt.MapFrom(x => x.courseID))
                    .ForMember(x => x.course, opt => opt.Ignore())
                    .ForMember(x => x.teacher, opt => opt.Ignore());;

            // Create Mapper Students 
            /// find students
            CreateMap<Students, findStudentsDtos>()
        .ForMember(x => x.StudentID, opt => opt.MapFrom(f => f.StudnetID))
        .ForMember(x=>x.findPeople,opt=>opt.MapFrom(x=>x.person));
            /// update students
            CreateMap<updateStudentsPersonDtos,Students>();

            /// add Students
            CreateMap<addStudentDtos, Students>()
                .ForMember(x => x.StudnetID, opt => opt.Ignore())
                .ForMember(x => x.PersonID, opt => opt.MapFrom(x=>x.addPeopleDtos.PersonID))
                .ForMember(x => x.person, opt => opt.Ignore())
                .ForMember(x => x.enrollment, opt => opt.Ignore())
                ;

            /// Enrollments            
            CreateMap<EnrollDtos, Enrollments>()
                .ForMember(x => x.StudnetID, opt => opt.MapFrom(x=>x.StudnetID))
                .ForMember(x => x.enrollStatus, opt => opt.MapFrom(x =>(EnrollmentEnums)x.enrollStatus))
                ;
                ;

            /// find Enrollments
            CreateMap<Enrollments, findEnrollmentDtos>()
                .ForMember(x => x.enrollDate, opt => opt.MapFrom(x => x.enrollDate))
                .ForMember(x => x.enrollStatus, opt => opt.MapFrom(x => x.enrollStatus.ToString()))
.ForMember(x => x.StudnetID, opt => opt.MapFrom(x => x.StudnetID))
.ForMember(x => x.enrollID, opt => opt.MapFrom(x => x.enrollID));



            /// add enroll studnet enroll detilas.
            CreateMap<addStudentsEnrollmentDetialsFTDtos, Students>();

            CreateMap<addStudentsEnrollmentDetialsDtos, EnrollmentDetials>()
                .ForMember(x => x.enrollment, opt => opt.Ignore())
                .ForMember(x => x.TeacherCourse, opt => opt.Ignore())
                .ForMember(x => x.enrollID, opt => opt.MapFrom(x=>x.enrollID))
                .ForMember(x => x.TeacherCourseID,opt=>opt.Ignore())
                .ForMember(x => x.enrollDetialsID, opt => opt.Ignore())
                ;

            /// find enroll detilas 
            CreateMap<EnrollmentDetials, findEnrollmentDetialsDtos>()
                .ForMember(x => x.enrollDetialsID, opt => opt.MapFrom(x => x.enrollDetialsID))
                .ForMember(x => x.TeacherCourseID, opt => opt.MapFrom(x => x.TeacherCourseID))
.ForMember(x => x.enrollID, opt => opt.MapFrom(x => x.enrollID));

        }

    }
}
