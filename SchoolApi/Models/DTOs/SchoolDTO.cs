using System;
using SchoolApi.Models.Entities;

namespace SchoolApi.Models.DTOs
{
    [Serializable]
    public class SchoolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public SchoolDTO()
        {

        }
        public SchoolDTO(School school)
        {
            this.Id = school.Id;
            this.Name = school.Name;
            this.Description = school.Description;
            this.Type = school.Type;

        }
    }
}

