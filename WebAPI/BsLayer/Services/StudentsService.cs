using AutoMapper;
using DTLayer.Entities;
using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using Dtos.EnrollStudentsDtos.StudentsDtos;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public  class StudentsService
    {
        readonly StudentsRepo _studentsRepo;
        readonly IMapper _mapper;
        readonly EnrollmentRepo _enrollmentRepo;
        readonly EnrollmentDetialsRepo _enrollmentDetialsRepo;
        readonly TransactionService _transactionService;
        readonly PeopleRepo _peopleRepo;
        
        public StudentsService(StudentsRepo studentsRepo, IMapper mapper, EnrollmentRepo enrollmentRepo, EnrollmentDetialsRepo enrollmentDetialsRepo, TransactionService transactionService,PeopleRepo peopleRepo)
        {
            _studentsRepo = studentsRepo;
            _mapper = mapper;
            _enrollmentRepo = enrollmentRepo;
            _enrollmentDetialsRepo = enrollmentDetialsRepo;
            _transactionService = transactionService;
            _peopleRepo = peopleRepo;
        }

        public async Task<findStudentsDtos?> GetStudentByIDAsync(int studnetID)
        {
            return _mapper.Map<findStudentsDtos>(await _studentsRepo.GetStudentByIDAsync(studnetID));
        }
        public async Task<List<findStudentsDtos>?> GetAllStudentsAsync()
        {
            return _mapper.Map<List<findStudentsDtos>>(await _studentsRepo.GetStudentsAsync());
        }

        public async Task<bool> UpdateStudentPersonAsync(updateStudentsPersonDtos dto)
        {
            return await _peopleRepo.UpdateAsync(_mapper.Map<People>(dto.updatePeopleDtos));
        }
        public async Task<bool> DeleteStudnetAsync(int studnetID)
        {
            int personID = await _studentsRepo.GetPersonID(studnetID);
            return personID == 0 ? false : await _peopleRepo.DeleteAsync(personID);
        }

        public async Task<int> addStudentsAsync(addStudentsEnrollmentDetialsFTDtos dto)
        {
            await _transactionService.BeginTransactionAsync();

            /// add person 
            int personID = await _peopleRepo.AddAsync(_mapper.Map<People>(dto.addStudentDtos.addPeopleDtos));
            if (personID == 0) { await _transactionService.RollbackAsync(); return 0; }

            dto.addStudentDtos.addPeopleDtos.PersonID = personID;
            /// add studentID
            int studnetID = await _studentsRepo.AddStudentAsync(_mapper.Map<Students>(dto.addStudentDtos));
            if (studnetID == 0) { await _transactionService.RollbackAsync(); return 0; }


            /// add enroll-id
            dto.enrollDtos.StudnetID = studnetID;
            int enrollID = await _enrollmentRepo.addEnrollAsync( _mapper.Map<Enrollments>( dto.enrollDtos));

            if (enrollID == 0) { await _transactionService.RollbackAsync(); return 0; }


            /// add enrollment detilas
            var TeacherIDS = dto.TeacherCourseIDs;

            var list = TeacherIDS.Select(x => new EnrollmentDetials { enrollID = enrollID, TeacherCourseID = x }).ToList();

            if (!await _enrollmentDetialsRepo.AddEnrollmentDetilasAsync(list))
            {
                await _transactionService.RollbackAsync(); return 0;
            }

            await _transactionService.CommitAsync();

            return studnetID;
        
        }

    }
}
