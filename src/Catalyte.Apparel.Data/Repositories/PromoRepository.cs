using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    public class PromoRepository : IPromoRepository
    {
        private readonly IApparelCtx _ctx;
        
        public PromoRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Promo> CreatePromoAsync(Promo promo)
        {
            _ctx.Promos.Add(promo);
            await _ctx.SaveChangesAsync();

            return promo;
        }

    }
}
