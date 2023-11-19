using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public class Order:BaseEntity
{ 
    public int OrderCode { get; set; }
=======
public partial class Order : BaseEntity
{
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
public partial class Order : BaseEntity
{
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public DateOnly OrderDate { get; set; }

    public DateOnly ExpectedDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string Status { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public int ClientCode { get; set; }

    public virtual Client ClientCodeNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
