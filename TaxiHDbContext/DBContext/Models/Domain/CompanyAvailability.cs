using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiHDbContext.DBContext.Models.Shared;

namespace TaxiHDbContext.DBContext.Models.Domain;
public class CompanyAvailability : RegistersSharedModel
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get;set; }
    #endregion

    #region CityId
    //FK property
    [ForeignKey("City")]
    public long CityId { get; set; }

    //Navigation property
    public City? City { get; set; }
    #endregion

    #region CompanyId
    //FK property
    [ForeignKey("Company")]
    public long CompanyId { get; set; }

    //Navigation property
    public Company? Company { get; set; }
    #endregion
}
