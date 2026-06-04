using System;
using System.ComponentModel.DataAnnotations;

namespace UseCases.Events.DTOs;

public class CraeteEventDto
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Description { get; set; }= "";
    public DateTime StartDate { get; set; }
    [Required]
    public string Country { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    public double  Parallel {get;set;}
    public double Meridian {get; set;}
    
}