using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiHDbContext.DBContext.Models.Domain;

public class CompanyNumbers
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region CompanyAvailabilityId
    //FK property
    [ForeignKey("CompanyAvailability")]
    public long CompanyAvailabilityId { get; set; }

    //Navigation property
    public CompanyAvailability? CompanyAvailability { get; set; }
    #endregion

    #region PhoneNumber
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string PhoneNumber { get; set; } = string.Empty;
    #endregion

    #region CompanyEmployeeId
    //FK property
    [ForeignKey("CompanyEmployee")]
    public long CompanyEmployeeId { get; set; }

    //Navigation property
    public CompanyEmployee? CompanyEmployee { get; set; }
    #endregion
}
