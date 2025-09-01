using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.Repository;

namespace ECommerce.TechnicalTest.Data.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<OrderItemDetail> OrderItemDetails { get; }

    Task<int> SaveChangesAsync();

}