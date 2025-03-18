using System;
using System.Collections.Generic;

namespace WebApi.models;

public partial class Shopping
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime Date { get; set; }

    public double Sum { get; set; }

    public string? Remark { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SoppingDetail> SoppingDetails { get; } = new List<SoppingDetail>();
}
