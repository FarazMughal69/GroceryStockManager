using GroceryStockManager.Services;
using GroceryStockManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryStockManager.Views.Shared.Components.ProductSupplier
{
    public class ProductSupplierViewComponent : ViewComponent
    {
        private readonly ProductAccessService _productAccessService;

        public ProductSupplierViewComponent(ProductAccessService productAccessService)
        {
            _productAccessService = productAccessService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string name = "", string selectedValue = "1", bool? isDisabled = false)
        {
            var viewModel = new DropdownViewModel
            {
                Name = name,
                SelectListItems = [],
                SelectedValue = selectedValue,
                IsDisabled = isDisabled ?? false
            };

            var items = await _productAccessService.GetAllSuppliersAsync();

            if (items != null)
            {
                foreach (var item in items)
                {
                    viewModel.SelectListItems.Add(new SelectListItem
                    {
                        Value = item.SupplierId.ToString(),
                        Text = item.SupplierName,
                    });
                }
            }

            return View(viewModel);
        }
    }


}
