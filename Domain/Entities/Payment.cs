using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public class Payment :BaseEntity
{
=======
public partial class Payment : BaseEntityString
{

>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
    public string PaymentMethod { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public decimal Total { get; set; }

    public int ClientCode { get; set; }

    public virtual Client ClientCodeNavigation { get; set; } = null!;
}
