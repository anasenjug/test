using example.webapi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace repository.common
{
    public interface IRepository
    {

        List<Theater> ListTheaters();
        Theater GetTheaterById(Guid id);
        Theater AddTheater(Theater theater);
        Theater ChangeName(Guid id, Theater updatedTheater);
        bool Delete(Guid id);
    }
}
