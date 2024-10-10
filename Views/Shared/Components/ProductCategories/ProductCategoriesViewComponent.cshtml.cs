using GroceryStockManager.Services;
using GroceryStockManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryStockManager.Views.Shared.Components.ProductSuppliers
{
    public class ProductCategoriesViewComponent : ViewComponent
    {
        private readonly ProductAccessService _productAccessService;

        public ProductCategoriesViewComponent(ProductAccessService productAccessService)
        {
            _productAccessService = productAccessService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name = "", string SelectedValue = "", bool isDisabled = false)
        {
            var ddvm = new DropdownViewModel
            {
                Name = name,
                SelectedValue = SelectedValue,
                IsDisabled = isDisabled,
                SelectListItems = [],
            };
            var records = await _productAccessService.GetAllCategoriesAsync();
            if (records.Count < 1)
                return View();
            foreach (var record in records)
            {
                ddvm.SelectListItems.Add(new SelectListItem
                {
                    Value = record.CategoryId.ToString(),
                    Text = record.CategoryName,

                });
            }
            return View(ddvm);
        }
    }
}
