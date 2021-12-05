using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class NewMovieData
    {
        public List<NewMovieDataDetail> Items { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class NewMovieDataDetail
    {
        public string Id { get; set; }
        public string Title { set; get; }
        public string FullTitle { set; get; }
        public string Year { set; get; }
        public string ReleaseState { set; get; }
        public string Image { get; set; }
        public string Stars { set; get; }
    }
}
