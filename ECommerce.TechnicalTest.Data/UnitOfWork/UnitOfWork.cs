using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.Repository;

namespace ECommerce.TechnicalTest.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ECommerceTechnicalTestDataContext _contextInstance;

    public UnitOfWork(ECommerceTechnicalTestDataContext context)
    {
        this._contextInstance = context;
    }

    private IGenericRepository<Product> _products;
    private IGenericRepository<Order> _orders;
    private IGenericRepository<OrderItemDetail> _orderItemDetails;

    public IGenericRepository<Product> Products
    {
        get
        {
            if (_products is null)
                _products = new ECommerceRepository<Product>(_contextInstance);
            return _products;
        }
    }

    public IGenericRepository<Order> Orders
    {
        get
        {
            if (_orders is null)
                _orders = new ECommerceRepository<Order>(_contextInstance);
            return _orders;
        }
    }

    public IGenericRepository<OrderItemDetail> OrderItemDetails
    {
        get
        {
            if (_orderItemDetails is null)
                _orderItemDetails = new ECommerceRepository<OrderItemDetail>(_contextInstance);
            return _orderItemDetails;
        }
    }

    public Task<int> SaveChangesAsync()
    {
        return _contextInstance.SaveChangesAsync();
    }


    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _contextInstance.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}