using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public class ProductLine :BaseEntity
{
    public string ProductLine1 { get; set; } = null!;

    public string? DescriptionText { get; set; }

    public string? DescriptionHtml { get; set; }

    public string? Image { get; set; }
=======
public partial class ProductLine : BaseEntityString
{

    public string DescriptionText { get; set; }

    public string DescriptionHtml { get; set; }

    public string Image { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
