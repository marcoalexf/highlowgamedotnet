
using HighLowGame.Infrastructure.Entities;

namespace HighLowGame.Infrastructure
{
    public class MockDB<T> : IMockDB<T> where T : IEntity
    {
        public List<T> entites;

        public MockDB()
        {
            this.entites = new List<T>();
        }

        public async virtual Task<T> AddAsync(T t)
        {
            var newGuid = Guid.NewGuid();
            while (entites.Single(p => p.Id == newGuid) is not null)
            {
                newGuid = Guid.NewGuid();
            };
            t.Id = newGuid;
            entites.Add(t);

            // simulating db for now
            await Task.Delay(500);

            return t;
        }

        public virtual Task DeleteAsync(Guid id)
        {
            var toDelete = this.entites.Find(p => p.Id.Equals(id));
            if (toDelete != null)
            {
                this.entites.Remove(toDelete);
                return Task.CompletedTask;
            }
            // improve this... again DB integration takes too long
            throw new Exception();
        }

        public virtual Task<T?> GetAsync(Guid id)
        {
            return Task.FromResult(this.entites.Find(p => p.Id.Equals(id)));
        }

        public virtual Task<T> UpdateAsync(T t)
        {
            var toUpdate = this.entites.Find(p => p.Id.Equals(t.Id));

            if (toUpdate != null)
            {
                this.entites.Remove(toUpdate);
                this.entites.Add(t);
                return Task.FromResult(t);
            }

            throw new Exception();
        }
    }
}
