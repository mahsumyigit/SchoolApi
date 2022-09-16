using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models.Entities
{
    public class School:IEntity
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        //public virtual ICollection<Student>? Students { get; set; }
        //public virtual ICollection<Teacher>? Teachers { get; set; }
    }
}

