using HighLowGame.Domain.Aggregates.GameAggregate;

namespace HighLowGame.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    public Task<Guid> AddAsync(Game entity)
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}