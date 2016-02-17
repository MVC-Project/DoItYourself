namespace DoItYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using DoItYourself.Data.Common;
    using DoItYourself.Data.Models;

    public class LocationService : ILocationService
    {
        private readonly IDbRepository<Location> locations;

        public LocationService(IDbRepository<Location> locations)
        {
            this.locations = locations;
        }

        public IQueryable<Location> AllLocations()
        {
            return this.locations.All()
                .OrderBy(location => location.City);
        }

        public IQueryable<Location> AllLocationsWithDeleted()
        {
            return this.locations.AllWithDeleted()
                .OrderBy(location => location.City);
        }

        public Location GetById(int id)
        {
            return this.locations.GetById(id);
        }

        public IQueryable<string> AllCities()
        {
            return this.locations.All()
                .OrderBy(location => location.City)
                .Select(location => location.City);
        }

        public void DeleteLocation(Location location)
        {
            this.locations.Delete(location);
            this.locations.Save();
        }

        public void HardDeleteLocation(Location location)
        {
            this.locations.HardDelete(location);
            this.locations.Save();
        }

        public void DeleteLocationById(int id)
        {
            var location = this.locations.GetById(id);
            this.locations.Delete(location);
            this.locations.Save();
        }

        public void HardDeleteLocationById(int id)
        {
            var location = this.locations.GetById(id);
            this.locations.Delete(location);
            this.locations.Save();
        }

        public void AddLocation(Location location)
        {
            this.locations.Add(location);
            this.locations.Save();
        }
    }
}
