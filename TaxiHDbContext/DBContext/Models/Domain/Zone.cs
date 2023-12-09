using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiHDbContext.DBContext.Models.Domain;
public class Zone
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region City
    //FK property
    [ForeignKey("City")]
    public long CityId { get; set; }

    //Navigation property
    public City? City { get; set; }
    #endregion

    #region ZoneName 
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(20)]
    public string ZoneName { get; set; } = string.Empty;
    #endregion

    #region ZoneCode
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(5)]
    [MinLength(5)]
    public string ZoneCode { get; set; } = string.Empty;
    #endregion
}
