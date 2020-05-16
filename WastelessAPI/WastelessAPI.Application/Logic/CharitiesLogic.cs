using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Logic
{
    public class CharitiesLogic
    {
        private readonly CharitiesRepository _charitiesRepository;
        private readonly IGroceriesRepository _groceriesRepository;

        public CharitiesLogic(CharitiesRepository charitiesRepository, IGroceriesRepository groceriesRepository)
        {
            _charitiesRepository = charitiesRepository;
            _groceriesRepository = groceriesRepository;
        }

        public async Task<IList<Charity>> GetCharities()
        {
            return await _charitiesRepository.GetAll();
        }

        public async Task Donate(Donation donation)
        {
            await _charitiesRepository.Donate(donation);
            await _groceriesRepository.Consume(donation.ItemId);
        }
    }
}
