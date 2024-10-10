using System;
using System.Collections.Generic;

namespace GroceryStockManager.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? Unit { get; set; }

    public string? Description { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
