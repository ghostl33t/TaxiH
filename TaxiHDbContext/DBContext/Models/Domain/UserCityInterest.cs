using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiHDbContext.DBContext.Models.Domain;
public class UserCityInterest
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region UserId
    //FK property
    [ForeignKey("User")]
    public long UserId { get; set; }

    //Navigation property
    public User? User { get; set; }
    #endregion

    #region CityId
    //FK property
    [ForeignKey("City")]
    public long CityId { get; set; }

    //Navigation property
    public City? City { get; set; }
    #endregion
}
