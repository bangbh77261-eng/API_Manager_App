using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GoodsReceipt
{
    [Key]
    public int ReceiptID { get; set; }
    public string ReceiptCode { get; set; }
    public DateTime ReceiptDate { get; set; } = DateTime.Now.Date;
    public int SupplierID { get; set; }
    public int EmployeeID { get; set; }
    public int WarehouseID { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; } = 0;
    [MaxLength(1000)]
    public string Notes { get; set; }
    [MaxLength(50)]
    public string Status { get; set; } = "Đã nhập";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int? CreatedBy { get; set; }

    [ForeignKey("SupplierID")]
    public virtual Supplier Supplier { get; set; }
    [ForeignKey("EmployeeID")]
    public virtual Employee Employee { get; set; }
    [ForeignKey("WarehouseID")]
    public virtual Warehouse Warehouse { get; set; }
    public virtual ICollection<GoodsReceiptDetail> Details { get; set; }
}

public class GoodsReceiptDetail
{
    [Key]
    public int DetailID { get; set; }
    public int ReceiptID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal VAT { get; set; } = 0;
    [NotMapped]
    public decimal TotalAmount => Quantity * UnitPrice * (1 + VAT / 100);
    [MaxLength(100)]
    public string InvoiceNumber { get; set; }
    [MaxLength(500)]
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey("ReceiptID")]
    public virtual GoodsReceipt Receipt { get; set; }
    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
}

public class GoodsIssue
{
    [Key]
    public int IssueID { get; set; }
    public string IssueCode { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.Now.Date;
    public int EmployeeID { get; set; }
    public int? CustomerID { get; set; }
    [MaxLength(200)]
    public string RecipientName { get; set; }
    [MaxLength(20)]
    public string RecipientPhone { get; set; }
    public int WarehouseID { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; } = 0;
    [MaxLength(1000)]
    public string Notes { get; set; }
    [MaxLength(50)]
    public string Status { get; set; } = "Đã xuất";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int? CreatedBy { get; set; }

    [ForeignKey("EmployeeID")]
    public virtual Employee Employee { get; set; }
    [ForeignKey("CustomerID")]
    public virtual Customer Customer { get; set; }
    [ForeignKey("WarehouseID")]
    public virtual Warehouse Warehouse { get; set; }
    public virtual ICollection<GoodsIssueDetail> Details { get; set; }
}

public class GoodsIssueDetail
{
    [Key]
    public int DetailID { get; set; }
    public int IssueID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal VAT { get; set; } = 0;
    [NotMapped]
    public decimal TotalAmount => Quantity * UnitPrice * (1 + VAT / 100);
    [MaxLength(100)]
    public string InvoiceNumber { get; set; }
    [MaxLength(500)]
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey("IssueID")]
    public virtual GoodsIssue Issue { get; set; }
    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
}

public class SalesTransaction
{
    [Key]
    public int TransactionID { get; set; }
    public string TransactionCode { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    public int? CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; } = 0;
    [NotMapped]
    public decimal FinalAmount => TotalAmount - DiscountAmount;
    [MaxLength(50)]
    public string PaymentMethod { get; set; }
    [MaxLength(50)]
    public string Status { get; set; } = "Hoàn thành";
    [MaxLength(1000)]
    public string Notes { get; set; }

    [ForeignKey("CustomerID")]
    public virtual Customer Customer { get; set; }
    [ForeignKey("EmployeeID")]
    public virtual Employee Employee { get; set; }
}