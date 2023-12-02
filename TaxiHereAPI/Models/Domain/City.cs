using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiHereAPI.Models.Domain;
public class City
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get;set; }
    #endregion

    #region CityName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(50)]
    public string CityName { get; set; } = string.Empty;
    #endregion

    #region Country
    //FK property
    [ForeignKey("Country")]
    public long CountryId { get; set; }

    //Navigation property
    public Country? Country { get; set; } 
    #endregion

    #region CityCode
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(3)]
    [MinLength(3)]
    public string CityCode { get; set; } = string.Empty;
    #endregion

    /* This field is set to 'true' if the application is available in the city. */
    #region Available
    [Column(TypeName = "bit")]
    public bool? Available { get; set; }
    #endregion

    /* This number is updated every time a new taxi company is added to the application. */
    #region NumberOfActiveCompanies
    [Column(TypeName = "smallint")]
    public int NumberOfActiveCompanies { get; set; } = 0;
    #endregion
}
