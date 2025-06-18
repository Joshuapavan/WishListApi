using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WishListApi.Models;

public class Wish
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required string WishText { get; set; }
    public string? WishDescription { get; set; }
    [DefaultValue(false)]
    public bool IsCompleted { get; set; } = false;
}