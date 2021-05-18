using System.Linq;

namespace GameTracker.Models
{
    public interface IGameRepository
    {
        //Create
        public Game Create(Game g);
        //Read
        public IQueryable<Game> GetAllGames(int locationId);

        public Game GetGameById(int gameId);

        //Update
        public Game Update(Game g);

        //Delete
        public bool Delete(Game g);
    }
}
