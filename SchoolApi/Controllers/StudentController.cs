using System;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models.DTOs;
using SchoolApi.Models.Entities;
using SchoolApi.Services.Interface;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost("add")]
        public async Task<Student> Add(Student student)
        {
            await _studentService.AddStudent(student);
            return student;
        }
        [HttpDelete("delete")]
        public async Task<StudentDTO> Delete(int id)
        {
           return await _studentService.DeleteStudent(id);

        }
        [HttpPut("update")]
        public async Task<StudentDTO> UpdateStudent([FromQuery] Student student)
        {
            return await _studentService.UpdateStudent(student);

        }

        [HttpGet("getall")]
        public async Task<List<Student>> GetAll()
        {
            return await _studentService.GetAllStudent();
        }
        [HttpGet("getbystudentid")]
        public async Task<Student> GetByStudentId([FromQuery] int id)
        {
            return await _studentService.GetStudentById(id);
        }
    }
}

