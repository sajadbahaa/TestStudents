using AutoMapper;
using DTLayer.Entities;
using DTLayer.Entities.EntityEnums;
using Dtos.CoursesDtos;
using Dtos.ItemWithSpeclizeDtos;
using Dtos.PeopleDtos;
using Dtos.TeacherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            // repeate. CreateMap<addTeacherDtos,Teachers>()
            //        .ForMember(x => x.hireDate, opt => opt.MapFrom(x => x.hireDate))
            //        .ForMember(x => x.person, opt => opt.MapFrom(x => x.person))
            //        .ForMember(x => x.specilizeId, opt => opt.MapFrom(x => x.specilizeId))
            //        .ForMember(x => x.specilze, opt => opt.Ignore());



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



        }

    }
}
