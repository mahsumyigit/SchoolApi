using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Repositories.Interface
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchool();
        Task<School> GetSchoolById(int id);
        Task<School> AddSchool(School school);
        Task<School> UpdateSchool(School school);
        Task<School> DeleteSchool(int id);
    }
}

