using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiHDbContext.DBContext.Models.Domain;

public class EmployeeRideHistory
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region Zones

    #region ZoneIdFrom
    //FK property
    [ForeignKey("Zone")]
    public long ZoneIdFrom { get; set; }
    #endregion

    #region ZoneIdTo
    //FK property
    [ForeignKey("Zone")]
    public long ZoneIdTo { get; set; }
    #endregion

    public virtual ICollection<Zone>? Zones { get; set; }
    #endregion

    #region CompanyEmployeeId
    //FK property
    [ForeignKey("CompanyEmployee")]
    public long CompanyEmployeeId { get; set; }

    //Navigation property
    public CompanyEmployee? CompanyEmployee { get; set; }
    #endregion

    #region RequestDateTime
    [Column(TypeName = "datetime")]
    public DateTime RequestDateTime { get; set; } = DateTime.Now;
    #endregion

    #region StartTime
    [Column(TypeName = "datetime")]
    public DateTime? StartTime { get; set; }
    #endregion

    #region FinishTime
    [Column(TypeName = "datetime")]
    public DateTime? FinishTime { get; set; }
    #endregion
}
