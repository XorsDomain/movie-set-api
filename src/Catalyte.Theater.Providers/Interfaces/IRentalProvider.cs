using Catalyte.Theater.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for rental related service methods.
    /// </summary>
    public interface IRentalProvider
    {
        Task<Rental> GetRentalByIdAsync(int rentalId);

        Task<IEnumerable<Rental>> GetAllRentalsAsync();

        Task<Rental> CreateRentalAsync(Rental rental);

        Task<Rental> UpdateRentalAsync(int id, Rental updatedRental);

        Task DeleteRentalByIdAsync(int rentalId);
    }
}
