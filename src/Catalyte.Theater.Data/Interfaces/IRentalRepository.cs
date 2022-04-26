using Catalyte.Theater.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for rental repository methods.
    /// </summary>
    public interface IRentalRepository
    {
        Task<Rental> GetRentalByIdAsync(int rentalId);

        Task<IEnumerable<Rental>> GetAllRentalsAsync();

        Task<Rental> CreateRentalAsync(Rental rental);

        Task<Rental> UpdateRentalAsync(Rental updatedRental);

        Task DeleteRentalAsync(Rental rental);
    }
}
