using System;
using System.Collections.Generic;

namespace Invoices.DL.Models;

public partial class InvoicesTable
{
    public string Id { get; set; } = null!;

    public string? Status { get; set; }

    public int? Amount { get; set; }

    public DateTime? Date { get; set; }
}
