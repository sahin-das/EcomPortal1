using EcomPortal.Models;
using EcomPortal.Models.Entities;

namespace EcomPortal.Repositories
{
    public class OrderProductRepository : CrudRepository<Order>
    {
        public OrderProductRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
