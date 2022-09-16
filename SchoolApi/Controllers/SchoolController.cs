using System;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController:ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost("add")]
        public async Task<School> Add(School school)
        {
            await _schoolService.AddSchool(school);
            return school;
        }
        [HttpDelete("delete")]
        public async Task<SchoolDTO> Delete([FromQuery] int id)
        {
           return await _schoolService.DeleteSchool(id);

        }
        [HttpPut("update")]
        public async Task<SchoolDTO> UpdateSchool([FromQuery]School school)
        {
            return await _schoolService.UpdateSchool(school);

        }

        [HttpGet("getall")]
        public async Task<List<School>> GetAll()
        {
            return await _schoolService.GetAllSchool();
        }
        [HttpGet("getbyschoolid")]
        public async Task<School> GetBySchoolId([FromQuery] int id)
        {
            return await _schoolService.GetSchoolById(id);
        }
    }
}

