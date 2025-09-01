using AutoMapper;
using ECommerce.TechnicalTest.Data.Entities;
using ECommerce.TechnicalTest.Data.UnitOfWork;
using ECommerce.TechnicalTest.Domain.DTO;

namespace ECommerce.TechnicalTest.Services;

public class ProductService:IService<ProductDto>
{
    private IUnitOfWork _unitOfWorkInstance;
    private IMapper _iMapperInstance;
    private ProductVerifyService _productVerifyServiceInstance;
    
    public ProductService(IUnitOfWork unitOfWork, IMapper iMapper, ProductVerifyService productVerify)
    {
        this._unitOfWorkInstance = unitOfWork;
        this._iMapperInstance = iMapper;
        this._productVerifyServiceInstance=productVerify;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWorkInstance.Products.GetAllAsync();
        return _iMapperInstance.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWorkInstance.Products.GetByIdAsync(id);
        return product is null ? null : _iMapperInstance.Map<ProductDto>(product);
        
    }

    public async Task<ProductDto> CreateAsync(ProductDto item)
    {
        var entity = _iMapperInstance.Map<Product>(item);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
    
        await _unitOfWorkInstance.Products.AddAsync(entity);
        await _unitOfWorkInstance.SaveChangesAsync();

        return _iMapperInstance.Map<ProductDto>(entity);
        
    }

    public async Task<bool> UpdateAsync(ProductDto itemToUpdate)
    {
        var existing = await _unitOfWorkInstance.Products.GetByIdAsync(itemToUpdate.Id);
        if (existing is null) return false;

        _iMapperInstance.Map(itemToUpdate, existing);
        existing.UpdatedAt = DateTime.UtcNow;

        _unitOfWorkInstance.Products.Update(existing);
        await _unitOfWorkInstance.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _unitOfWorkInstance.Products.GetByIdAsync(id);
        if (product is null) return false;

        _unitOfWorkInstance.Products.Delete(product);
        await _unitOfWorkInstance.SaveChangesAsync();

        return true;
    }
}