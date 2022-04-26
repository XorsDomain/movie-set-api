using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Theater.DTOs.Rentals;
using Catalyte.Theater.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalyte.Theater.Data.Model;

namespace Catalyte.Theater.API.Controllers
{
    /// <summary>
    /// The RentalsController exposes endpoints for rental related actions.
    /// </summary>
    [ApiController]
    [Route("/rentals")]
    public class RentalsController : ControllerBase
    {
        private readonly ILogger<RentalsController> _logger;
        private readonly IRentalProvider _rentalProvider;
        private readonly IMapper _mapper;

        public RentalsController(
            ILogger<RentalsController> logger,
            IRentalProvider rentalProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _rentalProvider = rentalProvider;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDTO>> GetRentalByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetRentalByIdAsync for id: {id}");

            var rental = await _rentalProvider.GetRentalByIdAsync(id);
            var rentalDTO = _mapper.Map<RentalDTO>(rental);

            return Ok(rentalDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDTO>>> GetAllRentalsAsync()
        {
            var result = await _rentalProvider.GetAllRentalsAsync();

            IEnumerable<RentalDTO> rentalDTO = _mapper.Map<IEnumerable<RentalDTO>>(result);
            return Ok(rentalDTO);
        }

        [HttpPost]
        public async Task<ActionResult<RentalDTO>> CreateRentalAsync([FromBody] RentalDTO rentalToCreate)
        {
            _logger.LogInformation("Request recieved for CreateRentalAsync");

            var rental = _mapper.Map<Rental>(rentalToCreate);
            var newRental = await _rentalProvider.CreateRentalAsync(rental);
            var rentalDTO = _mapper.Map<RentalDTO>(newRental);
            return Created("/rentals", rentalDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentalDTO>> UpdateRentalAsync(int id, [FromBody] RentalDTO rentalToUpdate)
        {
            _logger.LogInformation("Request received for UpdateRentalAsync");

            var rental = _mapper.Map<Rental>(rentalToUpdate);
            var updatedRental = await _rentalProvider.UpdateRentalAsync(id, rental);
            var rentalDTO = _mapper.Map<RentalDTO>(updatedRental);

            return Ok(rentalDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRentalById(int id)
        {
            await _rentalProvider.DeleteRentalByIdAsync(id);
            return NoContent();
        }

    }
}
