using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int id);
    }
}

