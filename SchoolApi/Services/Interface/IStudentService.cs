using System;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;

namespace SchoolApi.Services.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<StudentDTO> UpdateStudent(Student student);
        Task<StudentDTO> DeleteStudent(int id);
    }
}

