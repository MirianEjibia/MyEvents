using System;

namespace Core;

public class Event
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCancelled { get; set; }

    public required string Country { get; set; }
    public required string City { get; set; }
    public double  Parallel {get;set;}
    public double Meridian {get; set;}
}