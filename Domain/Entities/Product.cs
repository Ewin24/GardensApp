using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public  class Product :BaseEntity
{
    public string ProductCode { get; set; } = null!;

=======
public partial class Product : BaseEntityString
{
    public string ProductCode { get; set; } = null!;
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
public partial class Product : BaseEntityString
{
    public string ProductCode { get; set; } = null!;
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
    public string Name { get; set; } = null!;

    public string ProductLine { get; set; } = null!;

<<<<<<< HEAD
<<<<<<< HEAD
    public string? Dimensions { get; set; }

    public string? Supplier { get; set; }

    public string? Description { get; set; }
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
    public string Dimensions { get; set; }

    public string Supplier { get; set; }

    public string Description { get; set; }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public short StockQuantity { get; set; }

    public decimal SellingPrice { get; set; }

<<<<<<< HEAD
    public decimal? SupplierPrice { get; set; }

    public int? IdProveedorFk { get; set; }

    public virtual Proveedor? IdProveedorFkNavigation { get; set; }
=======
    public decimal SupplierPrice { get; set; }

    public int IdProviderFk { get; set; }

    public virtual Proveedor IdProviderFkNavigation { get; set; }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> origin/main
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductLine ProductLineNavigation { get; set; } = null!;
}
