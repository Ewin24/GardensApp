using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public  class OrderDetail :BaseEntity
{
    public int OrderCode { get; set; }
=======
public partial class OrderDetail : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
public partial class OrderDetail : BaseEntity
{
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public short LineNumber { get; set; }

    public virtual Order OrderCodeNavigation { get; set; } = null!;

    public virtual Product ProductCodeNavigation { get; set; } = null!;
}
