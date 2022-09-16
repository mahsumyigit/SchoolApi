using System;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;

namespace SchoolApi.Services.Interface
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeacher();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<TeacherDTO> UpdateTeacher(Teacher teacher);
        Task<TeacherDTO> DeleteTeacher(int id);
    }
}

