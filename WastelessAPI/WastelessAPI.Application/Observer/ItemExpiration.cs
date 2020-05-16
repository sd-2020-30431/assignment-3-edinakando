﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Observer
{
    public class ItemExpiration : Subject
    {
        private UserRepository _userRepository;
        private IGroceriesRepository _groceriesRepository;

        public ItemExpiration(UserRepository userRepository, IGroceriesRepository groceriesRepository)
        {
            _userRepository = userRepository;
            _groceriesRepository = groceriesRepository;
        }

        public async Task CheckExpirationDates()
        {
            IList<User> users = await _userRepository.GetUsers();
            Int32 DAYS_BEFORE_EXPIRATION = 5;

            foreach (var user in users)
            {
                var itemsToExpire = await _groceriesRepository.GetUserItemsExpiringInNearFuture(user.Id);

                foreach(var item in itemsToExpire)
                {
                    if(item.ExpirationDate.Date == DateTime.Now.AddDays(DAYS_BEFORE_EXPIRATION).Date)
                    {
                        Notify(user.Id, new Models.Groceries.GroceryItem(item));
                    }
                }
            }
        }
    }
}