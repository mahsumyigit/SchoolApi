using System;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Context;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Repositories.Concretes
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DbContextBase _context;

        public SchoolRepository(DbContextBase context)
        {
            _context = context;
        }

        public async Task<School> AddSchool(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> DeleteSchool(int id)
        {
            School school = await _context.Schools.SingleOrDefaultAsync(x => x.Id == id);
            if (school != null)
            {
                _context.Schools.Remove(school);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<List<School>> GetAllSchool()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolById(int id)
        {
            return await _context.Schools.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<School> UpdateSchool(School school)
        {

            School school1Update = await _context.Schools.SingleOrDefaultAsync(x => x.Id == school.Id);
            if (school1Update != null)
            {
                school1Update.Name = school.Name;
                school1Update.Description = school.Description;
                school1Update.Type = school.Type;

                await _context.SaveChangesAsync();
                return school1Update;
            }
            return null;
        }
    }
}

