using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Model;

namespace CerealAPI.Repository
{
    public class ManufactorerRepository(CerealContext context) : IManufactorerRepository
    {
        private readonly CerealContext _context = context;

        public Manufacturer GetManufactorer(char shortform)
        {
            return  _context.Manufacturers.Where(m => m.Shortform == shortform).First();
            // if (_context.Types.Any(m => m.Shortform == cereal.Type.Shortform))
            //     cereal.Type = _context.Types.Where(m => m.Shortform == cereal.Mfr.Shortform).First();
        }

        public bool ManufactorerExists(char shortform)
        {
            return _context.Manufacturers.Any(m => m.Shortform == shortform);
        }
    }
}