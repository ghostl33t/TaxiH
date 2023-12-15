using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiHDbContext.DBContext.Models.Shared;

namespace TaxiHDbContext.DBContext.Models.Domain;

public class Company : RegistersSharedModel
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get;set; }
    #endregion

    #region CompanyName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(100)]
    [MinLength(4)]
    public string CompanyName { get; set; } = string.Empty;
    #endregion

    #region CompanyCode
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(5)]
    [MinLength(5)]
    public string CompanyCode { get; set; } = string.Empty;
    #endregion

    #region Validated
    [Required]
    [Column(TypeName = "bit")]
    public bool Validated { get; set; } = false;
    #endregion

    #region HQPhone
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    [MinLength(9)]
    public string HQPhone { get; set; } = string.Empty;
    #endregion

    #region HQAdress
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(200)]
    [MinLength(10)]
    public string HQAdress { get; set; } = string.Empty;
    #endregion

    #region Email
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    [MinLength(5)]
    public string Email { get; set; } = string.Empty;
    #endregion
}
