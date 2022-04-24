﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Movies;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The MoviesController exposes endpoints for movie related actions.
    /// </summary>
    [ApiController]
    [Route("/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieProvider _movieProvider;
        private readonly IMapper _mapper;

        public MoviesController(
            ILogger<MoviesController> logger,
            IMovieProvider movieProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _movieProvider = movieProvider;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovieByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetMovieByIdAsync for id: {id}");

            var movie = await _movieProvider.GetMovieByIdAsync(id);
            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMoviesAsync()
        {
            var result = await _movieProvider.GetAllMoviesAsync();

            IEnumerable<MovieDTO> movieDTO = _mapper.Map<IEnumerable<MovieDTO>>(result);
            return Ok(movieDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovieAsync([FromBody]MovieDTO movieToCreate)
        {
            _logger.LogInformation("Request recieved for CreateMovieAsync");

            var movie = _mapper.Map<Movie>(movieToCreate);
            var newMovie = await _movieProvider.CreateMovieAsync(movie);
            var movieDTO = _mapper.Map<MovieDTO>(newMovie);
            return Created("/movies", movieDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDTO>> UpdateMovieAsync(int id, [FromBody] MovieDTO movieToUpdate)
        {
            _logger.LogInformation("Request received for UpdateMovieAsync");

            var movie = _mapper.Map<Movie>(movieToUpdate);
            var updatedMovie = await _movieProvider.UpdateMovieAsync(id, movie);
            var movieDTO = _mapper.Map<MovieDTO>(updatedMovie);

            return Ok(movieDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovieById(int id)
        {
            await _movieProvider.DeleteMovieByIdAsync(id);
            return NoContent();
        }

    }
}
