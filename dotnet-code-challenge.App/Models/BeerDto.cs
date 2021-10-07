namespace DotNetCodeChallenge.Models
{
    public class BeerDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MinimumTemperature { get; set; }

        public int MaximumTemperature { get; set; }

        public int Temperature  { get; set; }
    }
}