
using CerealAPI.Model;

namespace CerealAPI.Interfaces
{
    public interface ITypeRepository
    {
        public Model.Type GetType(char shortform);
        public bool TypeExists(char shortform);
    }
}