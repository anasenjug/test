using example.model;
using example.services;
using Npgsql;
using services.common;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                List<TheaterView> theaters = iTheaterServices.ListTheaters()
                .Select(theater => new TheaterView
                {
                    name = theater.name,
                    address = theater.address
                })
                .ToList();

                if (theaters == null) throw new Exception();
                return Request.CreateResponse(HttpStatusCode.OK, theaters);
            }
            catch { return Request.CreateResponse(HttpStatusCode.InternalServerError,"Code not working"); }   
            

        }

        // GET: api/Theater/5
        public HttpResponseMessage GetTheaterById(Guid id)
        {
            if (id == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            Theater theater =iTheaterServices.GetTheaterById(id);

            if (theater == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, theater);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddTheater([FromBody] Theater theater)
        {
            if (theater == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            theater=iTheaterServices.AddTheater(theater);
            if(theater==null) return Request.CreateResponse(HttpStatusCode.InternalServerError);
            return Request.CreateResponse(HttpStatusCode.OK,theater);
        }

        [HttpPut]
        public HttpResponseMessage ChangeName(Guid id, [FromBody] Theater updatedTheater)
        {
            if (updatedTheater == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            if (iTheaterServices.ChangeName(id,updatedTheater) == true) return Request.CreateResponse(HttpStatusCode.OK, updatedTheater);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // DELETE: api/Theater/5
        public HttpResponseMessage Delete(Guid id)
        {
            if (iTheaterServices.Delete(id) == true) return Request.CreateResponse(HttpStatusCode.OK, "Theater has been deleted successfully");
            return Request.CreateResponse(HttpStatusCode.InternalServerError);  
            
        }
    }
}
