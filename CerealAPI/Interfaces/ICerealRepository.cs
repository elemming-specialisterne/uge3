using CerealAPI.Model;

namespace CerealAPI.Interfaces
{
    public interface ICerealRepository
    {
        ICollection<Cereal> GetCereals();
    }
}