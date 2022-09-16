using System;
using System.Diagnostics.Metrics;
using System.Net;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;

namespace SchoolApi.Repositories.Interface
{
    public interface ISchoolService
    {
        Task<List<School>> GetAllSchool();
        Task<School> GetSchoolById(int id);
        Task<School> AddSchool(School school);
        Task<SchoolDTO> UpdateSchool(School school);
        Task<SchoolDTO> DeleteSchool(int id);
    }
}

