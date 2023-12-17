using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiHDbContext.DBContext.Models.Shared;

public class RegistersSharedModel
{
    #region CreatedOn
    [Column(TypeName ="datetime")]
    public DateTime CreatedOn { get;set; }
    #endregion
    #region Status
    [Column(TypeName = "smallint")]
    public RegisterStatus Status { get; set; } = RegisterStatus.Deactivated;
    #endregion
}
public enum RegisterStatus
{ 
    Deactivated = 0,
    Active = 1,
    Deleted = 2,
}
