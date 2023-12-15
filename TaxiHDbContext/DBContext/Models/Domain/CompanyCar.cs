using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaxiHDbContext.DBContext.Models.Shared;

namespace TaxiHDbContext.DBContext.Models.Domain;
public class CompanyCar : RegistersSharedModel
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region CompanyId
    //FK property
    [ForeignKey("Company")]
    public long CompanyId { get; set; }

    //Navigation property
    public Company? Company { get; set; }
    #endregion

    #region CarName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string CarName { get; set; } = string.Empty;
    #endregion

    #region Description
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string Description { get; set; } = string.Empty;
    #endregion
}
