using example.common;
using example.model;
using example.services;
using Microsoft.Ajax.Utilities;
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
        public IServices _iTheaterServices;

        public TheaterController(IServices iTheaterServices)
        {
            _iTheaterServices = iTheaterServices;
           
        }
        public HttpResponseMessage GetTheaters(int pageSize=5,int pageNumber=1,string orderBy="Id",string sortOrder="ASC", string name=null)
        {
            try
            {
                Sorting sorting=new Sorting();  
                Paging paging=new Paging(); 
                TheaterFilter theaterFilter=new TheaterFilter();    

                sorting.OrderBy = orderBy;  
                sorting.SortOrder = sortOrder;  
                paging.PageSize = pageSize; 
                paging.PageNumber = pageNumber;

                if (paging.PageNumber < 1 || paging.PageSize < 1 || (sorting.SortOrder.ToLower() != "asc" && sorting.SortOrder.ToLower() != "desc"))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request");
                }

                if(!theaterFilter.Name.IsNullOrWhiteSpace()) {
                    theaterFilter.Name = name;
                }

                List<TheaterView> theaters = _iTheaterServices.ListTheaters(paging,sorting,theaterFilter)
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
            Theater theater =_iTheaterServices.GetTheaterById(id);

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
        public HttpResponseMessage AddTheater([FromBody] TheaterView theater)
        {
            if (theater == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            Theater addedTheater = _iTheaterServices.AddTheater(new Theater
            {
                name = theater.name,
                address = theater.address
            });
            
            if(theater==null) return Request.CreateResponse(HttpStatusCode.InternalServerError);
            return Request.CreateResponse(HttpStatusCode.OK,new TheaterView {
                name=theater.name,
                address=theater.address
            });
        }

        [HttpPut]
        public HttpResponseMessage ChangeName(Guid id, [FromBody] Theater updatedTheater)
        {
            if (updatedTheater == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK,updatedTheater);

        }

        // DELETE: api/Theater/5
        public HttpResponseMessage Delete(Guid id)
        {
            if (_iTheaterServices.Delete(id) == true) return Request.CreateResponse(HttpStatusCode.OK, "Theater has been deleted successfully");
            return Request.CreateResponse(HttpStatusCode.InternalServerError);  
            
        }
    }
}
