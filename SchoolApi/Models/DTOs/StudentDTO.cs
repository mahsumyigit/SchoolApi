using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Models.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Class { get; set; }

        public StudentDTO()
        {

        }
        public StudentDTO(Student student)
        {
            this.Id = student.Id;
            this.Name = student.Name;
            this.Surname = student.Surname;
            this.Class = student.Class;

        }
    }
}

