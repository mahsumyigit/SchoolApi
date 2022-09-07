using System;
using System.Data;

namespace SchoolApi.Models.Entities
{
    public class Teacher:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}

