using AutoMapper;
using DTLayer.Entities;
using Dtos.TeacherDtos;
using Dtos.TeacherDtos;
using RepLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    public class TeacherService
    {
        private readonly TeacherRepo _teacherRepo;
        private readonly PeopleRepo _peopleRepo;
        private readonly TransactionService _transactionService;
        private readonly IMapper _mapper;

        public TeacherService(
            PeopleRepo peopleRepo,
            TransactionService transactionService,
            IMapper mapper,
            TeacherRepo teacherRepo)
        {
            _peopleRepo = peopleRepo;
            _transactionService = transactionService;
            _mapper = mapper;
            _teacherRepo = teacherRepo;
        }

        // 1- GetAllTeachersAsync
        public async Task<List<findTeacherDtos>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepo.GetAllTeachersAsync();
            return _mapper.Map<List<findTeacherDtos>>(teachers);
        }

        // 2- GetTeacherByIDAsync
        public async Task<findTeacherDtos?> GetTeacherByIDAsync(short teacherId)
        {
            var teacher = await _teacherRepo.GetTeacherByIDAsync(teacherId);
            return _mapper.Map<findTeacherDtos?>(teacher);
        }

        // 3- AddNewAsync (use transaction)
        public async Task<short> AddNewAsync(addTeacherDtos dto)
        {

            await _transactionService.BeginTransactionAsync();
            
                // map person & save it
                var personEntity = _mapper.Map<People>(dto.person);
                int personId = await _peopleRepo.AddAsync(personEntity);

            if (personId==0)
            {
                await _transactionService.RollbackAsync();
                return 0;
            }
                // map teacher & save it
                var teacherEntity = _mapper.Map<Teachers>(dto);
                teacherEntity.personID = personId;

                var teacherId = await _teacherRepo.AddNewAsync(teacherEntity);
            if (teacherId == 0)
            {
                await _transactionService.RollbackAsync();
                return 0;
            }
             await _transactionService.CommitAsync();
            return teacherId;
        }

        // 4- UpdateTeacherAsync
        public async Task<bool> UpdateTeacherAsync(updateTeacherDtos dto)
        {
            var teacherEntity = _mapper.Map<Teachers>(dto);
            return await _teacherRepo.UpdateAsync(teacherEntity);
        }

        // 5- DeleteAsync
        public async Task<bool> DeleteAsync(short teacherId)
        {
            int personID = await _teacherRepo.GetPersonIDAsync(teacherId);

            return personID==0?false: await _peopleRepo.DeleteAsync(personID);
        }

        // 6- UpdateTeacherPeopleAsync (transaction)
        public async Task<bool> UpdateTeacherPeopleAsync(updateTeachrerPersonDtos dto)
        {
             await _transactionService.BeginTransactionAsync();
            
                // update person
                var personEntity = _mapper.Map<People>(dto.person);
                var updatedPerson = await _peopleRepo.UpdateAsync(personEntity);
            if (!updatedPerson)
            {
                await _transactionService.RollbackAsync();
                return false;

            }
                // update teacher
                var teacherEntity = _mapper.Map<Teachers>(dto);
                var updatedTeacher = await _teacherRepo.UpdateAsync(teacherEntity);

            if (!updatedTeacher)
            {
                await _transactionService.RollbackAsync();
                return false;

            }
            await _transactionService.CommitAsync();
            return updatedPerson && updatedTeacher;
            
        }
    }
}
