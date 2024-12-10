using EcomPortal.Models;
using EcomPortal.Models.Entities;

namespace EcomPortal.Repositories
{
    public class ProductRepository : CrudRepository<Order>
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            ApplicationDbContext _context = context;
        }
    }
}
