using Supermarket.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    public class AddToCartRepository : BaseRepository, IAddToCartRepository
    {
        public AddToCartRepository(AppDbContext context) : base(context){
        }
       public async Task<IEnumerable<Product>> GetProductListById(List<int> idList){
           
           return await _context.Products.FindAsync(idList => id);
        }
    }
}