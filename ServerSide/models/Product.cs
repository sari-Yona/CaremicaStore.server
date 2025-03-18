using System;
using System.Collections.Generic;

namespace WebApi.models;

public partial class Product
{
    public int Id { get; set; }

    public string NameProduct { get; set; } = null!;

    public int CategoryId { get; set; }

    public int CompanyId { get; set; }

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public DateTime UpdateDate { get; set; }

    public string Picture { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<SoppingDetail> SoppingDetails { get; } = new List<SoppingDetail>();
}
