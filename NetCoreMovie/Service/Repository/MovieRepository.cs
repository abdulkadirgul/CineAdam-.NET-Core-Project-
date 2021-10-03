﻿using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext movieContext;

        public MovieRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }
        public bool Any(Expression<Func<Movie, bool>> exp)
        {
            return movieContext.Movies.Any(exp);
        }

        public string DeleteMovie(int MovieId)
        {
            try
            {
                movieContext.Movies.Remove(Find(MovieId));
                movieContext.SaveChanges();
                return $"Film Silindi";

            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }

        public Movie Find(int MovieId)
        {
            return movieContext.Movies.Find(MovieId);
        }

        public List<Movie> GetMovies()
        {
          return  movieContext.Movies.ToList();
        }

        public string PostMovie(Movie Movie)
        {
            try
            {
                movieContext.Movies.Add(Movie);
                movieContext.SaveChanges();
                return $"Film Eklendi! ";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateMovie(Movie movie)
        {
            try
            {
                Movie updated = Find(movie.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(movie);
                movieContext.SaveChanges();
                return $"Film Güncellendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           


        }

        public List<Movie> Where(Expression<Func<Movie, bool>> exp)
        {
            return movieContext.Movies.Where(exp).ToList();
        }
    }
}
