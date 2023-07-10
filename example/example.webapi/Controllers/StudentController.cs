using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace example.webapi.Controllers
{
    public class StudentController : ApiController
    {
        private static List<Student> students = new List<Student>();
        private int generatedNumber;

        public ViewStudent MapViewStudent(Student student)
        {
            ViewStudent viewStudent = new ViewStudent();
            viewStudent.name = student.name;
            viewStudent.lastName = student.lastName;
            viewStudent.age = student.age;
            return viewStudent;
        }

        public int GenerateId()
        {
            generatedNumber += 1;
            return generatedNumber;
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            try
            {
                if (students.Count == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "List is empty");

                return Request.CreateResponse(HttpStatusCode.OK, students.Select(s => MapViewStudent(s)));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error retrieving students");
            }
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Student student = students.FirstOrDefault(s => s.id == id);
                if (student == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");

                return Request.CreateResponse(HttpStatusCode.OK, MapViewStudent(student));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error retrieving student");
            }
        }

        // POST api/<controller>
      
        public HttpResponseMessage Post([FromBody] Student newStudent)
        {
            try
            {
                newStudent.id = GenerateId();
                students.Add(newStudent);
                return Request.CreateResponse(HttpStatusCode.Created, "Student created successfully");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error creating student");
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] Student updatedStudent)
        {
            try
            {
                Student studentToUpdate = students.FirstOrDefault(s => s.id == id);
                if (studentToUpdate == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");

                studentToUpdate.name = updatedStudent.name;
                studentToUpdate.age = updatedStudent.age;
                studentToUpdate.lastName = updatedStudent.lastName;

                return Request.CreateResponse(HttpStatusCode.OK, "Student updated successfully");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error updating student");
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Student studentToDelete = students.FirstOrDefault(s => s.id == id);
                if (studentToDelete == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");

                students.Remove(studentToDelete);
                return Request.CreateResponse(HttpStatusCode.OK, "Student successfully removed");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error deleting student");
            }
        }
    }
}