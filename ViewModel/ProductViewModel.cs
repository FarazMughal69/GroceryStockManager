using GroceryStockManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryStockManager.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        [DisplayName("Supplier")]
        public string? Supplier { get; set; } 
        public string? Category { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int StockQuantity { get; set; }
        [DisplayName("Expiry Date")]
        [DataType(DataType.Date)]
        public DateOnly? ExpirationDate { get; set; }

        [DisplayName("Unit")]
        public string? Unit { get; set; }

    }

    public class DropdownViewModel
    {
        public required string Name { get; set; }
        public required string SelectedValue { get; set; }
        public bool IsDisabled { get; set; }
        public Collection<SelectListItem>? SelectListItems { get; set; }
    }
}
