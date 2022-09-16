using System;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Context;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Repositories.Concretes
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly DbContextBase _context;

        public TeacherRepository(DbContextBase context)
        {
            _context = context;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeacher(int id)
        {
            Teacher teacher = await _context.Teachers.SingleOrDefaultAsync(x => x.Id == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            Teacher teacherUpdate = await _context.Teachers.SingleOrDefaultAsync(x => x.Id == teacher.Id);
            if (teacherUpdate != null)
            {
                teacherUpdate.Name = teacher.Name;
                teacherUpdate.Surname = teacher.Surname;
                teacherUpdate.Description = teacher.Description;
                teacherUpdate.Department = teacher.Department;

                await _context.SaveChangesAsync();
                return teacherUpdate;
            }
            return null;
        }
    }
}

