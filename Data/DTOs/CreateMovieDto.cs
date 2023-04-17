using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.DTOs;

public class CreateMovieDto
{
    
    [Required (ErrorMessage = "The title is required")]
    [StringLength(100, ErrorMessage = "The title must be less than 100 characters")]
    public string Title { get; set; }

    [Required (ErrorMessage = "The genre is required")]
    [MaxLength(50, ErrorMessage = "The genre must be less than 50 characters")]
    public string Genre { get; set; }

    [Required (ErrorMessage = "The duration is required")]
    [Range(70, 300, ErrorMessage = "The duration must be between 70 and 300 minutes")]
    public int Duration { get; set; }
}