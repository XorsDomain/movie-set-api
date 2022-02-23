using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IPromoProvider
    {
        Task<Promo> CreatePromoAsync(Promo model);
    }
}
