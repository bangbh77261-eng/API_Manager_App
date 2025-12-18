using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Warehouse
{
    [Key]
    public int WarehouseID { get; set; }
    public string WarehouseCode { get; set; }
    public string WarehouseName { get; set; }
    [MaxLength(500)]
    public string Address { get; set; }
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    [MaxLength(200)]
    public string ManagerName { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual ICollection<StorageLocation> Locations { get; set; }
}

public class StorageLocation
{
    [Key]
    public int LocationID { get; set; }
    public int WarehouseID { get; set; }
    public string LocationCode { get; set; }
    public string LocationName { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }

    [ForeignKey("WarehouseID")]
    public virtual Warehouse Warehouse { get; set; }
}

public class ProductCategory
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryCode { get; set; }
    public string CategoryName { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Product> Products { get; set; }
}

public class Product
{
    [Key]
    public int ProductID { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    [MaxLength(200)]
    public string ManufactureLocation { get; set; }
    public int? CategoryID { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal VAT { get; set; } = 0;
    [MaxLength(200)]
    public string Barcode { get; set; }
    public int? CurrentLocationID { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [MaxLength(500)]
    public string ImageURL { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    [ForeignKey("CategoryID")]
    public virtual ProductCategory Category { get; set; }
    [ForeignKey("CurrentLocationID")]
    public virtual StorageLocation CurrentLocation { get; set; }
}

public class Inventory
{
    [Key]
    public int InventoryID { get; set; }
    public int WarehouseID { get; set; }
    public int ProductID { get; set; }
    public int TotalQuantityIn { get; set; } = 0;
    public int TotalQuantityOut { get; set; } = 0;
    public int DamagedQuantity { get; set; } = 0;
    [NotMapped]
    public int ActualQuantity => TotalQuantityIn - TotalQuantityOut - DamagedQuantity;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    [MaxLength(500)]
    public string Notes { get; set; }

    [ForeignKey("WarehouseID")]
    public virtual Warehouse Warehouse { get; set; }
    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
}
