using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Repositories.Interface
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeacher();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(int id);
    }
}

