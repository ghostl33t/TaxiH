using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiHereAPI.Models.Domain;
public class User
{
    #region Id
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    #endregion

    #region UserName
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(10)]
    [MinLength(5)]
    public string UserName { get; set; } = string.Empty;
    #endregion

    #region Phone
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(20)]
    [MinLength(9)]
    public string Phone { get; set; } = string.Empty;
    #endregion

    #region Email
    [Column(TypeName = "nvarchar")]
    [MaxLength(25)]
    public string? Email { get; set; }
    #endregion

    #region Password
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(16)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
    #endregion

    #region Deleted
    [Column(TypeName = "bit")]
    public bool? Deleted { get; set; }
    #endregion

    #region CreatedAt
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; } = DateTime.Today;
    #endregion
}
