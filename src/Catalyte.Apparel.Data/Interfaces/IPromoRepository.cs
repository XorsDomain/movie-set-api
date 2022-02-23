using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    public interface IPromoRepository
    {
        Task<Promo> CreatePromoAsync(Promo promo);
    }
}