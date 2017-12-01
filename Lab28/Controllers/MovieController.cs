using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab28.Models;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Lab28.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Movy> ListMovies()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.ToList();

        }

        [HttpGet]
        public List<Movy> ListMoviesByGenre(string genre)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();

        }

        [HttpGet]
        public Movy ListRandomMovie()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            Random rand = new Random();


            return ORM.Movies.ToList()[rand.Next(ORM.Movies.Count())];
        }

        [HttpGet]
        public Movy ListRandomMoviesFromGenre(string genre)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            Random rand = new Random();

            List<Movy> GenreList = ORM.Movies.Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();


            return GenreList[rand.Next(GenreList.Count())];

        }

        //ToDo: Finish this
        public List<Movy> ListMovieInfo(string title)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Where(x => x.Info.ToLower() == title.ToLower()).ToList();
        }

    }
}
