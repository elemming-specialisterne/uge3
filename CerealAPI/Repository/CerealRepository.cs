using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Model;

namespace CerealAPI.Repository
{
    public class CerealRepository(CerealContext context) : ICerealRepository
    {
        private readonly CerealContext _context = context;

        public ICollection<Cereal> GetCereals()
        {
            return [.. _context.Cereals];
        }
    }
}