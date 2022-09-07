using System;
using System.Data;

namespace SchoolApi.Models.Entities
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Class { get; set; }
        public int SchoolId { get; set; }
        public virtual School School{ get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
    }
}

