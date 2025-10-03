using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CerealAPI.Repository
{
    public class CerealRepository(CerealContext context) : ICerealRepository
    {
        private readonly CerealContext _context = context;

        public bool CerealExists(int id)
        {
            return _context.Cereals.Any(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool CreateCereal(Cereal cereal)
        {
            _context.Add(cereal);
            return Save();
        }

        public Cereal GetCereal(int id)
        {
            return _context.Cereals.Where(c => c.Id == id).Include(c => c.Mfr).Include(c => c.Type).FirstOrDefault();
        }

        public ICollection<Cereal> GetCereals()
        {
            return [.. _context.Cereals.Include(c => c.Mfr).Include(c => c.Type)];
        }

        public ICollection<Cereal> GetCerealsWhere()
        {
            //_context.
            return [.. _context.Cereals];
        }

        public bool UpdateCereal(Cereal cereal)
        {
            _context.Update(cereal);
            return Save();
        }

        public bool DeleteCereal(Cereal cereal)
        {
            _context.Set<Cereal>().Remove(cereal);
            return Save();
        }
    }
}