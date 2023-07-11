using example.common;
using example.webapi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace services.common
{
    public interface IServices
    {
        List<Theater> ListTheaters(Paging paging, Sorting sorting, TheaterFilter theaterFilter);
        Theater GetTheaterById(Guid id);
        Theater AddTheater(Theater theater);
        Theater ChangeName(Guid id, Theater updatedTheater);
        bool Delete(Guid id);
    }
}
