using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [AuthorizationFilter]
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            _studentLogic.InsertStudents(value);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Student> Get([FromQuery] int age = -1)
        {
            if (age < 0)
            {
                return _studentLogic.GetStudents();
            }
            var students = _studentLogic.GetStudentsByAge(age);
            return students;
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return _studentLogic.GetStudentById(id);
        }
    }
}
