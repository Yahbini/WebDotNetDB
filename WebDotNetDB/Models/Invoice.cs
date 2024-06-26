using System;
using System.Collections.Generic;

namespace WebDotNetDB.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Created { get; set; }

    public string Status { get; set; } = null!;

    public string Payment { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
