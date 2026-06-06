using System;
using System.ComponentModel.DataAnnotations;

namespace UseCases.Events.DTOs;

public class CraeteEventDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; }= "";
    public DateTime StartDate { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public double  Parallel {get;set;}
    public double Meridian {get; set;}
    
}