partial class Program
{
  static string[] summaries = { "Freezing", "Bracing", 
    "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", 
    "Sweltering", "Scorching" };

  internal static WeatherForecast[]? GetWeather(int days)
  {
    WeatherForecast[]? forecast = Enumerable.Range(1, days)
      .Select(index => new WeatherForecast
      (
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();

    return forecast;
  }

  internal record WeatherForecast(DateOnly Date, 
    int TemperatureC, string? Summary)
  {
    public int TemperatureF => 32 + 
      (int)(TemperatureC / 0.5556);
  }
}
