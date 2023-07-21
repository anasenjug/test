using example.common;
using example.repository;
using example.webapi.Controllers;
using repository.common;
using services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example.services
{
    public class TheaterServices : IServices
    {
       IRepository _repo;

        public TheaterServices(IRepository repo)
        {
            _repo = repo;
        }
        public List<Theater> ListTheaters(Paging paging, Sorting sorting, TheaterFilter theaterFilter)
        {
            List<Theater> theaters = _repo.ListTheaters(paging, sorting , theaterFilter);
            if (theaters == null || theaters.Count == 0)
            {
                return null;
            }
            else
            {
                return theaters;
            }
        }

      
        public Theater GetTheaterById(Guid id) =>_repo.GetTheaterById(id);   
        public Theater AddTheater(Theater theater) => _repo.AddTheater(theater);
        public Theater ChangeName(Guid id, Theater updatedTheater) =>_repo.ChangeName(id,updatedTheater);
        public bool Delete(Guid id) =>_repo.Delete(id);
    }
}
