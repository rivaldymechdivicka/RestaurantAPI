using System;
using System.Collections.Generic;

namespace RestaurantAPI.Models;

public partial class Food
{
    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public int Price { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
