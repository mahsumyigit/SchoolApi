using System;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Services.Interface;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController:ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost("add")]
        public async Task<Teacher> Add(Teacher teacher)
        {
            await _teacherService.AddTeacher(teacher);
            return teacher;
        }
        [HttpDelete("delete")]
        public async Task<TeacherDTO> Delete(int id)
        {
           return await _teacherService.DeleteTeacher(id);

        }
        [HttpPut("update")]
        public async Task<TeacherDTO> UpdateTeacher([FromQuery] Teacher teacher)
        {
            return await _teacherService.UpdateTeacher(teacher);
        }

        [HttpGet("getall")]
        public async Task<List<Teacher>> GetAll()
        {
            return await _teacherService.GetAllTeacher();
        }
        [HttpGet("getbyteacherid")]
        public async Task<Teacher> GetByTeacherId([FromQuery] int id)
        {
            return await _teacherService.GetTeacherById(id);
        }
    }
}

