using CerealAPI.Model;

namespace CerealAPI.DTO
{
    public class ManufacturerDTO
    {
        public char Shortform { get; set; }
        public required string Name { get; set; }
    }
}