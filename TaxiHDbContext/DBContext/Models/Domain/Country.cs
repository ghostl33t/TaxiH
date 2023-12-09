using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxiHDbContext.DBContext.Models.Enums;

namespace TaxiHDbContext.DBContext.Models.Domain;
public class Country
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region CountryName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(50)]
    public string CountryName { get; set; } = string.Empty;
    #endregion

    #region Continent
    [Required]
    [Column(TypeName = "smallint")]
    public Continent Contitnet { get; set; }
    #endregion

    #region CountryCode
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(5)]
    [MinLength(5)]
    public string CountryCode { get; set; } = string.Empty;
    #endregion

    /* This field is 'true' if the application is available in country.*/
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


