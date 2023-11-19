using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class OrderDetail :BaseEntity
{
    public int OrderCode { get; set; }
=======
public partial class OrderDetail : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public short LineNumber { get; set; }

    public virtual Order OrderCodeNavigation { get; set; } = null!;

    public virtual Product ProductCodeNavigation { get; set; } = null!;
}
