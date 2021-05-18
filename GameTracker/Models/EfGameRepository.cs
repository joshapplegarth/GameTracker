using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GameTracker.Models
{
    public class EfGameRepository : IGameRepository
    {
        private AppDbContext _context;
        private IUserRepository _userRepository;
        public EfGameRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository; 
        }

        //Methods

        //Create

        public Game Create(Game g)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                
                    _context.Game.Add(g);
                    _context.SaveChanges();
                
                
                return g;
            }

            return null;
        }
        public IQueryable<Game> GetAllGames(int locationId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Game.Where(g => g.Location.UserId == _userRepository.GetLoggedInUserId());
            }
            Game[] nogames = new Game[0];
            return nogames.AsQueryable();
        }

        public Game GetGameById(int gameId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Game
                           .Include(g => g.Location)
                           .FirstOrDefault(g => g.Id == gameId);
            }
            return null;
            
        }
        
        //Update
        public Game Update(Game g)
        {
            Game gameToUpdate = GetGameById(g.Id);
            if (gameToUpdate != null)
            {
                gameToUpdate.Type = g.Type;
                gameToUpdate.Gender =g.Gender;
                gameToUpdate.Weight = g.Weight;
                gameToUpdate.Date = g.Date;

                _context.SaveChanges();
            }
            return gameToUpdate;
        }
        
        //Delete
        
        public bool Delete(Game g)
        {
            Game gameToDelete = GetGameById(g.Id);
            if (gameToDelete == null)
            {
                return false;
            }
            _context.Game.Remove(gameToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
