using CerealAPI.Data;

namespace CerealAPI
{
    public class Seed(CerealContext context)
    {
        private readonly CerealContext cerealContext = context;

        public void SeedDataContext()
        {
            if (!cerealContext.Cereals.Any())
            {
                var manufacturers = new List<Model.Manufacturer>
                {
                    new() { Shortform = 'G', Name = "General Mills" },
                    new() { Shortform = 'K', Name = "Kellogg's" },
                    new() { Shortform = 'N', Name = "Nabisco" },
                    new() { Shortform = 'P', Name = "Post" },
                    new() { Shortform = 'Q', Name = "Quaker Oats" }
                };
                cerealContext.Manufacturers.AddRange(manufacturers);
                var types = new List<Model.Type>
                {
                    new() { Shortform = 'C', Name = "Cold" },
                    new() { Shortform = 'H', Name = "Hot" }
                };
                cerealContext.Types.AddRange(types);

                using (StreamReader sr = new StreamReader("Data/cereal.csv"))
                {
                    var headerLine = sr.ReadLine(); // Read and ignore the header line
                    var typeLine = sr.ReadLine(); // Read and ignore the types line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(';');
                        var cereal = new Model.Cereal
                        {
                            Name = values[0],
                            Mfr = manufacturers.Find(m => m.Shortform == values[1][0]),
                            Type = types.Find(t => t.Shortform == values[2][0]),
                            Calories = int.Parse(values[3]),
                            Protein = int.Parse(values[4]),
                            Fat = int.Parse(values[5]),
                            Sodium = int.Parse(values[6]),
                            Fiber = float.Parse(values[7]),
                            Carbo = float.Parse(values[8]),
                            Sugars = int.Parse(values[9]),
                            Potass = int.Parse(values[10]),
                            Vitamins = int.Parse(values[11]),
                            Shelf = int.Parse(values[12]),
                            Weight = float.Parse(values[13]),
                            CupsPerServing = float.Parse(values[14]),
                            Rating = float.Parse(values[15])
                        };
                        cerealContext.Cereals.Add(cereal);
                    }
                }
                cerealContext.SaveChanges();
            }
        }
    }
}