using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MovieController : ApiController
    {

        private readonly ApplicationDbContext Context;
        public MovieController()
        {
            Context = new ApplicationDbContext();
        }


        //Get /api/movie
        [HttpGet]
        
        public IHttpActionResult GetMovies(string query =null)
        {
            var movieQuery = Context.Movies.
                Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));

            var movieDto = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }


        //Get/api/movie/1
        [HttpGet]
        [Authorize (Roles =RoleName.CanMangeMovies)]
        public IHttpActionResult Movie(int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }



        //Post/api/movie
        [HttpPost]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

             Context.Movies.Add(movie);
            Context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto.Id);
        }






        //Put /api/movie
        [HttpPut]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public void UpdateMovie(int id , MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieIndb = Context.Movies.SingleOrDefault(m => m.Id == id);


            if (movieIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(movieDto, movieIndb);
            Context.SaveChanges();

        }





        //Delet/api/movie
        [HttpDelete]
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public void Delete(int id) 
        {
            var movie = Context.Movies.SingleOrDefault(m => m.Id ==id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Context.Movies.Remove(movie);
            Context.SaveChanges();
        }
    }
}
