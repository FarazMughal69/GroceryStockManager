using GroceryStockManager.Models;
using GroceryStockManager.Services;
using GroceryStockManager.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStockManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductAccessService _productService;
        public ProductController(ProductAccessService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Products()
        {
            var productsLst = await _productService.GetAllProductsAsync();
            var categoriesLst = await _productService.GetAllCategoriesAsync();
            var suppliersLst = await _productService.GetAllSuppliersAsync();
            if (productsLst.Count == 0)
                return View(null);
            List<ProductViewModel> p = new List<ProductViewModel>();
            foreach (var product in productsLst)
            {
                ProductViewModel m = new ProductViewModel
                {
                    Id = product.ProductId,
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    Name = product.ProductName,
                    Price = product.Price,
                    Unit = product.Unit,
                    Description = product.Description,
                };
                if (suppliersLst.Count > 0)
                {
                    var Supplier = suppliersLst.FirstOrDefault(s => s.SupplierId == m.SupplierId!);
                    if (Supplier != null)
                        m.Supplier = Supplier!.SupplierName;
                }
                if (categoriesLst.Count > 0)
                {
                    var category = categoriesLst.FirstOrDefault(s => s.CategoryId == m.CategoryId);
                    if (category != null)
                        m.Category = category!.CategoryName;
                }
                p.Add(m);
            }
            return View(p);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
                return BadRequest("Id Can not be null");
            var product = await _productService.GetProductByIDAsync((int)Id!);
            if (product == null)
                return NotFound();
            //var supplier = await _productService.
            return PartialView("_Details", product);
        }

        public IActionResult AddNewProduct()
        {

            return PartialView("_AddNewProduct", new ProductViewModel());
        }
        [HttpPost]
        public async Task<bool> SaveProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            bool responce = await _productService.SaveProduct(model);
            if (responce)
                return true;
            return false;
        }
    }
}
