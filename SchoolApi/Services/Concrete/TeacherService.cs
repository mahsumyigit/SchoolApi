using System;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Concretes;
using SchoolApi.Repositories.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services.Concrete
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var result = await _teacherRepository.GetTeacherById(teacher.Id);
            if (result == null)
            {
                return await _teacherRepository.AddTeacher(teacher);
            }
            throw new InvalidOperationException("There is another teacher with the same name.");
        }

        public async Task<TeacherDTO> DeleteTeacher(int id)
        {
            try
            {
                Teacher teacher = await _teacherRepository.DeleteTeacher(id);
                if (teacher != null)
                {
                    return new TeacherDTO(await _teacherRepository.DeleteTeacher(id));
                }
                return new TeacherDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _teacherRepository.GetAllTeacher();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _teacherRepository.GetTeacherById(id);
        }

        public async Task<TeacherDTO> UpdateTeacher(Teacher teacher)
        {
            try
            {
                TeacherDTO teacherDTO = new TeacherDTO(await _teacherRepository.GetTeacherById(teacher.Id));
                if (teacherDTO != null)
                {
                    return new TeacherDTO(await _teacherRepository.UpdateTeacher(teacher));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

