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
        public IRepository repo;

        public TheaterServices()
        {
            repo = new TheaterRepository();
        }
        public List<Theater> ListTheaters()
        {
            List<Theater> theaters = repo.ListTheaters();
            if (theaters == null || theaters.Count == 0)
            {
                return null;
            }
            else
            {
                return theaters;
            }
        }

      
        public Theater GetTheaterById(Guid id) =>repo.GetTheaterById(id);   
        public Theater AddTheater(Theater theater) => repo.AddTheater(theater);
        public Theater ChangeName(Guid id, Theater updatedTheater) =>repo.ChangeName(id,updatedTheater);
        public bool Delete(Guid id) =>repo.Delete(id);
    }
}
