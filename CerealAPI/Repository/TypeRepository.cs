using CerealAPI.Data;
using CerealAPI.Interfaces;
using CerealAPI.Model;

namespace CerealAPI.Repository
{
    public class TypeRepository(CerealContext context) : ITypeRepository
    {
        private readonly CerealContext _context = context;

        public Model.Type GetType(char shortform)
        {
            return  _context.Types.Where(t => t.Shortform == shortform).First();
            // if (_context.Types.Any(m => m.Shortform == cereal.Type.Shortform))
            //     cereal.Type = _context.Types.Where(m => m.Shortform == cereal.Mfr.Shortform).First();
        }

        public bool TypeExists(char shortform)
        {
            return _context.Types.Any(t => t.Shortform == shortform);
        }
    }
}