using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace FinalProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        
        public DbSet<User> Users { set; get; }
        public DbSet<Profile> Profiles { set; get; }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<TvShow> TvShows { set; get; }
        public DbSet<FavoriteMovie> FavoriteMovies { set; get; }
        public DbSet<FavoriteTvShow> FavoriteTvShows { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            
            modelBuilder.Entity<Movie>()
                .Property(b => b.ProfileId)
                .HasDefaultValue(1);
            modelBuilder.Entity<TvShow>()
                .Property(b => b.ProfileId)
                .HasDefaultValue(1);


            // seeding
            List<Movie> moviesList = GetMovieList();

            for (int i = 0; i < moviesList.Count; i++)
            {
                modelBuilder.Entity<Movie>().HasData(new Movie()
                {Id = moviesList[i].Id,
                    Title = moviesList[i].Title,
                    Date = moviesList[i].Date,
                    Summary = moviesList[i].Summary,
                    Rating = moviesList[i].Rating,
                    Poster = moviesList[i].Poster});
            }
            
            List<TvShow> tvShowList = GetTvShowsList();
            
            for (int i = 0; i < tvShowList.Count; i++)
            {
                modelBuilder.Entity<TvShow>().HasData(new TvShow()
                {Id = tvShowList[i].Id,
                    Title = tvShowList[i].Title,
                    Date = tvShowList[i].Date,
                    Summary = tvShowList[i].Summary,
                    Rating = tvShowList[i].Rating,
                    Poster = tvShowList[i].Poster});
            }
            
        }
        
        
        public List<Movie> GetMovieList()
        {
            int count = 0;
            
            List<Movie> MovieList = new List<Movie>();
            for (int j = 1; j < 5; j++)
            {
                JArray result = GetJSON(true, j);
                for (int i = 0; i < result.Count; i++)
                {
                    MovieList.Add(new Movie()
                    {
                        Id = count + 1,
                        Title = result[i]["title"].ToString(),
                        Date = JObject.Parse(result[i].ToString()).ContainsKey("release_date") ? result[i]["release_date"].ToString() : null,
                        Summary = result[i]["overview"].ToString(),
                        Rating = Convert.ToInt32(result[i]["vote_average"]),
                        Poster = "https://image.tmdb.org/t/p/w300" + result[i]["poster_path"].ToString()
                    });
                    count++;
                }
            }

            return MovieList;
        }
        public List<TvShow> GetTvShowsList()
        {
            int count = 0;
            
            List<TvShow> tvShowList = new List<TvShow>();
            for (int j = 1; j < 5; j++)
            {
                JArray result = GetJSON(false, j);
                for (int i = 0; i < result.Count; i++)
                {
                    tvShowList.Add(new TvShow()
                    {
                        Id = count + 1,
                        Title = result[i]["name"].ToString(),
                        Date = JObject.Parse(result[i].ToString()).ContainsKey("first_air_date") ? result[i]["first_air_date"].ToString() : null,
                        Summary = result[i]["overview"].ToString(),
                        Rating = Convert.ToInt32(result[i]["vote_average"]),
                        Poster = "https://image.tmdb.org/t/p/w300" + result[i]["poster_path"].ToString()
                    });
                    count++;
                }
            }

            return tvShowList;
        }

        public JArray GetJSON(bool what, int page)
        {
            string html = string.Empty;
            
            string url = what? $@"https://api.themoviedb.org/3/movie/popular?api_key=5b1b9f67b573e2104ae29d0da0c6104f&language=en-US&page={page}" : $@"https://api.themoviedb.org/3/tv/popular?api_key=5b1b9f67b573e2104ae29d0da0c6104f&language=en-US&page={page}";
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            
            var res = JObject.Parse(html);
            JArray result = JArray.Parse(res["results"].ToString());

            return result;
        }

    }
}