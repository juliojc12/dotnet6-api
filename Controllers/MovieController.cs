using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    Guid id = Guid.NewGuid();
    
    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip=0,
                                        [FromQuery] int take=20)
    {
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }   
        return Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(Guid id, [FromBody] UpdateMovieDto movieDto)
    {
        var movieFromDb = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movieFromDb == null)
        {
            return NotFound();
        }
        _mapper.Map(movieDto, movieFromDb);
        _context.SaveChanges();

        return NoContent();
    }
}
