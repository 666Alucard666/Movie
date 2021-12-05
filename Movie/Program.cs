using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movie.Data;
using Movie.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movie
{
    public class Program
    {
        public const string SERIALS = @"http://localhost:2789/upcomingserials";
        public const string MOVIES = @"https://imdb-api.com/en/API/ComingSoon/k_izy438np";
        public static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MOVIES);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string sReadData = streamReader.ReadToEnd();
            var movie = JsonConvert.DeserializeObject<NewMovieData>(sReadData);
            response.Close();
            HttpWebRequest requestSerials = (HttpWebRequest)WebRequest.Create(SERIALS);
            HttpWebResponse responseSerials = (HttpWebResponse)requestSerials.GetResponse();
            Stream streamSerials = response.GetResponseStream();
            StreamReader streamReaderSerials = new StreamReader(streamSerials);
            string sReadDataSerials = streamReaderSerials.ReadToEnd();
            var serials = JsonConvert.DeserializeObject<NewSerialData>(sReadDataSerials);
            response.Close();
            using (NewMovieContext db = new NewMovieContext())
            {
                foreach (var item in movie.Items)
                {
                    if (!db.NewMovies.Contains(item))
                    {
                        db.Add(item);
                    }
                }
                foreach (var item in db.NewMovies)
                {
                    if (!movie.Items.Select(m => m.Title).Contains(item.Title))
                    {
                        Console.WriteLine($"Todays premier is {item.Title}");
                        db.NewMovies.Remove(item);
                    }
                }
                db.SaveChanges();
            }
            using (NewSerialContext db2 = new NewSerialContext())
            {
                foreach (var item in serials.Items)
                {
                    if (!db2.NewSerials.Contains(item))
                    {
                        db2.Add(item);
                    }
                }
                foreach (var item in db2.NewSerials)
                {
                    if (!serials.Items.Select(m => m.EpisodeTitle).Contains(item.EpisodeTitle))
                    {
                        Console.WriteLine($"Todays premier is {item.EpisodeTitle}");
                        db2.NewSerials.Remove(item);
                    }
                }
                db2.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
