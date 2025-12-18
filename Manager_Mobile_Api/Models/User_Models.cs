// 1. USER MANAGEMENT MODELS
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manager_mobile_Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

public class LevelUser
{
    [Key]
    public int LevelID { get; set; }
    public string LevelCode { get; set; }
    public string LevelName { get; set; }
    public int LevelValue { get; set; } = 1;
    public decimal DiscountPercent { get; set; } = 0;
    public decimal MinPurchaseForDiscount { get; set; } = 0;
    public decimal MinTotalPurchaseForUpgrade { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}

public class UserKey
{
    [Key]
    public int UserID { get; set; }
    [MaxLength(20)]
    public string UserName { get; set; }
    public string CMND { get; set; }
    public int? Age { get; set; }
    [MaxLength(10)]
    public string Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; } = false;
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    [MaxLength(500)]
    public string Avatar { get; set; }
    [MaxLength(10)]
    public string LanguageSave { get; set; } = "vi-VN";
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? LastLoginDate { get; set; }
    [MaxLength(500)]
    public string Address { get; set; }
    public int? LevelID { get; set; }
    public bool IsActive { get; set; } = true;
    //public virtual ICollection<UserRoleAssignment> RoleAssignments { get; set; }
    //public virtual ICollection<LevelUser> LevelUsers { get; set; }
}

public class UserRole
{
    [Key]
    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public string RoleCode { get; set; }
    [MaxLength(500)]
    public string RoleDescription { get; set; }
    [MaxLength(100)]
    public string RoleGroup { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

   // public virtual ICollection<UserRoleAssignment> RoleAssignments { get; set; }
}

public class UserRoleAssignment
{
    [Key]
    public int AssignmentID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime AssignedDate { get; set; } = DateTime.Now;

    [ForeignKey("UserID")]
    public virtual UserKey User { get; set; }
    [ForeignKey("RoleID")]
    public virtual UserRole Role { get; set; }
}

[Keyless]
public class UserCompleteInfoView
{
    // UserKey
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string? CMND { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public bool IsEmailVerified { get; set; }
    public string? PasswordHash { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Avatar { get; set; }
    public string? LanguageSave { get; set; }
    public DateTime UserCreatedDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public string Address { get; set; }
    public int? LevelID { get; set; }
    public bool UserIsActive { get; set; }

    // LevelUser
    public string? LevelCode { get; set; }
    public string? LevelName { get; set; }
    public int? LevelValue { get; set; }
    public decimal? DiscountPercent { get; set; }
    public decimal? MinPurchaseForDiscount { get; set; }
    public decimal? MinTotalPurchaseForUpgrade { get; set; }
    public DateTime? LevelCreatedDate { get; set; }
    public DateTime? LevelUpdatedDate { get; set; }

    // UserRoleAssignment
    public int? AssignmentID { get; set; }
    public int? RoleID { get; set; }
    public bool? AssignmentIsActive { get; set; }
    public DateTime? AssignedDate { get; set; }

    // UserRole
    public string? RoleName { get; set; }
    public string? RoleCode { get; set; }
    public string? RoleDescription { get; set; }
    public string? RoleGroup { get; set; }
    public DateTime? RoleCreatedDate { get; set; }
    public bool? RoleIsActive { get; set; }
}