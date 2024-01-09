using AviaTikets.Data;
using AviaTikets.Interfaces;
using AviaTikets.Models;
using Microsoft.EntityFrameworkCore;

namespace AviaTikets.Reposiotories
{
    public class AirTicketsRepositories : ITickets
    {
        private readonly AppDataContext _appData;

        public AirTicketsRepositories(AppDataContext appData)
        {
            _appData = appData;
        }


        public bool Add(Tickets tickets)
        {
            _appData.Add(tickets);
            return Save();
        }

        public bool Delete(Tickets tickets)
        {
            _appData.Remove(tickets);
            return Save();
        }

        //public async Task<List<Tickets>> FindTickets(Tickets tickets)
        //{
            

        //    return find.ToList();
        //}

        public async Task<List<Tickets>> GetAll()
        {
            return await _appData.ticketsProperties.ToListAsync();
        }

        public async Task<Tickets> GetTiketsById(int id)
        {
            return await _appData.ticketsProperties.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var save = _appData.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Tickets tickets)
        {
            _appData.Update(tickets);
            return Save();
        }

       
    }
}
