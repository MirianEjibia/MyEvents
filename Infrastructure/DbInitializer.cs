using Core;

namespace Infrastructure;

public class DbInitializer
{
    public static async Task SeedData (ApplicationDbContext context)
    {
        if(context.Events.Any()) return;

        string[] eventTypes = ["Tech Meetup", "Music Festival", "Food Expo", "Startup Summit", "Art Fair", "Wellness Retreat"];
        string[] cities = ["Lagos", "Nairobi", "Cape Town", "Kigali", "Accra", "Cairo"];
        string[] countries = ["Nigeria", "Kenya", "South Africa", "Rwanda", "Ghana", "Egypt"];
        string[] descriptions =
        [
            "A curated gathering with speakers, networking, and live sessions.",
            "An all-day experience featuring workshops, panels, and community activities.",
            "A multi-track event bringing together guests, creators, and sponsors.",
            "An immersive program focused on learning, collaboration, and discovery."
        ];

        var events = Enumerable.Range(0, 12)
            .Select(index =>
            {
                int locationIndex = Random.Shared.Next(cities.Length);
                DateTime startDate = DateTime.UtcNow.Date.AddDays(Random.Shared.Next(5, 180)).AddHours(Random.Shared.Next(8, 18));

                return new Event
                {
                    Name = $"{eventTypes[Random.Shared.Next(eventTypes.Length)]} {index + 1}",
                    Description = descriptions[Random.Shared.Next(descriptions.Length)],
                    StartDate = startDate,
                    EndDate = startDate.AddHours(Random.Shared.Next(2, 8)),
                    IsCancelled = Random.Shared.NextDouble() < 0.1,
                    Country = countries[locationIndex],
                    City = cities[locationIndex],
                    Parallel = Math.Round(Random.Shared.NextDouble() * 140 - 35, 6),
                    Meridian = Math.Round(Random.Shared.NextDouble() * 360 - 180, 6)
                };
            })
            .ToList();

        context.Events.AddRange(events);
        context.SaveChanges();
    }
}