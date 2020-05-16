using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Interfaces
{
    public interface IGroceriesRepository
    {
        Task Save(Groceries groceries);
        Task<IList<GroceryItem>> GetUserItemsExpiringInNearFuture(Int32 userId);
        Task<IList<Groceries>> GetGroceries(Int32 userId);
        Task Consume(int itemId);
        Task UpdateNotification(int itemId);
        Task<IList<GroceryItem>> GetUserNotifications(int userId);
        Task Edit(IList<GroceryItem> groceries);
    }
}