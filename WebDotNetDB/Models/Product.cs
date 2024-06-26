using System;
using System.Collections.Generic;

namespace WebDotNetDB.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public DateOnly? Created { get; set; }

    public string? Photo { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
