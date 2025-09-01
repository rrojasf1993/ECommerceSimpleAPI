namespace ECommerce.TechnicalTest.Services;

public interface IService<TItem> where TItem : class 
{
    Task<IEnumerable<TItem>> GetAllAsync();
    Task<TItem?> GetByIdAsync(int id);
    Task<TItem> CreateAsync(TItem item);
    Task<bool> UpdateAsync(TItem itemToUpdate);
    Task<bool> DeleteAsync(int id);
}