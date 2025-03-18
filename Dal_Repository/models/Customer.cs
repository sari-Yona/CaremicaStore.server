using System;
using System.Collections.Generic;

namespace Dal_Repository.models;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateBirth { get; set; }

    public virtual ICollection<Shopping> Shoppings { get; } = new List<Shopping>();
}
