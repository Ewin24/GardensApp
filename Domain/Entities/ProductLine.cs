using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public class ProductLine :BaseEntity
{
    public string ProductLine1 { get; set; } = null!;

    public string? DescriptionText { get; set; }

    public string? DescriptionHtml { get; set; }

    public string? Image { get; set; }
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
public partial class ProductLine : BaseEntityString
{

    public string DescriptionText { get; set; }

    public string DescriptionHtml { get; set; }

    public string Image { get; set; }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
