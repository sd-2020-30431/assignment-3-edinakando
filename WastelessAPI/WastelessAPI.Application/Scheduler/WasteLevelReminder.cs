using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Scheduler
{
    public class WasteLevelReminder : IInvocable
    {
        private UserRepository _userRepository;
        private IGroceriesRepository _groceriesRepository;

        public WasteLevelReminder(UserRepository userRepository, IGroceriesRepository groceriesRepository)
        {
            _userRepository = userRepository;
            _groceriesRepository = groceriesRepository;
        }

        public async Task Invoke()
        {
            IList<User> users = await _userRepository.GetUsers();
            Int32 RECOMMENDED_CALLORIES_PER_DAY = 2000;
            Int32 MAX_WASTE_ALLOWED = 200;

            foreach(var user in users)
            {
                IList<GroceryItem> itemsToExpire = await _groceriesRepository.GetUserItemsExpiringInNearFuture(user.Id);
                Double idealCaloriesPerDay = 0;
                
                foreach(var item in itemsToExpire)
                {
                    Double daysUntilExpired = (item.ExpirationDate - DateTime.Now).TotalDays;
                    idealCaloriesPerDay += item.Calories / daysUntilExpired;
                }

                Double waste = idealCaloriesPerDay - RECOMMENDED_CALLORIES_PER_DAY;
                if (waste > MAX_WASTE_ALLOWED)
                {
                    _SendNotification(user.Id, waste);
                }
            }
        }

        private void _SendNotification(Int32 userId, Double waste)
        {
        }
    }
}
