using System;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Context;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Repositories.Concretes
{
    public class StudentRepository:IStudentRepository
    {
        private readonly DbContextBase _context;

        public StudentRepository(DbContextBase context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            Student studentUpdate = await _context.Students.SingleOrDefaultAsync(x => x.Id == student.Id);
            if (studentUpdate != null)
            {
                studentUpdate.Name = student.Name;
                studentUpdate.Surname = student.Surname;
                studentUpdate.StudentNumber = student.StudentNumber;
                studentUpdate.Class = student.Class;

                await _context.SaveChangesAsync();
                return studentUpdate;
            }
            return null;
        }
    }
}

