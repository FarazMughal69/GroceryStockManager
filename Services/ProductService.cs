using GroceryStockManager.Model;
using GroceryStockManager.Models;
using GroceryStockManager.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GroceryStockManager.Services
{
    public class ProductAccessService
    {
        private readonly ProductStockContext _context;
        public ProductAccessService(ProductStockContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            try
            {
                return await _context.Suppliers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            try
            {
                var p =  await _context.Products.FindAsync(id);
                if(p == null) return new Product();
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<Supplier> GetSupplierByIDAsync(int id)
        {
            try
            {
                var p = await _context.Suppliers.FindAsync(id);
                if (p == null) 
                    return new Supplier();
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveProduct(ProductViewModel model)
        {
            try
            {
                var product = new Product
                {
                    ProductName = model.Name,
                    SupplierId = model.SupplierId,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Price = model.Price,
                    StockQuantity = model.StockQuantity,
                    ExpirationDate = model.ExpirationDate,
                    Unit = model.Unit,
                };
                _context.Products.Add(product!);
                await _context.SaveChangesAsync();
                var id = product.ProductId;
                if(id > 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
