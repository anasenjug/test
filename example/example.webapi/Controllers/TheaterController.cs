using example.services;
using Npgsql;
using services.common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace example.webapi.Controllers
{

    public class TheaterController : ApiController
    {
        public IServices iTheaterServices;

        public TheaterController()
        {
            iTheaterServices = new TheaterServices();
        }
        public HttpResponseMessage GetTheaters()
        {
            
            

        }

        // GET: api/Theater/5
        public HttpResponseMessage GetTheaterById(Guid id)
        {
           
        }

        [HttpPost]
        public HttpResponseMessage AddTheater([FromBody] Theater theater)
        {
            
        }

        [HttpPut]
        public HttpResponseMessage ChangeName(Guid id, [FromBody] Theater updatedTheater)
        {
           
        }

        // DELETE: api/Theater/5
        public HttpResponseMessage Delete(Guid id)
        {


            
        }
    }
}
