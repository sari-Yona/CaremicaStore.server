﻿using System;
using System.Collections.Generic;

namespace Dal_Repository.models;

public partial class Company
{
    public int Id { get; set; }

    public string NameCompany { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
