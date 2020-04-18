using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;


namespace Supermarket.API.Persistence.Repositories
{
    public class SuperShopRepository : BaseRepository, ISuperShopRepository
    {

        public SuperShopRepository(AppDbContext context): base(context){
        }
        public async Task<SuperShop> FindByAsync(int id){
            return await _context.SuperShops.FindAsync(id);
        }
    }
}