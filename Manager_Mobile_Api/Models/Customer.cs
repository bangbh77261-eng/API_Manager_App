using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    [MaxLength(50)]
    public string TaxCode { get; set; }
    [MaxLength(500)]
    public string Address { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(20)]
    public string IDNumber { get; set; }
    [MaxLength(50)]
    public string CustomerType { get; set; } = "Cá nhân";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public int? LevelID { get; set; }
    public decimal TotalPurchaseAmount { get; set; } = 0;

    [ForeignKey("LevelID")]
    public virtual LevelUser Level { get; set; }
}

public class Supplier
{
    [Key]
    public int SupplierID { get; set; }
    public string SupplierCode { get; set; }
    public string SupplierName { get; set; }
    [MaxLength(500)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string TaxCode { get; set; }
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    [MaxLength(20)]
    public string Hotline { get; set; }
    [MaxLength(200)]
    public string Representative { get; set; }
    [MaxLength(20)]
    public string RepresentativeIDNumber { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }
    public string EmployeeCode { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int? Age { get; set; }
    [MaxLength(20)]
    public string IDNumber { get; set; }
    [MaxLength(50)]
    public string TaxCode { get; set; }
    public DateTime StartDate { get; set; }
    [NotMapped]
    public int WorkingYears => (DateTime.Now - StartDate).Days / 365;
    [NotMapped]
    public int WorkingMonths => (DateTime.Now - StartDate).Days / 30;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}