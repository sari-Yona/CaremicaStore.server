using System;
using System.Collections.Generic;

namespace WebApi.models;

public partial class SoppingDetail
{
    public int Id { get; set; }

    public int SoppingId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Shopping Sopping { get; set; } = null!;
}
