using CerealAPI.Model;

namespace CerealAPI.Interfaces
{
    public interface ICerealRepository
    {
        ICollection<Cereal> GetCereals();
        Cereal GetCereal(int id);
        bool CerealExists(int id);
        bool Save();
        bool CreateCereal(Cereal cereal);
        bool UpdateCereal(Cereal cereal);
        bool DeleteCereal(Cereal cereal);
        // (
        //     int Id,
        //     string Name,
        //     string MfrShotform,
        //     string TypeShortform,
        //     int Calories,
        //     int Protein,
        //     int Fat,
        //     int Sodium,
        //     float Fiber,
        //     float Carbo,
        //     int Sugars,
        //     int Potass,
        //     int Vitamins,
        //     int Shelf,
        //     float Weight,
        //     float CupsPerServing,
        //     float Rating
        //     );
    }
}