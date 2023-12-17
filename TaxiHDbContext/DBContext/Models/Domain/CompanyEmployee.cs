using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiHDbContext.DBContext.Models.Shared;

namespace TaxiHDbContext.DBContext.Models.Domain;

public class CompanyEmployee : RegistersSharedModel
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region EmployeeName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(20)]
    public string EmployeeName { get; set; } = string.Empty;
    #endregion

    #region EmployeeLastName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string EmployeeLastName { get; set; } = string.Empty;
    #endregion

    #region PrivatePhoneNumber
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string PrivatePhoneNumber { get; set; } = string.Empty;
    #endregion

    #region Email
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    [MinLength(5)]
    public string Email { get; set; } = string.Empty;
    #endregion

    #region CompanyId
    //FK property
    [ForeignKey("Company")]
    public long CompanyId { get; set; }

    //Navigation property
    public Company? Company { get; set; }
    #endregion

    #region CompanyCarId
    //FK property
    [ForeignKey("CompanyCar")]
    public long CompanyCarId { get; set; }

    //Navigation property
    public CompanyCar? CompanyCar { get; set; }
    #endregion

    #region ZoneId
    //FK property
    [ForeignKey("Zone")]
    public long ZoneId { get; set; }

    //Navigation property
    public Zone? Zone { get; set; }
    #endregion
}
