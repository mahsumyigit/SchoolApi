using System;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Concretes;
using SchoolApi.Repositories.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _studentRepository.GetStudentById(student.Id);
            if (result == null)
            {
                return await _studentRepository.AddStudent(student);
            }
            throw new InvalidOperationException("There is another student with the same name.");
        }

        public async Task<StudentDTO> DeleteStudent(int id)
        {
            try
            {
                Student student = await _studentRepository.DeleteStudent(id);
                if (student != null)
                {
                    return new StudentDTO(await _studentRepository.DeleteStudent(id));
                }
                return new StudentDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentRepository.GetAllStudent();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task<StudentDTO> UpdateStudent(Student student)
        {
            try
            {
                StudentDTO studentDTO = new StudentDTO(await _studentRepository.GetStudentById(student.Id));
                if (studentDTO != null)
                {
                    return new StudentDTO(await _studentRepository.UpdateStudent(student));
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

