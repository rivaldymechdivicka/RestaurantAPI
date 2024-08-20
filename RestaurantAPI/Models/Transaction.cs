using System;
using System.Collections.Generic;

namespace RestaurantAPI.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int CustomerId { get; set; }

    public int FoodId { get; set; }

    public int Qty { get; set; }

    public int TotalPrice { get; set; }

    public DateOnly TransactionDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
