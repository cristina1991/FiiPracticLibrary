using System.Threading;
using System.Threading.Tasks;
using Library.Data.Entities.Context;

namespace Library.Data.Implementations
{
    public class DefaultRepository<T> : BaseEntityFrameworkRepository<T> where T : class
    {
      
        public DefaultRepository(DataBaseContext context)
            : base(context)
        {
        }

        protected override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
