using ABC_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Website.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }
        private readonly MovieDbContext _movieDbContext;
        public MovieController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        [HttpGet]
        public IEnumerable<MovieAk> GetMovie()
        {
            return _movieDbContext.movies.ToList();
        }
        [HttpGet("GetMovieById")]
        public MovieAk GetMovieById(int Id)
        {
            return _movieDbContext.movies.Find(Id);
        }
        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody] MovieAk movies)
        {
            if (movies.Id.ToString() != "")
            {
                //insert into tutorial values(tutorial.id,tutorial,name,tutorial.desc,tutorial.publish,tutorial.fees)
                _movieDbContext.movies.Add(movies);
                _movieDbContext.SaveChanges();
                return Ok("Saved successfully");
            }
            else
                return BadRequest(); //404 ERROR
        }
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] MovieAk movies)
        {
            if (movies.Id.ToString() != "")
            {
                //update tutorial set name=tutorial.name , desc=tutorial.desc , fees=tutorial.fees , publish=tutorial.publish where id=tutorial.id
                _movieDbContext.Entry(movies).State = EntityState.Modified;
                _movieDbContext.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }
        //localhost:3433/Tutorial/DeleteTutorial?tutorialId=3
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int Id)
        {
            //select * from tutorial where tutorialId=3
            var result = _movieDbContext.movies.Find(Id);
            _movieDbContext.movies.Remove(result);
            _movieDbContext.SaveChanges();
            return Ok("Deleted successfully");
        }

    }


    
}
