using EcomPortal.Models;
using EcomPortal.Models.Entities;

namespace EcomPortal.Repositories
{
    public class UserRepository : CrudRepository<Order>
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            ApplicationDbContext _context = context;
        }
    }
}
