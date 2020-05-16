using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class GroceriesRepository : IGroceriesRepository
    {
        private readonly WastelessDbContext _context;

        public GroceriesRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task Save(Groceries groceries)
        {
            _context.GroceryLists.Add(groceries);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<GroceryItem>> GetUserItemsExpiringInNearFuture(Int32 userId)
        {
            Int32 MAX_DAYS_TILL_EXPIRATION = 5;
            return await _context.GroceryItems.Where(item => item.GroceryList.UserId == userId && 
                                                        item.ConsumptionDate == DateTime.MinValue &&
                                                        item.ExpirationDate > DateTime.Now &&
                                                        item.ExpirationDate < DateTime.Now.AddDays(MAX_DAYS_TILL_EXPIRATION))
                                        .ToListAsync();
        }

        public async Task<IList<Groceries>> GetGroceries(Int32 userId)
        {
            return await _context.GroceryLists
                             .Include(list => list.Items)
                             .Where(list => list.UserId == userId).ToListAsync();
        }

        public async Task Consume(int itemId)
        {
            var item = await _context.GroceryItems.Where(item => item.Id == itemId).FirstOrDefaultAsync();
            item.ConsumptionDate = DateTime.Now;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotification(int itemId)
        {
            var item = await _context.GroceryItems.Where(item => item.Id == itemId).FirstAsync();
            item.NotifyExpiration = true;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<GroceryItem>> GetUserNotifications(int userId)
        {
            var groceries = await GetGroceries(userId);
            var items = new List<GroceryItem>();

            foreach (var grocery in groceries)
                items.AddRange(grocery.Items.Where(i => i.NotifyExpiration == true));

            return items;
        }

        public async Task Edit(IList<GroceryItem> groceries)
        {
            foreach (var item in groceries)
                _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}