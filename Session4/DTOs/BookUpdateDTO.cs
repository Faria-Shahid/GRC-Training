using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class BookUpdateDTO
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    [Range(1800, 2100)]
    public int Year { get; set; }

    [Range(1, int.MaxValue)]
    public int PageCount { get; set; }
}
