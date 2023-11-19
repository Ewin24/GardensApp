using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class Product :BaseEntity
{
    public string ProductCode { get; set; } = null!;

=======
public partial class Product : BaseEntityString
{
    public string ProductCode { get; set; } = null!;
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
    public string Name { get; set; } = null!;

    public string ProductLine { get; set; } = null!;

<<<<<<< HEAD
    public string? Dimensions { get; set; }

    public string? Supplier { get; set; }

    public string? Description { get; set; }
=======
    public string Dimensions { get; set; }

    public string Supplier { get; set; }

    public string Description { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

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
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductLine ProductLineNavigation { get; set; } = null!;
}
