using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameTracker.Models
{
    public class EfLocationRepository : ILocationRepository
    {
        private AppDbContext _context;
        private IUserRepository _userRepository;

        public EfLocationRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;

        }

        //Methods

        //Create

        public Location Create(Location l)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                try
                {
                    l.UserId = _userRepository.GetLoggedInUserId();
                    _context.Location.Add(l);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                }
                return l;
            }

            return null;
        }

        //Read
        public IQueryable<Location> GetAllLocations()
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Location.Where(l => l.UserId == _userRepository.GetLoggedInUserId());
            }

            Location[] noLocations = new Location[0];
            return noLocations.AsQueryable<Location>();
        }

        public Location GetLocationById(int id)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                Location l = _context.Location
                                .Include(l => l.Game)
                                .FirstOrDefault(l => l.Id == id && l.UserId == _userRepository.GetLoggedInUserId());
                if (l != null)
                {
                    l.Game = l.Game.OrderByDescending(g => g.Date);
                }
                return l;
            }
            return null;
        }

        //Update
        public Location Update(Location l)
        {
            Location locationToUpdate = GetLocationById(l.Id);
            if (locationToUpdate != null)
            {
                locationToUpdate.City = l.City;
                locationToUpdate.State = l.State;
                locationToUpdate.LandOwner = l.LandOwner;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                }
            }
            return locationToUpdate;
        }

        //Delete

        public bool Delete(int id)
        {
            Location locationToDelete = GetLocationById(id);
            if (locationToDelete == null)
            {
                return false;
            }
            try
            {
                _context.Location.Remove(locationToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
            
        }
        //public bool Delete(Location l)
        //{
        //    return Delete(l.Id);
        //}
    }
}
