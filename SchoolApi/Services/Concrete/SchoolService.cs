using System;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Services.Concrete
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<School> AddSchool(School school)
        {
            var result = await _schoolRepository.GetSchoolById(school.Id);
            if (result == null)
            {
                return await _schoolRepository.AddSchool(school);
            }
            throw new InvalidOperationException("There is another school with the same name.");
        }

        public async Task<SchoolDTO> DeleteSchool(int id)
        {
            try
            {
                School school = await _schoolRepository.DeleteSchool(id);
                if (school != null)
                {
                    return new SchoolDTO(await _schoolRepository.DeleteSchool(id));
                }
                return new SchoolDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<School>> GetAllSchool()
        {
            return await _schoolRepository.GetAllSchool();
        }

        public async Task<School> GetSchoolById(int id)
        {
            return await _schoolRepository.GetSchoolById(id);
        }

        public async Task<SchoolDTO> UpdateSchool(School school)
        {
            try
            {
                SchoolDTO schoolDTO = new SchoolDTO(await _schoolRepository.GetSchoolById(school.Id));
                if (schoolDTO != null)
                {
                    return new SchoolDTO(await _schoolRepository.UpdateSchool(school));
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

