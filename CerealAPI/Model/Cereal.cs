namespace CerealAPI.Model
{
    public class Cereal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Manufacturer Mfr { get; set; }
        public required Type Type { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Sodium { get; set; }
        public float Fiber { get; set; }
        public float Carbo { get; set; }
        public int Sugars { get; set; }
        public int Potass { get; set; }
        public int Vitamins { get; set; }
        public int Shelf { get; set; }
        public float Weight { get; set; }
        public float CupsPerServing { get; set; }
        public float Rating { get; set; }
    }
}