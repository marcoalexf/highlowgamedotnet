using HighLowGame.Infrastructure.Contexts;
using HighLowGame.Infrastructure.Entities;

namespace HighLowGame.Infrastructure.Repositories
{
    public class PlayerRepository
    {
        PlayerContext _playerContext;
        public PlayerRepository(PlayerContext playerContext) 
        { 
            _playerContext = playerContext;
        }

        public async Task<Player> AddPlayer(string username)
        {
            var playerToAdd = new Player() { Username = username};
            await this._playerContext.AddAsync(playerToAdd);
            return playerToAdd;
        }
    }
}
