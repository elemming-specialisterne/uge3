
using CerealAPI.Model;

namespace CerealAPI.Interfaces
{
    public interface IManufactorerRepository
    {
        public Manufacturer GetManufactorer(char shortform);
        public bool ManufactorerExists(char shortform);
    }
}