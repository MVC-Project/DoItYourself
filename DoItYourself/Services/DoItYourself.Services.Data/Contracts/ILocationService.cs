namespace DoItYourself.Services.Data.Contracts
{
    using System.Linq;

    using DoItYourself.Data.Models;

    public interface ILocationService
    {
        IQueryable<Location> AllLocations();

        IQueryable<Location> AllLocationsWithDeleted();

        Location GetById(int id);

        IQueryable<string> AllCities();

        void DeleteLocation(Location location);

        void HardDeleteLocation(Location location);

        void DeleteLocationById(int id);

        void HardDeleteLocationById(int id);

        void AddLocation(Location location);
    }
}
