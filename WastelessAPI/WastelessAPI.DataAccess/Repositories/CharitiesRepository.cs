using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class CharitiesRepository
    {
        private readonly WastelessDbContext _context;
        public CharitiesRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Charity>> GetAll()
        {
            return await _context.Charities.ToListAsync();
        }

        public void Donate(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
        }
    }
}