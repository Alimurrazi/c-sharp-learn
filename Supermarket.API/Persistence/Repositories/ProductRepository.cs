using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository 
    {
        public ProductRepository(AppDbContext context) : base (context){
        }

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _context.Products.Include(p=>p.Category).ToListAsync();
        }
    }
}