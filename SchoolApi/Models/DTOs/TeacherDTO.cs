using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Models.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }

        public TeacherDTO()
        {
        }
        public TeacherDTO(Teacher teacher)
        {
            this.Id = teacher.Id;
            this.Name = teacher.Name;
            this.Surname = teacher.Surname;
            this.Description = teacher.Description;
            this.Department = teacher.Department;

        }
    }
}

