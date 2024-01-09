using AviaTikets.Controllers;
using AviaTikets.Models;

namespace AviaTikets.Interfaces
{
    public interface ITickets
    {
        Task<List<Tickets>> GetAll();
        Task<Tickets> GetTiketsById(int id);
       
        bool Add(Tickets tickets);
        bool Update(Tickets tickets);
        bool Delete(Tickets tickets);
        bool Save();
    }
}
