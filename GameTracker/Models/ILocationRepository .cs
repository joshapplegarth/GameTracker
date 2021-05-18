using System.Linq;

namespace GameTracker.Models
{
    public interface ILocationRepository
    {
        //Create
        public Location Create(Location l);
        //Read
        public IQueryable<Location> GetAllLocations();
        public Location GetLocationById(int id);
        //Update
        public Location Update(Location l);
        //Delete
        public bool Delete(int id);

   
    }
}
